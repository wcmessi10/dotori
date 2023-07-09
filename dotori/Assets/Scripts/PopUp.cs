using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//어떤 버튼을 누르면 특정 팝업창이 등장하고, 캐릭터는 멈추고

public class PopUp : MonoBehaviour
{
    public GameObject popUp;// 팝업창(canvas)
    public GameObject player;//플레이어
    SimplePlayerController moving; 
    // Start is called before the first frame update
    void Start()
    {
        popUp.SetActive(false);//기본값 canvas는 false
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

        // 특정 물체를 마우스로 클릭했을 때 호출되는 함수
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
