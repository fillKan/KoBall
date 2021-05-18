using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Trigger : MonoBehaviour
{
    public Rigidbody rigid;
    private Transform m_transform;
    public float power;

    private bool b_isTouch = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        m_transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (b_isTouch)
        {
            m_transform.Translate(new Vector3(0, power * Time.deltaTime, 0));
            b_isTouch = false;
        }
    }

    private void OnCollisionEnter(Collision collision) // 충돌 검사
    {
        if (collision.gameObject.tag == "Player")
        {
            b_isTouch = true;
        }
    }

  //http://theeye.pe.kr/archives/2725

    // 코루틴 :: 일정 시간마다 반복
}
