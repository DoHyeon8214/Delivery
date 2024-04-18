using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{   
    //물품 픽업시 자동차 색과 배달완료시 자동차 색을 변경하기 위한 데이터
    //유니티 화면에서 컬러값을 직접 설정하기 위해 추가 
    [SerializeField] Color32 hasPackgeColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackgeColor = new Color32(1, 1, 1, 1);
    
    //물품 픽업 안된 상태 값
    bool hasPackage = false;
    //자동차의 SpriteRenderer 컴포넌트를 스크립트로 제어하기 위해 변수 설정
    SpriteRenderer spriteRenderer;
    void Start()
    {
        //게임이 시작되면 자동차 오브젝트의 SpriteRenderer 컴포넌트를 불러옴 
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌됨");    
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //맵에 있는 물품을 픽업 했을 시 동작 코드
        if(collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("물품픽업!");
            hasPackage = true;
            spriteRenderer.color = hasPackgeColor; //자동차 색 변경
            Destroy(collision.gameObject, 0.5f); //픽업 시 해당 물품은 화면에서 사라지게 처리
        }
        if(collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("고객에게 배달완료!");
            hasPackage = false;
            spriteRenderer.color = noPackgeColor; // 고객에게 배달 완료 시 자동차 색 변경
        }
    }
}
