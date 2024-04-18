using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    //자동차의 이동 및 회전에 관련된 데이터 값 설정
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float slowSpeed = 0.5f;
    [SerializeField] float boostSpeed = 20f;
    
    void Update()
    {
        //자동차의 좌우 회전 값
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        //자동차의 앞뒤 이동 값
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount); //자동차 오브젝트의 transform 컴포넌트의 회전 값 변경
        transform.Translate(0, moveAmount, 0); //자동차 오브젝트의 transform 컴포넌트의 앞뒤 이동 값 변경
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed; //장애물 충돌 시 느려짐
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SpeedUp")
        {
            moveSpeed = boostSpeed; //부스터 동그라미에 도달하면 속도 업
        }
    }
}
