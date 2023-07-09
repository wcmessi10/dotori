using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragAndMove : MonoBehaviour
{
    RaycastHit hitLayerMask;
    private Camera camera;
    private float doubleClickTimeThreshold = 0.5f; // ����Ŭ�� ���� �ð� �Ӱ谪 (��)
    private float lastClickTime = 0.5f; // ������ Ŭ�� �ð�
    private bool isCtrlPressed = false;
    private bool isShiftPressed = false; // ���� Shift Ű�� ���ȴ��� ����
    public GameObject gameObject;
    private bool ShiftPressed()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isShiftPressed = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isShiftPressed = false;
        }
        return isShiftPressed;
    }
    private bool CtrlPressed()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCtrlPressed = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCtrlPressed = false;
        }
        return isCtrlPressed;
    }
    void Update()
    {
        ShiftPressed();
        CtrlPressed();
    }

    private void OnMouseDown()
    {

        if (ShiftPressed()==true)
        {
            
            // ����Ŭ�� ������
            transform.Rotate(Vector3.forward, 90f); // ������Ʈ�� Y���� �������� rotationSpeed��ŭ ȸ��
                
            
        }
        else if (CtrlPressed() == true)
        {
            Destroy(gameObject);
        }


    }
    

    private void OnMouseDrag()
    {
        camera = GameObject.Find("�ٹ̱�ī�޶�").GetComponent<Camera>();
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

        int layerMask = 1 << LayerMask.NameToLayer("Stage"); /* Ư�� layer ���� */
        if (ShiftPressed()==true||CtrlPressed()==true)
        { }
        else
        {
            if (Physics.Raycast(ray, out hitLayerMask, Mathf.Infinity, layerMask))
            {
                float y = this.transform.position.y; /* ���� ���� */
                this.transform.position = new Vector3(hitLayerMask.point.x, y, hitLayerMask.point.z);
            }
        }
            
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, 90f); // ������Ʈ�� Y���� �������� rotationSpeed��ŭ ȸ��
    }
}