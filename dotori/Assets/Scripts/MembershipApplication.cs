using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;     //C#�� ������ ���̺� ������ ���
using MySql.Data;     //MYSQL�Լ����� �ҷ����� ���ؼ� ���
using MySql.Data.MySqlClient; 

public class MembershipApplication : DBConnect
{
    public Text memberName;
    public Text memberStudentID;
    public Text memberMajor;
    public Text memberPhone;
    public Text memberMotive;
    public GameObject popUp;
    public GameObject popUp2;
    
    /*void OnEnable()
    {
        Profile();
    }*/
    
    public void Profile()
    {
        
        string subscriber = PlayerPrefs.GetString("subscriber");
        Debug.Log(subscriber);
        DataTable dt = new DataTable();
        string query = "select name, studentID, major, phone, motive from club_t where studentID = " + subscriber;
        dt = selsql(query);
        memberName.text = dt.Rows[0]["name"].ToString();
        memberStudentID.text = dt.Rows[0]["studentID"].ToString();
        memberMajor.text = dt.Rows[0]["major"].ToString();
        memberPhone.text = dt.Rows[0]["phone"].ToString();
        memberMotive.text = dt.Rows[0]["motive"].ToString();
        
        
    }
    public void OK()
    {
        string query = "update account_t set club_no = 1 where studentID = " + memberStudentID.text;
        string query2 = "delete from club_t where studentID = " + memberStudentID.text;
        sqlcmdall(query);
        sqlcmdall(query2);
        
        popUp2.SetActive(true);
        popUp.SetActive(false);
    }
    public void No()
    {
        string query = "delete from club_t where studentID = " + memberStudentID.text;
        sqlcmdall(query);
        popUp2.SetActive(true);
        popUp.SetActive(false);
    }
}
