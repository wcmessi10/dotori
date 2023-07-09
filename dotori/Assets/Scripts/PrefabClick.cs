using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PrefabClick : MonoBehaviour, IPointerClickHandler
{
    public Text studentID;
    GameObject popUp;
    GameObject popUp2;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("aa");
        PlayerPrefs.SetString("subscriber", studentID.text.ToString());
        popUp = GameObject.Find("동아리리스트");
        popUp2 = GameObject.Find("가입문").transform.Find("가입문배경").gameObject;
        popUp.SetActive(false);
        popUp2.SetActive(true);
        
    }
}
