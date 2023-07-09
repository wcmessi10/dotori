using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System.Data;     //C#의 데이터 테이블 때문에 사용
using MySql.Data;     //MYSQL함수들을 불러오기 위해서 사용
using MySql.Data.MySqlClient;

public class ChatManager : DBConnect
{
    SimplePlayerController moving;
    public GameObject player;
    public GameObject chatItemFactory;
    public InputField inputChat;
    public Transform trContent;
    public Scrollbar scrollbar;

    void Start()
    {
        moving = player.GetComponent<SimplePlayerController>();
        
        //InputChat에서 엔터를 눌렀을 때 호출되는 함수등록
        inputChat.onSubmit.AddListener(delegate { 
            OnSubmit();
            
        });
        //inputChat.onSubmit.AddListener(OnSubmit);
    }

    void Update()
    {
        if (inputChat.isFocused)
        {
            moving.enabled = false;
        }
        else
        {
            moving.enabled = true;
        }
    }

    void OnSubmit()
    {

        /*photonView.RPC("RpcAddChat", RpcTarget.All, s);

        //4. inputChat의 내용을 초기화
        inputChat.text = "";

        //5.inputChat이 선택되도록 한다.
        inputChat.ActivateInputField();

        scrollbar.value = 0f;*/

        
        scrollbar.value = 0f;
        //1.글을 쓰다가 엔터를 치면
        //2.ChatItem을 하나 만든다.
        //(부모를 ScrollView - Content)
        GameObject item = Instantiate(chatItemFactory, trContent);

        string studentID = PlayerPrefs.GetString("studentID");

        string nick = GetNick(studentID);
        
        //3.text 컴포넌트 가져와서 inputField의 내용을 셋팅
        Text t = item.GetComponent<Text>();
        t.text = nick + " : " + inputChat.text;

        //4. inputChat의 내용을 초기화
        inputChat.text = "";

        //5.inputChat이 선택되도록 한다.
        inputChat.ActivateInputField();

        
    }

    private string GetNick(string studentID)
    {
        string query = "select nickname from account_t where studentID = " + studentID;
        DataTable dt = selsql(query);
        string nick = dt.Rows[0][0].ToString();
        return nick;
    }

}