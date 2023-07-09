using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System.Data;     //C#�� ������ ���̺� ������ ���
using MySql.Data;     //MYSQL�Լ����� �ҷ����� ���ؼ� ���
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
        
        //InputChat���� ���͸� ������ �� ȣ��Ǵ� �Լ����
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

        //4. inputChat�� ������ �ʱ�ȭ
        inputChat.text = "";

        //5.inputChat�� ���õǵ��� �Ѵ�.
        inputChat.ActivateInputField();

        scrollbar.value = 0f;*/

        
        scrollbar.value = 0f;
        //1.���� ���ٰ� ���͸� ġ��
        //2.ChatItem�� �ϳ� �����.
        //(�θ� ScrollView - Content)
        GameObject item = Instantiate(chatItemFactory, trContent);

        string studentID = PlayerPrefs.GetString("studentID");

        string nick = GetNick(studentID);
        
        //3.text ������Ʈ �����ͼ� inputField�� ������ ����
        Text t = item.GetComponent<Text>();
        t.text = nick + " : " + inputChat.text;

        //4. inputChat�� ������ �ʱ�ȭ
        inputChat.text = "";

        //5.inputChat�� ���õǵ��� �Ѵ�.
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