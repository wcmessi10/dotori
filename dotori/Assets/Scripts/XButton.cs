using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XButton : MonoBehaviour
{
    public GameObject popUp;// 팝업창(canvas)
    public GameObject player;//플레이어
    SimplePlayerController moving;
    public void OnMouseDown()
    {
        moving = player.GetComponent<SimplePlayerController>();
        popUp.SetActive(false);
        moving.enabled = true;
    }
}
