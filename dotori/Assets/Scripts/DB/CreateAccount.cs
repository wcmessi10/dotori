using System.Data;     //C#�� ������ ���̺� ������ ���
using MySql.Data;     //MYSQL�Լ����� �ҷ����� ���ؼ� ���
using MySql.Data.MySqlClient;    //Ŭ���̾�Ʈ ���������ϱ� ���ؼ� ���
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
        if (email.Contains("@"))//����� ���ٸ�?
        {
            if (studentID.Length == 8)
            {
                string query = "insert into account_t(email, studentID, pw, nickname) values('" + email + "'," + studentID + ",password('" + password + "'),'" + nickname+ "');";
                try
                {
                    sqlcmdall(query);
                }catch(Exception e)
                {
                    fail.text = "�̹� �ִ� �й� �����Դϴ�";
                }
                
                SceneManager.LoadScene("Login");
            }
            else
            {
                fail.text += " �й� ������ ����� �����ּ��� ";
            }
        }
        else
        {
            fail.text += " �̸��� ������ ����� �����ּ��� ";
        }
    }
}
