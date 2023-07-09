using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;     //C#�� ������ ���̺� ������ ���
using MySql.Data;     //MYSQL�Լ����� �ҷ����� ���ؼ� ���
using MySql.Data.MySqlClient;


//�̰� 3D���ӿ�����Ʈ ��ư�� Ŭ������ ��
public class PopUp2 : DBConnect
{
    public GameObject popUp;// �˾�â(canvas)
    public GameObject popUp2;
    public GameObject popUp3;
    public GameObject popUp4;
    public GameObject popUp5;
    public GameObject player;//�÷��̾�
    SimplePlayerController moving;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetString("studentID","20161309");
        popUp.SetActive(false);//�⺻�� canvas�� false
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
