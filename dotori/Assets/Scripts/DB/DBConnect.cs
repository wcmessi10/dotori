using System.Data;     //C#의 데이터 테이블 때문에 사용
using MySql.Data;     //MYSQL함수들을 불러오기 위해서 사용
using MySql.Data.MySqlClient;    //클라이언트 기능을사용하기 위해서 사용
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
        //DB정보 입력
        string sqlDatabase = "Server=" + sqlDBip + ";Database=" + sqlDBname + ";UserId=" + sqlDBid + ";Password=" + sqlDBpw + ";Port="+port +"";
        //string sqlDatabase = "Server=" + sqlDBip + ";Database=" + sqlDBname + ";UserId=" + sqlDBid + ";Password=" + sqlDBpw + ";";
        //접속 확인하기
        try
        {
            sqlconn = new MySqlConnection(sqlDatabase);
            sqlconn.Open();
            Debug.Log("SQL의 접속 상태 : " + sqlconn.State); //접속이 되면 OPEN이라고 나타남
        }
        catch (Exception msg)
        {
            Debug.Log(msg); //기타다른오류가 나타나면 오류에 대한 내용이 나타남
        }
    }

    void sqldisConnect()
    { 
        sqlconn.Close();
        Debug.Log("SQL의 접속 상태 : " + sqlconn.State); //접속이 끊기면 Close가 나타남 
    }

    public void sqlcmdall(string allcmd) //함수를 불러올때 명령어에 대한 String을 인자로 받아옴
    {
        sqlConnect(); //접속
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
        MySqlCommand dbcmd = new MySqlCommand(allcmd, sqlconn); //명령어를 커맨드에 입력
        dbcmd.Transaction = transaction;
        dbcmd.ExecuteNonQuery(); //명령어를 SQL에 보냄
        //dbcmd = new MySqlCommand("COMMIT", sqlconn);
        transaction.Commit();
        sqldisConnect(); //접속해제*/
        sqldisConnect();
    }

    public DataTable selsql(string sqlcmd)  //리턴 형식을 DataTable로 선언함
    {
        DataTable dt = new DataTable(); //데이터 테이블을 선언함

        sqlConnect();
        //adapter = new MySqlDataAdapter(sqlcmd, sqlconn);
        //adapter.Fill(dt); //데이터 테이블에  채워넣기를함

        MySqlCommand dbcmd = new MySqlCommand(sqlcmd, sqlconn);
        using (MySqlDataReader reader = dbcmd.ExecuteReader())
        {
            dt.Load(reader);
        }
        sqldisConnect();

        return dt; //데이터 테이블을 리턴함
    }
}
