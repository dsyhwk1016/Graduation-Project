using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnController : MonoBehaviour
{
    public SpriteRenderer spriterenderer;
    public Sprite[] newsprite;

    void Start()
    {
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)//블록 함수 호출
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)//버튼 On
    {
        if (collision.gameObject.tag == "Player")
        {
            ButtonOn();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)//버튼 Off
    {
        if (collision.gameObject.tag == "Player")
            ButtonOut();
    }
    void ButtonOn()//충돌 발생시 오브젝트 이미지 변경
     {
        spriterenderer.sprite = newsprite[0];
    }
    void ButtonOut()//충돌 발생시 오브젝트 이미지 변경
    {
        spriterenderer.sprite = newsprite[1];
    }
}
