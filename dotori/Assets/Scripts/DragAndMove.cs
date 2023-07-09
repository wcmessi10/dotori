using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragAndMove : MonoBehaviour
{
    RaycastHit hitLayerMask;
    private Camera camera;
    private float doubleClickTimeThreshold = 0.5f; // 더블클릭 감지 시간 임계값 (초)
    private float lastClickTime = 0.5f; // 마지막 클릭 시간
    private bool isCtrlPressed = false;
    private bool isShiftPressed = false; // 왼쪽 Shift 키가 눌렸는지 여부
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
            
            // 더블클릭 감지됨
            transform.Rotate(Vector3.forward, 90f); // 오브젝트를 Y축을 기준으로 rotationSpeed만큼 회전
                
            
        }
        else if (CtrlPressed() == true)
        {
            Destroy(gameObject);
        }


    }
    

    private void OnMouseDrag()
    {
        camera = GameObject.Find("꾸미기카메라").GetComponent<Camera>();
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

        int layerMask = 1 << LayerMask.NameToLayer("Stage"); /* 특정 layer 검출 */
        if (ShiftPressed()==true||CtrlPressed()==true)
        { }
        else
        {
            if (Physics.Raycast(ray, out hitLayerMask, Mathf.Infinity, layerMask))
            {
                float y = this.transform.position.y; /* 높이 저장 */
                this.transform.position = new Vector3(hitLayerMask.point.x, y, hitLayerMask.point.z);
            }
        }
            
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, 90f); // 오브젝트를 Y축을 기준으로 rotationSpeed만큼 회전
    }
}