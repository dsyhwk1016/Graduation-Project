using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{ 
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
        spriteRenderer = GetComponent<SpriteRenderer>();//

        if (spriteRenderer == null)
        {
            Debug.LogError("You need to SpriteRenderer for Block");
        }
    }
}
   