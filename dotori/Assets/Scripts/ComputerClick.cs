using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ComputerClick : MonoBehaviour
{
    public Button xButton; // 닫기 버튼
    public Button Button1; 
    public Button Button2;

    private void Start()
    {
        Button1 = GetComponent<Button>();
        Button2 = GetComponent<Button>();
        xButton = GetComponent<Button>();
        
        Button1.onClick.AddListener(OnClickButton1);
        Button2.onClick.AddListener(OnClickButton2);
        xButton.onClick.AddListener(OnClickxButton);
    }

    private void OnClickButton1()
    {
        SceneManager.LoadScene(""); 
    }

    private void OnClickButton2()
    {

        SceneManager.LoadScene("Room");
    }


private void OnClickxButton()
    {
        SceneManager.LoadScene("Club"); 

    }

    }