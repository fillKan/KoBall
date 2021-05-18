using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rigid;
    public float MoveSpeed;

    private bool jump = false;
    private Vector3 vector3;

    private float vertcal;
    private float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        vector3 = new Vector3();
    }

    // Update is called once per frame
    void Update() // 움직이는 방향이 이상해서 출력을 바꿈
    {

        /*
                 수직선 vertcal = Input.GetAxis("VertiCal"); // -1 ~ 1 // !Raw(정수 그거가 아니다) // 소수점(float)의 추가로 자연스러운 프레임 ~
                 horizontal= Input.GetAxis("Horizontal"); // 수평의 // 에디터에서 이미 정의되어 들어옴
                 https://itpangpang.xyz/147
                 Vector3 moveForce = new Vector3(horizontal, 0, vertcal);
                 /// 트랜스 레이트는 오브젝트 기준 좌표계. 월드 행렬이 아니다.
                 /// 에드 포스는 아니다!.
                 모든 객체는 지역 좌표가 있음. 유니티는 그로벌~
                 에드포스는 글로벌 좌표를 기준으로 하여 움직임
                 월드 = 글로벌 좌표계 / 셀프 = 지역 좌표계
        */

        // 트랜스 레이트 :: 오브젝트이 좌표 이동

        // 에드 포스 :: 힘을 준다

        // 타임. 델타 타임 :: 컴퓨터의 성능에 따라 코드의 속도가 다름. 자신의 프레임과 시간을 계산해서 개발자의 의도대로 움직이게 해줌.

        // GetAxis :: 

        if (Input.GetKey(KeyCode.LeftArrow))
        {
             rigid.AddForce(Vector3.right * MoveSpeed );
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid.AddForce(Vector3.left * MoveSpeed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigid.AddForce(Vector3.back * MoveSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigid.AddForce(Vector3.forward * MoveSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jump == false)
        {
            rigid.AddForce(Vector3.up * MoveSpeed, ForceMode.Impulse);
            jump = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        jump = false;
    }
    private void OnCollisionExit(Collision collision)
    {
        jump = true;
    }

}
