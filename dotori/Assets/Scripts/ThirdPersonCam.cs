using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public float Yaxis;
    public float Xaxis;
    public float cameraXaxis;

    public Transform target;//Player
    public Transform cameratransform;//Camera

    private float rotSensitive = 2f;//ī�޶� ȸ�� ����
    private float dis = 5f;//ī�޶�� �÷��̾������ �Ÿ�
    private float RotationMin = -40f;//ī�޶� ȸ������ �ּ�
    private float RotationMax = 0f;//ī�޶� ȸ������ �ִ�
    
    

    void Start()
    {
        
        cameratransform.position = target.position - cameratransform.forward * dis;
    }

    void Update()
    {
        
    }

    
    void LateUpdate()//Player�� �����̰� �� �� ī�޶� ���󰡾� �ϹǷ� LateUpdate
    {
        if (Input.GetMouseButton(1))//��Ŭ�� ����
        {
            Yaxis = Yaxis + Input.GetAxis("Mouse X") * rotSensitive;//���콺 �¿�������� �Է¹޾Ƽ� ī�޶��� Y���� ȸ����Ų��
            Xaxis = Xaxis - Input.GetAxis("Mouse Y") * rotSensitive;//���콺 ���Ͽ������� �Է¹޾Ƽ� ī�޶��� X���� ȸ����Ų��
            //Xaxis�� ���콺�� �Ʒ��� ������(�������� �Է� �޾�����) ���� �������� ī�޶� �Ʒ��� ȸ���Ѵ� 

            Xaxis = Mathf.Clamp(Xaxis, 0, 0);
            //X�� ����

            Quaternion q = Quaternion.Euler(new Vector3(Xaxis, Yaxis)); // Quaternion���� ��ȯ
            q.z = 0;
            target.transform.rotation = Quaternion.Slerp(target.transform.rotation, q, 2f);

            cameraXaxis = cameraXaxis - Input.GetAxis("Mouse Y") * rotSensitive;
            //cameraYaxis = Mathf.Clamp(cameraYaxis, RotationMin, RotationMax);
            //cameratransform.transform.Rotate(target.position, Input.GetAxis("Mouse Y"));
            cameratransform.eulerAngles = new Vector3(cameraXaxis, Yaxis,0);
            //ī�޶��� ��ġ�� �÷��̾�� ������ ����ŭ �������ְ� ��� ����ȴ�.
        }
    }
}
