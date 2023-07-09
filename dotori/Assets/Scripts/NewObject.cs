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
        // 회전 값 설정
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        Vector3 position = new Vector3(x, y, z);
        // clone 변수에 Instantiate를 생성하여 할당
        // 방금 생성된 복제 정보 받아서 설정
        GameObject clone = Instantiate(boxPrefab, position, rotation);
        //clone.transform.SetParent(transform);
        Transform trans = clone.GetComponent<Transform>();
        trans.localScale = new Vector3(scalex, scaley, scalez);

    }
}
