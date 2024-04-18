using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //외부에 있는 자동차 요소를 불러오기 위해 추가
    [SerializeField] GameObject thingsFollow;

    void LateUpdate()
    {
        //카메라의 위치 값을 자동차가 이동하는 위치와 동일하게 설정함
        transform.position = thingsFollow.transform.position + new Vector3(0, 0, -12);
    }
}
