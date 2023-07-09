using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndMove3 : MonoBehaviour
{
    private Camera camera;
    public GameObject gameObject;
    private void OnMouseDrag()
    {
        camera = GameObject.Find("꾸미기카메라").GetComponent<Camera>();
        
        // 마우스 왼쪽 버튼이 클릭되었을 때 호출됩니다.
        // 마우스 위치를 가져옵니다.
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = camera.ScreenPointToRay(mousePosition);

        RaycastHit hit;
        // 레이캐스트를 사용하여 충돌을 체크합니다.
        int layerMask = 1 << LayerMask.NameToLayer("Stage");
        if (Physics.Raycast(ray, out hit, layerMask))
        {
            Collider hitCollider = hit.collider;
            // 자식 오브젝트에 있는 Collider와의 충돌 여부를 체크합니다.
            if (hitCollider.transform.IsChildOf(transform))
            {
                if (hit.point.x < -4.99)
                {
                    float z = gameObject.transform.position.z; /* 높이 저장 */
                    gameObject.transform.position = new Vector3(hit.point.x, hit.point.y, z);
                }
                else
                {
                    float x = gameObject.transform.position.x; /* 높이 저장 */
                    gameObject.transform.position = new Vector3(x, hit.point.y, hit.point.z);
                }
            }
        }
        
    }
}

    