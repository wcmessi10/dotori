using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class LoadingSceneController : MonoBehaviour
{
    #region Singleton

    private static LoadingSceneController instance;
    public static LoadingSceneController Instance
    {
        get
        {
            if (instance == null)
            {
                LoadingSceneController sceneController = FindObjectOfType<LoadingSceneController>();
                if (sceneController != null)
                {
                    instance = sceneController;
                }
                else
                {
                    // 인스턴스가 없다면 생성
                    instance = Create();
                }
            }

            return instance;
        }
    }

    #endregion

    private static LoadingSceneController Create()
    {
        // 리소스에서 로드
        return Instantiate(Resources.Load<LoadingSceneController>("LoadingUI"));
    }

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] private CanvasGroup mCanvasGroup;
    [SerializeField] private Image mProgressBar;
    [SerializeField] private TextMeshProUGUI mToolTipLabel;
    [SerializeField][TextArea] string[] mToolTips;

    private string mLoadSceneName;

    Action? mOnSceneLoadAction;

    public void LoadScene(string sceneName, Action? action = null)
    {
        gameObject.SetActive(true);
        SceneManager.sceneLoaded += OnSceneLoaded;
        mOnSceneLoadAction = action;

        mLoadSceneName = sceneName;

        mToolTipLabel.text = mToolTips[UnityEngine.Random.Range(0, mToolTips.Length - 1)];

        StartCoroutine(CoLoadSceneProcess());
    }

    private IEnumerator CoLoadSceneProcess()
    {
        mProgressBar.fillAmount = 0.0f;

        //코루틴 안에서 yield return으로 코루틴을 실행하면.. 해당 코루틴이 끝날때까지 대기한다
        yield return StartCoroutine(Fade(true));

        //로컬 로딩
        AsyncOperation op = SceneManager.LoadSceneAsync(mLoadSceneName);

        op.allowSceneActivation = false;

        float process = 0.0f;

        //씬 로드가 끝나지 않은 상태라면?
        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                mProgressBar.fillAmount = op.progress;
            }
            else
            {
                process += Time.unscaledDeltaTime * 5.0f;
                mProgressBar.fillAmount = Mathf.Lerp(0.9f, 1.0f, process);

                if (process > 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name == mLoadSceneName)
        {
            StartCoroutine(Fade(false));
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private IEnumerator CoLateStart()
    {
        yield return new WaitForEndOfFrame();

        // 예약된 함수 실행
        mOnSceneLoadAction?.Invoke();
    }

    private IEnumerator Fade(bool isFadeIn)
    {
        float process = 0f;

        if (!isFadeIn)
            StartCoroutine(CoLateStart());

        while (process < 1.0f)
        {
            process += Time.unscaledDeltaTime;
            mCanvasGroup.alpha = isFadeIn ? Mathf.Lerp(0.0f, 1.0f, process) : Mathf.Lerp(1.0f, 0.0f, process);

            yield return null;
        }

        if (!isFadeIn)
            gameObject.SetActive(false);
    }
}