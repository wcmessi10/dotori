using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset;

    private void OnMouseDown()
    {
        // ���콺 ��ġ�� ������Ʈ�� ��ġ ���� �������� ����մϴ�.
        offset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        // ���콺 ��ġ�� �������� ���ο� ��ġ�� ����մϴ�.
        Vector3 newPosition = GetMouseWorldPosition() + offset;

        // x���� �������� �����մϴ�.
        newPosition.x = transform.position.x;

        // ������Ʈ�� ���ο� ��ġ�� �̵��մϴ�.
        transform.position = newPosition;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}

