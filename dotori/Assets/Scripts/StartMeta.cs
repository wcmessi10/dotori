using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMeta : MonoBehaviour
{

    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)//�ƹ�Ű�� ������ ��
        {
            SceneManager.LoadScene("Login");
        }

    }

}
