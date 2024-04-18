using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    //�ڵ����� �̵� �� ȸ���� ���õ� ������ �� ����
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float slowSpeed = 0.5f;
    [SerializeField] float boostSpeed = 20f;
    
    void Update()
    {
        //�ڵ����� �¿� ȸ�� ��
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        //�ڵ����� �յ� �̵� ��
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount); //�ڵ��� ������Ʈ�� transform ������Ʈ�� ȸ�� �� ����
        transform.Translate(0, moveAmount, 0); //�ڵ��� ������Ʈ�� transform ������Ʈ�� �յ� �̵� �� ����
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed; //��ֹ� �浹 �� ������
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SpeedUp")
        {
            moveSpeed = boostSpeed; //�ν��� ���׶�̿� �����ϸ� �ӵ� ��
        }
    }
}
