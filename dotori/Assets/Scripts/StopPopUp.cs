using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPopUp : MonoBehaviour
{
    SimplePlayerController moving;
    public GameObject popUp;
    public GameObject popUp2;
    public GameObject popUp3;
    public GameObject popUp4;
    public GameObject player;//플레이어
    // Start is called before the first frame update
    void Start()
    {
        popUp.SetActive(false);//기본값 canvas는 false
        popUp2.SetActive(false);
        popUp3.SetActive(false);
        popUp4.SetActive(false);
        moving = player.GetComponent<SimplePlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
