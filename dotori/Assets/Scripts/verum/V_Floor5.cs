using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class V_Floor5: MonoBehaviour
{
    public string Corridor;
    public Button Button5; 
  

    private void Start()
    {
      
        Button5 = GetComponent<Button>();
        
        Button5.onClick.AddListener(OnClickButton5);
    }



    private void OnClickButton5()
    {
        SceneManager.LoadScene("Corridor"); 

    }

   
    }