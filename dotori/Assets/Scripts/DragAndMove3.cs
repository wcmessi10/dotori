using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndMove3 : MonoBehaviour
{
    private Camera camera;
    public GameObject gameObject;
    private void OnMouseDrag()
    {
        camera = GameObject.Find("�ٹ̱�ī�޶�").GetComponent<Camera>();
        
        // ���콺 ���� ��ư�� Ŭ���Ǿ��� �� ȣ��˴ϴ�.
        // ���콺 ��ġ�� �����ɴϴ�.
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = camera.ScreenPointToRay(mousePosition);

        RaycastHit hit;
        // ����ĳ��Ʈ�� ����Ͽ� �浹�� üũ�մϴ�.
        int layerMask = 1 << LayerMask.NameToLayer("Stage");
        if (Physics.Raycast(ray, out hit, layerMask))
        {
            Collider hitCollider = hit.collider;
            // �ڽ� ������Ʈ�� �ִ� Collider���� �浹 ���θ� üũ�մϴ�.
            if (hitCollider.transform.IsChildOf(transform))
            {
                if (hit.point.x < -4.99)
                {
                    float z = gameObject.transform.position.z; /* ���� ���� */
                    gameObject.transform.position = new Vector3(hit.point.x, hit.point.y, z);
                }
                else
                {
                    float x = gameObject.transform.position.x; /* ���� ���� */
                    gameObject.transform.position = new Vector3(x, hit.point.y, hit.point.z);
                }
            }
        }
        
    }
}

    