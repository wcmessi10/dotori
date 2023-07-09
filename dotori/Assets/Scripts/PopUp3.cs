using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;     //C#�� ������ ���̺� ������ ���
using MySql.Data;     //MYSQL�Լ����� �ҷ����� ���ؼ� ���
using MySql.Data.MySqlClient;

public class PopUp3 : DBConnect
{
    SimplePlayerController moving;
    public GameObject popUp;
    public GameObject player;//�÷��̾�
    // Start is called before the first frame update
    void Start()
    {
        
        moving = player.GetComponent<SimplePlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {

        // Ư�� ��ü�� ���콺�� Ŭ������ �� ȣ��Ǵ� �Լ�
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
                    popUp.SetActive(true);
                    moving.enabled = false;
                }

                
            }
        }


    }
}
