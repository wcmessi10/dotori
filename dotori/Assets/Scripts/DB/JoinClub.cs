using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;     //C#�� ������ ���̺� ������ ���
using MySql.Data;     //MYSQL�Լ����� �ҷ����� ���ؼ� ���
using MySql.Data.MySqlClient;    //Ŭ���̾�Ʈ ���������ϱ� ���ؼ� ���

public class JoinClub : DBConnect
{
    public InputField nameInput;
    private string name;
    public Text studentIDInput;
    private string studentID;
    public InputField majorInput;
    private string major;
    public InputField phoneInput;
    private string phone;
    public InputField motiveInput;
    private string motive;
    public Text fail;
    public GameObject popUp;

    // Start is called before the first frame update
    void Start()
    {
        string user = PlayerPrefs.GetString("studentID");
        Debug.Log("studentID");
        studentIDInput.text = user;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void join()
    {
        fail.text = "";
        name = nameInput.text;
        studentID = studentIDInput.text;
        major = majorInput.GetComponent<InputField>().text;
        phone = phoneInput.GetComponent<InputField>().text;
        motive = motiveInput.GetComponent<InputField>().text;
        if (phone.Length == 13)
        {
            if(studentID.Length == 8)
            {
                string query = "insert into club_t(club_no, name, studentID, major, phone, motive) values(1,'" + name + "'," + studentID + ",'" + major + "','" + phone + "','" + motive + "');";
                sqlcmdall(query);
                nameInput.text = "";
                studentIDInput.text = "";
                majorInput.GetComponent<InputField>().text = "";
                phone = phoneInput.GetComponent<InputField>().text = "";
                motive = motiveInput.GetComponent<InputField>().text = "";
                popUp.SetActive(false);
            }
            else
            {
                fail.text += " �й��� ���̸� �����ּ���";
            }
        }
        else
        {
            if (studentID.Length != 8)
            {
                fail.text += "��ȭ��ȣ�� ��Ȯ�� �Է����ֽð�, �й��� ���̸� �����ּ���";
            }
            else {
                fail.text += "��ȭ��ȣ�� ��Ȯ�� �Է����ּ���";
            }
        }
        
    }
}
