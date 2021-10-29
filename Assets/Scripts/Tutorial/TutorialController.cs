using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 리듬 게임 버튼 오브젝트로서, 노트 클리어 판정
public class TutorialController : MonoBehaviour
{
    public Sprite[] btnSprite;  // 스프라이트 이미지 배열

    private string collisionTag;    // 충돌한 오브젝트의 태그명
    private SpriteRenderer spriteRenderer;  // 사용할 스프라이트 렌더러 컴포넌트 변수
    private RhythmRule rhythmRule;

    void Start()
    { 
        // 사용할 컴포넌트를 가져와 변수에 할당
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rhythmRule = GameObject.Find("Judge Line").GetComponent<RhythmRule>();
    }

    // 버튼 On
    void OnTriggerEnter2D(Collider2D collision)
    {
        collisionTag = collision.gameObject.tag;    // 충돌한 객체의 태그명 가져오기

        if (collisionTag == "Player")
        {
            // 일정 거리 이상 내려왔을 때
            if (GameObject.Find("Note").transform.GetChild(0).position.y < 2)
            {
                rhythmRule.noteIn = true;   // true로 설정

                // 본인의 태그와 판정라인 충돌체의 태그가 같지않다면
                if (gameObject.tag != rhythmRule.collisionTag)
                    TutorialGameManager.instance.HeartDown();   // 생명 감소

                Destroy(GameObject.Find("Note").transform.GetChild(0).gameObject); // 해당 노트 삭제
            }
            spriteRenderer.sprite = btnSprite[0];   // 스프라이트 이미지 변경
        }
    }

    // 버튼 Off
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            spriteRenderer.sprite = btnSprite[1];   // 스프라이트 이미지 변경
    }
}