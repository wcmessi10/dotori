using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XButton : MonoBehaviour
{
    public GameObject popUp;// �˾�â(canvas)
    public GameObject player;//�÷��̾�
    SimplePlayerController moving;
    public void OnMouseDown()
    {
        moving = player.GetComponent<SimplePlayerController>();
        popUp.SetActive(false);
        moving.enabled = true;
    }
}
