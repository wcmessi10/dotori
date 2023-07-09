using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndMove2 : MonoBehaviour
{
    private Camera camera;
    RaycastHit hitLayerMask;
    private bool isCtrlPressed = false;
    private bool isShiftPressed = false; // 왼쪽 Shift 키가 눌렸는지 여부
    public GameObject gameObject;
    private Quaternion rotation;
    private Vector3 r1, r2;
    void Start()
    {
        rotation = Quaternion.identity;
        r1 = this.transform.eulerAngles;
        r2 = this.transform.eulerAngles;
        r2.z = r1.z + 90f;
    }
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

        if (ShiftPressed() == true)
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

        int layerMask = 1 << LayerMask.NameToLayer("Stage");
        if (ShiftPressed() == true || CtrlPressed() == true)
        { }
        else
        {
            
            if (Physics.Raycast(ray, out hitLayerMask, Mathf.Infinity, layerMask))
            {
                
                if (hitLayerMask.point.x < -4.99)
                {
                    float x = this.transform.position.x; /* 높이 저장 */
                    this.transform.position = new Vector3(x, hitLayerMask.point.y, hitLayerMask.point.z);
                    rotation.eulerAngles = r1;
                    this.transform.rotation = rotation;
                }
                else
                {
                    float z = this.transform.position.z; /* 높이 저장 */
                    this.transform.position = new Vector3(hitLayerMask.point.x, hitLayerMask.point.y, z);
                    //this.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 270));
                    rotation.eulerAngles = r2;
                    this.transform.rotation = rotation;
                }

            }
        }
        
    }
}