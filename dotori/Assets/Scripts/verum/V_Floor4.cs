using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class V_Floor4 : MonoBehaviour
{
    public string Corridor;
    public Button Button4; 
  

    private void Start()
    {
      
        Button4 = GetComponent<Button>();
        
        Button4.onClick.AddListener(OnClickButton4);
    }



    private void OnClickButton4()
    {
        SceneManager.LoadScene("Corridor"); 

    }

   
    }