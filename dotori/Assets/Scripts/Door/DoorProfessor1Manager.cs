using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorProfessor1Manager : MonoBehaviour
{
    public string Professor1; // 이동할 씬의 이름을 저장할 변수

    private void OnMouseDown()
    {
        
        // 특정 물체를 마우스로 클릭했을 때 호출되는 함수
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log("문이 클릭됨");
                 SceneManager.LoadScene("Professor1"); 
            }
        }
    }
    
}
