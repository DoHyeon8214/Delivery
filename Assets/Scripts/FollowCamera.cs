using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //�ܺο� �ִ� �ڵ��� ��Ҹ� �ҷ����� ���� �߰�
    [SerializeField] GameObject thingsFollow;

    void LateUpdate()
    {
        //ī�޶��� ��ġ ���� �ڵ����� �̵��ϴ� ��ġ�� �����ϰ� ������
        transform.position = thingsFollow.transform.position + new Vector3(0, 0, -12);
    }
}
