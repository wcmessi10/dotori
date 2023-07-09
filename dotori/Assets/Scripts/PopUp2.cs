using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;     //C#의 데이터 테이블 때문에 사용
using MySql.Data;     //MYSQL함수들을 불러오기 위해서 사용
using MySql.Data.MySqlClient;


//이건 3D게임오브젝트 버튼을 클릭했을 때
public class PopUp2 : DBConnect
{
    public GameObject popUp;// 팝업창(canvas)
    public GameObject popUp2;
    public GameObject popUp3;
    public GameObject popUp4;
    public GameObject popUp5;
    public GameObject player;//플레이어
    SimplePlayerController moving;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetString("studentID","20161309");
        popUp.SetActive(false);//기본값 canvas는 false
        popUp2.SetActive(false);
        popUp3.SetActive(false);
        popUp4.SetActive(false);
        popUp5.SetActive(false);
        moving = player.GetComponent<SimplePlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {

        // 특정 물체를 마우스로 클릭했을 때 호출되는 함수
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        string studentID = PlayerPrefs.GetString("studentID");
        string query = "select club_cap from account_t where studentID = " + studentID;
        DataTable dt = selsql(query);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log(dt.Rows[0]["club_cap"].ToString());
                if (dt.Rows[0]["club_cap"].ToString().Equals("1"))
                {
                    
                }
                else
                {
                    popUp.SetActive(true);
                    moving.enabled = false;
                }
                
                
            }
        }

        
    }
    
    public void PopUp2Open()
    {
        popUp2.SetActive(false);
        popUp3.SetActive(true);
    }
}
