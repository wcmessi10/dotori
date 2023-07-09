using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;     //C#의 데이터 테이블 때문에 사용
using System;
using MySql.Data;     //MYSQL함수들을 불러오기 위해서 사용
using MySql.Data.MySqlClient;    //클라이언트 기능을사용하기 위해서 사용
using UnityEngine.SceneManagement;//씬 이동


public class Login : DBConnect
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public InputField studentIDInput;
    private string studentID;
    public InputField passwordInput;
    private string password;
    public Text fail;
    
    public void login()
    {
        studentID = studentIDInput.GetComponent<InputField>().text;
        password = passwordInput.GetComponent<InputField>().text;
        string query = "select studentID from account_t where studentID=" + studentID + " && pw = password('" + password + "');";
        
        DataTable dt = new DataTable();

        fail.text = "";
        try
        {
            dt = selsql(query);
            Debug.Log(dt.Rows.Count);
            if (dt.Rows.Count >0)
            {
                

                PlayerPrefs.SetString("studentID",dt.Rows[0]["studentID"].ToString());

                Debug.Log(PlayerPrefs.GetString("studentID"));

                SceneManager.LoadScene("Lobby"); //씬이동
            }
            else
            {
                fail.text += "학번 혹은 비밀번호가 틀렸습니다. 다시 입력하시오";
            }
        }
        catch(Exception e)
        {
            fail.text += "학번 혹은 비밀번호가 틀렸습니다. 다시 입력하시오";
            Debug.Log(e);
        }
    }
}
