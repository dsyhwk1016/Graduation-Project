using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private string parentName;  // 부모 오브젝트 이름

    void Start()
    {
        parentName = gameObject.transform.parent.name;  // 변수에 부모 오브젝트 이름 할당
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Finish 게임 오브젝트와 충돌하면
        if (collision.gameObject.name == "Finish")
            // BlockController의 isFinish 값 변경
            GameObject.Find(parentName).GetComponent<BlockController>().isFinish = true;
    }

    public Color color//타일의 색상 변경
    {
        set
        {
            spriteRenderer.color = value;
        }

        get
        {
            return spriteRenderer.color;
        }
    }

    public int sortingOrder//스프라이트 표시 순서
     {
        set
        {
            spriteRenderer.sortingOrder = value;
        }

        get
        {
            return spriteRenderer.sortingOrder;
        }
     }
    SpriteRenderer spriteRenderer;

    private void Awake()//오브젝트 생성후 바로 호출
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("You need to SpriteRenderer for Block");
        }
    }
}
   