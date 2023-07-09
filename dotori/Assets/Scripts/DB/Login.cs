using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;     //C#�� ������ ���̺� ������ ���
using System;
using MySql.Data;     //MYSQL�Լ����� �ҷ����� ���ؼ� ���
using MySql.Data.MySqlClient;    //Ŭ���̾�Ʈ ���������ϱ� ���ؼ� ���
using UnityEngine.SceneManagement;//�� �̵�


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

                SceneManager.LoadScene("Lobby"); //���̵�
            }
            else
            {
                fail.text += "�й� Ȥ�� ��й�ȣ�� Ʋ�Ƚ��ϴ�. �ٽ� �Է��Ͻÿ�";
            }
        }
        catch(Exception e)
        {
            fail.text += "�й� Ȥ�� ��й�ȣ�� Ʋ�Ƚ��ϴ�. �ٽ� �Է��Ͻÿ�";
            Debug.Log(e);
        }
    }
}
