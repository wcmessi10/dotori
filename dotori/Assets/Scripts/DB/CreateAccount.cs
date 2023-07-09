using System.Data;     //C#의 데이터 테이블 때문에 사용
using MySql.Data;     //MYSQL함수들을 불러오기 위해서 사용
using MySql.Data.MySqlClient;    //클라이언트 기능을사용하기 위해서 사용
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class CreateAccount : DBConnect
{
    public InputField emailInput;
    private string email;
    public InputField studentIDInput;
    private string studentID;
    public InputField passwordInput;
    private string password;
    public InputField nicknameInput;
    private string nickname;
    public Text fail;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void newAccount()
    {
        fail.text = "";
        email = emailInput.GetComponent<InputField>().text;
        studentID = studentIDInput.GetComponent<InputField>().text;
        password = passwordInput.GetComponent<InputField>().text;
        nickname = nicknameInput.GetComponent<InputField>().text;
        if (email.Contains("@"))//골뱅이 없다면?
        {
            if (studentID.Length == 8)
            {
                string query = "insert into account_t(email, studentID, pw, nickname) values('" + email + "'," + studentID + ",password('" + password + "'),'" + nickname+ "');";
                try
                {
                    sqlcmdall(query);
                }catch(Exception e)
                {
                    fail.text = "이미 있는 학번 계정입니다";
                }
                
                SceneManager.LoadScene("Login");
            }
            else
            {
                fail.text += " 학번 형식을 제대로 적어주세요 ";
            }
        }
        else
        {
            fail.text += " 이메일 형식을 제대로 적어주세요 ";
        }
    }
}
