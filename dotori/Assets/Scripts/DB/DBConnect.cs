using System.Data;     //C#�� ������ ���̺� ������ ���
using MySql.Data;     //MYSQL�Լ����� �ҷ����� ���ؼ� ���
using MySql.Data.MySqlClient;    //Ŭ���̾�Ʈ ���������ϱ� ���ؼ� ���
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class DBConnect : MonoBehaviour
{
    MySqlConnection sqlconn = null;
    MySqlTransaction transaction = null;
    MySqlDataAdapter adapter = null;
    string sqlDBip = //"localhost";
        "dotori.cvymcsnbbta3.ap-northeast-2.rds.amazonaws.com";
    string sqlDBname = "dotori";
    string sqlDBid = "root";
    string sqlDBpw = "hd20161308";
    string port = "3306";
    void sqlConnect()
    {
        //DB���� �Է�
        string sqlDatabase = "Server=" + sqlDBip + ";Database=" + sqlDBname + ";UserId=" + sqlDBid + ";Password=" + sqlDBpw + ";Port="+port +"";
        //string sqlDatabase = "Server=" + sqlDBip + ";Database=" + sqlDBname + ";UserId=" + sqlDBid + ";Password=" + sqlDBpw + ";";
        //���� Ȯ���ϱ�
        try
        {
            sqlconn = new MySqlConnection(sqlDatabase);
            sqlconn.Open();
            Debug.Log("SQL�� ���� ���� : " + sqlconn.State); //������ �Ǹ� OPEN�̶�� ��Ÿ��
        }
        catch (Exception msg)
        {
            Debug.Log(msg); //��Ÿ�ٸ������� ��Ÿ���� ������ ���� ������ ��Ÿ��
        }
    }

    void sqldisConnect()
    { 
        sqlconn.Close();
        Debug.Log("SQL�� ���� ���� : " + sqlconn.State); //������ ����� Close�� ��Ÿ�� 
    }

    public void sqlcmdall(string allcmd) //�Լ��� �ҷ��ö� ��ɾ ���� String�� ���ڷ� �޾ƿ�
    {
        sqlConnect(); //����
        using (transaction = sqlconn.BeginTransaction())
        {
            try
            {
                using(MySqlCommand dbcmd = new MySqlCommand(allcmd, sqlconn))
                {
                    dbcmd.Transaction = transaction;
                    dbcmd.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch(Exception e)
            {
                transaction.Rollback();
                Debug.LogError("Transaction failed: " + e.Message);
            }
        }
        /*
        MySqlCommand dbcmd = new MySqlCommand(allcmd, sqlconn); //��ɾ Ŀ�ǵ忡 �Է�
        dbcmd.Transaction = transaction;
        dbcmd.ExecuteNonQuery(); //��ɾ SQL�� ����
        //dbcmd = new MySqlCommand("COMMIT", sqlconn);
        transaction.Commit();
        sqldisConnect(); //��������*/
        sqldisConnect();
    }

    public DataTable selsql(string sqlcmd)  //���� ������ DataTable�� ������
    {
        DataTable dt = new DataTable(); //������ ���̺��� ������

        sqlConnect();
        //adapter = new MySqlDataAdapter(sqlcmd, sqlconn);
        //adapter.Fill(dt); //������ ���̺�  ä���ֱ⸦��

        MySqlCommand dbcmd = new MySqlCommand(sqlcmd, sqlconn);
        using (MySqlDataReader reader = dbcmd.ExecuteReader())
        {
            dt.Load(reader);
        }
        sqldisConnect();

        return dt; //������ ���̺��� ������
    }
}
