using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 리듬 게임 버튼 오브젝트로서, 노트 클리어 판정
public class TutorialController : MonoBehaviour
{
    public Sprite[] btnSprite;  // 스프라이트 이미지 배열

    private bool onButton = false;  // 버튼 on 여부
    private string collisionTag;    // 충돌한 오브젝트의 태그명
    private float cycle = 1.5f; // 함수 호출 주기
    private float timeAfterMove;    // 마지막 호출 후 누적 시간
    private SpriteRenderer spriteRenderer;  // 사용할 스프라이트 렌더러 컴포넌트 변수
    private RhythmRule rhythmRule;

    void Start()
    { 
        // 사용할 컴포넌트를 가져와 변수에 할당
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rhythmRule = GameObject.Find("Judge Line").GetComponent<RhythmRule>();
    }

    // 일정 시간 간격으로 버튼 동작
    void Update()
    {
        if (onButton)   // 버튼이 on 상태이면
        {
            timeAfterMove += Time.deltaTime;    // 누적 시간 갱신

            // 누적 시간이 주기 이상이고 일정 거리 이상 내려왔을 때
            if (timeAfterMove >= cycle && GameObject.Find("Note").transform.GetChild(0).position.y < 2)
            {
                timeAfterMove = 0f; // 누적 시간 초기화

                rhythmRule.noteIn = true;   // true로 설정

                // 본인의 태그와 판정라인 충돌체의 태그가 같지않다면
                if (gameObject.tag != rhythmRule.collisionTag)
                    TutorialGameManager.instance.HeartDown();   // 생명 감소

                Destroy(GameObject.Find("Note").transform.GetChild(0).gameObject); // 해당 노트 삭제
            }
        }
    }

    // 버튼 On
    void OnTriggerEnter2D(Collider2D collision)
    {
        collisionTag = collision.gameObject.tag;    // 충돌한 객체의 태그명 가져오기

        if (collisionTag == "Player")
        {
            onButton = true;    // 버튼 on
            timeAfterMove = cycle;  // 누적 시간을 주기로 초기화
            spriteRenderer.sprite = btnSprite[0];   // 스프라이트 이미지 변경
        }
    }

    // 버튼 Off
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            onButton = false;   // 버튼 off
            spriteRenderer.sprite = btnSprite[1];   // 스프라이트 이미지 변경
        }
    }
}