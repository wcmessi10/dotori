using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObject : MonoBehaviour
{
    public GameObject boxPrefab;
    public float x, y, z;
    public float scalex, scaley, scalez;
    public void NewOne()
    {
        // ȸ�� �� ����
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        Vector3 position = new Vector3(x, y, z);
        // clone ������ Instantiate�� �����Ͽ� �Ҵ�
        // ��� ������ ���� ���� �޾Ƽ� ����
        GameObject clone = Instantiate(boxPrefab, position, rotation);
        //clone.transform.SetParent(transform);
        Transform trans = clone.GetComponent<Transform>();
        trans.localScale = new Vector3(scalex, scaley, scalez);

    }
}
