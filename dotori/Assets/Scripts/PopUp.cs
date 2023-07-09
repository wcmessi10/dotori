using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//� ��ư�� ������ Ư�� �˾�â�� �����ϰ�, ĳ���ʹ� ���߰�

public class PopUp : MonoBehaviour
{
    public GameObject popUp;// �˾�â(canvas)
    public GameObject player;//�÷��̾�
    SimplePlayerController moving; 
    // Start is called before the first frame update
    void Start()
    {
        popUp.SetActive(false);//�⺻�� canvas�� false
        moving = player.GetComponent<SimplePlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
        }
    }
    public void OnMouseDown()
    {

        // Ư�� ��ü�� ���콺�� Ŭ������ �� ȣ��Ǵ� �Լ�
        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                popUp.SetActive(true);
                moving.enabled = false;
            }
        }*/

        popUp.SetActive(true);
        moving.enabled = false;
    }
}
