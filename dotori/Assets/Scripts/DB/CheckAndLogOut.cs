using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�� �̵�

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
        string studentID = PlayerPrefs.GetString("studentID");//���������� PlayerPrefs�� �����ߴ� studentID ������ ��������
        Debug.Log(studentID);
    }

    public void Logout()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Login");
    }
}
