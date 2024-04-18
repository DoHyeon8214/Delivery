using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{   
    //��ǰ �Ⱦ��� �ڵ��� ���� ��޿Ϸ�� �ڵ��� ���� �����ϱ� ���� ������
    //����Ƽ ȭ�鿡�� �÷����� ���� �����ϱ� ���� �߰� 
    [SerializeField] Color32 hasPackgeColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackgeColor = new Color32(1, 1, 1, 1);
    
    //��ǰ �Ⱦ� �ȵ� ���� ��
    bool hasPackage = false;
    //�ڵ����� SpriteRenderer ������Ʈ�� ��ũ��Ʈ�� �����ϱ� ���� ���� ����
    SpriteRenderer spriteRenderer;
    void Start()
    {
        //������ ���۵Ǹ� �ڵ��� ������Ʈ�� SpriteRenderer ������Ʈ�� �ҷ��� 
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�浹��");    
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //�ʿ� �ִ� ��ǰ�� �Ⱦ� ���� �� ���� �ڵ�
        if(collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("��ǰ�Ⱦ�!");
            hasPackage = true;
            spriteRenderer.color = hasPackgeColor; //�ڵ��� �� ����
            Destroy(collision.gameObject, 0.5f); //�Ⱦ� �� �ش� ��ǰ�� ȭ�鿡�� ������� ó��
        }
        if(collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("������ ��޿Ϸ�!");
            hasPackage = false;
            spriteRenderer.color = noPackgeColor; // ������ ��� �Ϸ� �� �ڵ��� �� ����
        }
    }
}
