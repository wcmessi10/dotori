using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;     //C#의 데이터 테이블 때문에 사용
using MySql.Data;     //MYSQL함수들을 불러오기 위해서 사용
using MySql.Data.MySqlClient;    //클라이언트 기능을사용하기 위해서 사용

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
                fail.text += " 학번의 길이를 맞춰주세요";
            }
        }
        else
        {
            if (studentID.Length != 8)
            {
                fail.text += "전화번호를 정확히 입력해주시고, 학번의 길이를 맞춰주세요";
            }
            else {
                fail.text += "전화번호를 정확히 입력해주세요";
            }
        }
        
    }
}
