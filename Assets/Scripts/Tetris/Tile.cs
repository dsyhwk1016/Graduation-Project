using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tile은 블록 생성을 위한 프리팹으로, 충돌을 감지하고 색상과 레이어 변경
public class Tile : MonoBehaviour
{
    private string parentName;  // 부모 오브젝트 이름
    private SpriteRenderer spriteRenderer;  // 사용할 스프라이트 렌더러 컴포넌트 변수

    // 오브젝트 생성 후 바로 호출
    private void Awake()
    {
        // SpriteRenderer 컴포넌트를 가져와 변수에 할당
        spriteRenderer = GetComponent<SpriteRenderer>();

        // SpriteRenderer 컴포넌트가 없을 경우 경고 메시지 출력
        if (spriteRenderer == null)
        {
            Debug.LogError("You need to SpriteRenderer for Block");
        }
    }

    void Start()
    {
        // 변수에 부모 오브젝트 이름 할당
        parentName = gameObject.transform.parent.name;
    }

    // 타일의 색상 변경
    public Color color
    {
        set
        {
            spriteRenderer.color = value;   // 색상 할당
        }

        get
        {
            return spriteRenderer.color;    // 색상 반환
        }
    }

    // 스프라이트 표시 순서
    public int sortingOrder
     {
        set
        {
            spriteRenderer.sortingOrder = value;    // 레이어 할당
        }

        get
        {
            return spriteRenderer.sortingOrder; // 레이어 반환
        }
     }
}