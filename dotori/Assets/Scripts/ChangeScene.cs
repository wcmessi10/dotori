using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    //public Button button1; // 닫기 버튼
    //public Button button; // 신청하기 버튼

    public string sceneName;
    public float x;
    public float y;
    public float z;

    private void Start()
    {
        // 1번 버튼에 클릭 이벤트 리스너 추가
        /*button1 = GetComponent<Button>();
        button2 = GetComponent<Button>();
        
        button1.onClick.AddListener(OnClickButton1);*/
        // 2번 버튼에 클릭 이벤트 리스너 추가
        /*button2.onClick.AddListener(OnClickButton2);*/
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Teleport(sceneName, x, y, z);
        }
        
    }

    public void Teleport(string sceneName)//버튼 클릭용 
    {
        SceneManager.LoadScene(sceneName); // 원하는 씬으로 이동
    }

    public void Teleport(string sceneName, float x, float y, float z)//각각 워프로 이동할 좌표를 미리 정해둔다.
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log("문이 클릭됨");
                PlayerPrefs.SetFloat("x", x);
                PlayerPrefs.SetFloat("y", y);
                PlayerPrefs.SetFloat("z", z);
                SceneManager.LoadScene(sceneName);
                //스타트 포인트는 Start() 함수에 SetFloat넣은 좌표를 position으로 정한 스크립트를 만들어 플레이어 오브젝트에 component 추가
            }
        }
    }
}
