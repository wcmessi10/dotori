using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRoom : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public GameObject player;
    public GameObject popUp;
    public GameObject popUp2;
    public GameObject canvas;
    public GameObject doorleaf;
    private ChangeScene cs;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    // Start is called before the first frame update

    void Start()
    {
         cs = doorleaf.GetComponent<ChangeScene>();
    }


    public void makeRoom()
    {
        cs.enabled = false;
        ActivateCamera2();
        popUp.SetActive(true);
        canvas.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        popUp2.SetActive(false);
        player.SetActive(false);
    }

    public void Back()
    {
        ActivateCamera1();
        canvas.SetActive(true);
        player.SetActive(true);
        popUp2.SetActive(true);
        popUp.SetActive(false);
        cs.enabled = true;
    }
    void ActivateCamera1()
    {
        camera1.enabled = true;
        camera2.enabled = false;
    }

    // 두 번째 카메라를 활성화하고 첫 번째 카메라를 비활성화
    void ActivateCamera2()
    {
        camera1.enabled = false;
        camera2.enabled = true;
    }
    
}
