using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndMove4 : MonoBehaviour
{
    private Camera camera;
    RaycastHit hit;

    void Start()
    {
        
    }


    private void OnMouseDrag()
    {
        camera = GameObject.Find("꾸미기카메라").GetComponent<Camera>();

        // 마우스 왼쪽 버튼이 클릭되었을 때 호출됩니다.
        // 마우스 위치를 가져옵니다.
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = camera.ScreenPointToRay(mousePosition);

        
        // 레이캐스트를 사용하여 충돌을 체크합니다.
        int layerMask = 1 << LayerMask.NameToLayer("Stage");
        if (Physics.Raycast(ray, out hit, layerMask))
        {
            Collider hitCollider = hit.collider;
            // 자식 오브젝트에 있는 Collider와의 충돌 여부를 체크합니다.
            if (hitCollider.transform.IsChildOf(transform))
            {
                float y = this.transform.position.y; /* 높이 저장 */
                this.transform.position = new Vector3(hit.point.x, y, hit.point.z);
            }
        }

    }
}

