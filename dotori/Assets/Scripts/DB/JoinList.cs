using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;     //C#의 데이터 테이블 때문에 사용
using MySql.Data;     //MYSQL함수들을 불러오기 위해서 사용
using MySql.Data.MySqlClient;    //클라이언트 기능을사용하기 위해서 사용
using UnityEngine.EventSystems;

public class JoinList : DBConnect
{
    public GameObject buttonPrefab;
    public GameObject content;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
        List();
    }
    void Update()
    {
        
    }
    
    void OnDisable()
    {
        
        Transform[] childList = content.GetComponentsInChildren<Transform>();

        if (childList != null)
        {
            for (int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                    Destroy(childList[i].gameObject);
            }
        }
    }
    public void List()
    {
        
        string loginStudentID = PlayerPrefs.GetString("studentID");

        DataTable dt = new DataTable();
        string query = "select name, studentID from club_t where club_no in (select club_no from account_t where studentID = " + loginStudentID + " and club_cap = 1);";//원래는 동아리별 조사이기 때문에 동아리 코드도 where절에 담아야 함
        dt = selsql(query);

        


        if (dt.Rows.Count > 0)
        {
            int i = -30;
            int j = 1;
            foreach (DataRow row in dt.Rows)
            {
                string name = row[0].ToString();
                string studentID = row[1].ToString();

                Vector3 position = new Vector3(0, i, 0);

                GameObject listbtn = Instantiate(buttonPrefab);
                listbtn.transform.SetParent(GameObject.Find("Content").transform);

                Debug.Log(i);
                RectTransform rc = listbtn.GetComponent<RectTransform>();
                rc.localPosition = position;

                listbtn.name = "listbtn" + j.ToString();

                PrefabName pn = listbtn.GetComponent<PrefabName>();
                pn.Change(name, studentID);


                i -= 50;
                j += 1;
            }
        }
        else
        {
            Debug.Log("동아리 신청이 없습니다.");
        }
    }
}
