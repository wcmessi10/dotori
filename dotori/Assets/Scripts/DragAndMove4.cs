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
        camera = GameObject.Find("�ٹ̱�ī�޶�").GetComponent<Camera>();

        // ���콺 ���� ��ư�� Ŭ���Ǿ��� �� ȣ��˴ϴ�.
        // ���콺 ��ġ�� �����ɴϴ�.
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = camera.ScreenPointToRay(mousePosition);

        
        // ����ĳ��Ʈ�� ����Ͽ� �浹�� üũ�մϴ�.
        int layerMask = 1 << LayerMask.NameToLayer("Stage");
        if (Physics.Raycast(ray, out hit, layerMask))
        {
            Collider hitCollider = hit.collider;
            // �ڽ� ������Ʈ�� �ִ� Collider���� �浹 ���θ� üũ�մϴ�.
            if (hitCollider.transform.IsChildOf(transform))
            {
                float y = this.transform.position.y; /* ���� ���� */
                this.transform.position = new Vector3(hit.point.x, y, hit.point.z);
            }
        }

    }
}

