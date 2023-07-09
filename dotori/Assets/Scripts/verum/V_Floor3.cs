using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class V_Floor3 : MonoBehaviour
{
    public string Corridor;
    public Button Button3; 
  

    private void Start()
    {
      
        Button3 = GetComponent<Button>();
        
        Button3.onClick.AddListener(OnClickButton3);
    }



    private void OnClickButton3()
    {
        SceneManager.LoadScene("Corridor"); 

    }

   
    }