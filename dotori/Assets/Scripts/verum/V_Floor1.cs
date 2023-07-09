using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class V_Floor1 : MonoBehaviour
{
    public string Corridor;
    public Button Button1; 
  

    private void Start()
    {
      
        Button1 = GetComponent<Button>();
        
        Button1.onClick.AddListener(OnClickButton1);
    }



    private void OnClickButton1()
    {
        SceneManager.LoadScene("Corridor"); 

    }

   
    }