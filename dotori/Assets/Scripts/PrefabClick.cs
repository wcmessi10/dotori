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
        popUp = GameObject.Find("���Ƹ�����Ʈ");
        popUp2 = GameObject.Find("���Թ�").transform.Find("���Թ����").gameObject;
        popUp.SetActive(false);
        popUp2.SetActive(true);
        
    }
}
