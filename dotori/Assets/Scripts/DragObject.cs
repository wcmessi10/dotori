using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset;

    private void OnMouseDown()
    {
        // 마우스 위치와 오브젝트의 위치 간의 오프셋을 계산합니다.
        offset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        // 마우스 위치를 기준으로 새로운 위치를 계산합니다.
        Vector3 newPosition = GetMouseWorldPosition() + offset;

        // x축의 움직임을 고정합니다.
        newPosition.x = transform.position.x;

        // 오브젝트를 새로운 위치로 이동합니다.
        transform.position = newPosition;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}

