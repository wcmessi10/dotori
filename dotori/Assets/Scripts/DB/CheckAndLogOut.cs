using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//씬 이동

public class CheckAndLogOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Check()
    {
        string studentID = PlayerPrefs.GetString("studentID");//이전씬에서 PlayerPrefs에 저장했던 studentID 데이터 가져오기
        Debug.Log(studentID);
    }

    public void Logout()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Login");
    }
}
