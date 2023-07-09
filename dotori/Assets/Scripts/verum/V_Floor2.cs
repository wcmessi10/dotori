using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class V_Floor2 : MonoBehaviour
{
    public string Corridor;
    public Button Button2; 
  

    private void Start()
    {
      
        Button2 = GetComponent<Button>();
        
        Button2.onClick.AddListener(OnClickButton2);
    }



    private void OnClickButton2()
    {
        SceneManager.LoadScene("Corridor"); 

    }

   
    }