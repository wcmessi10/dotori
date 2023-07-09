using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VerumFloorClick : MonoBehaviour
{
    public string Lobby;
    public Button xButton; // 닫기 버튼
  

    private void Start()
    {
      
        xButton = GetComponent<Button>();
        
        xButton.onClick.AddListener(OnClickxButton);
    }



    private void OnClickxButton()
    {
        SceneManager.LoadScene("Lobby"); 

    }

   
    }