using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Edit -> Project Settings -> Input Manager -> Horizontal, Vertical -> Positive, Negative Button
public class SimplePlayerController : MonoBehaviour
{
    private CharacterController mCharacterController;
    public float jumpSpeed;
    public float gravity;
    public float speed;
    private Vector3 MoveDir;

    public Transform player;
    private float x;
    private float y;
    private float z;

    void Start()
    {
        x = PlayerPrefs.GetFloat("x");
        y = PlayerPrefs.GetFloat("y");
        z = PlayerPrefs.GetFloat("z");
        player.position = new Vector3(x, y, z);
        PlayerPrefs.DeleteKey("x");
        PlayerPrefs.DeleteKey("y");
        PlayerPrefs.DeleteKey("z");
    }

    private void Awake()
    {
        speed = 6.0f;
        jumpSpeed = 8.0f;
        gravity = 20.0f;
        MoveDir = Vector3.zero;
        mCharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        MoveDir.y -= gravity * Time.deltaTime;
        mCharacterController.Move(MoveDir * Time.deltaTime);
            
    }
    void move()
    {
        if (mCharacterController.isGrounded)
        {
            // 위, 아래 움직임 셋팅. 
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            // 벡터를 로컬 좌표계 기준에서 월드 좌표계 기준으로 변환한다.
            MoveDir = transform.TransformDirection(MoveDir);

            // 스피드 증가.
            MoveDir *= speed;

            // 캐릭터 점프
            if (Input.GetButton("Jump"))
                MoveDir.y = jumpSpeed;

        }
    }
}
