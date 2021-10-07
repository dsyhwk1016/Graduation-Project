using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerController는 플레이어의 캐릭터로서 Player 게임 오브젝트를 제어
public class PlayerController : MonoBehaviour
{
    [Header("Editor Object")]
    public float speed;   // 이동 속력
    public string charName;    // 캐릭터 이름

    private Rigidbody2D characterRigidbody; // 사용할 리지드바디 컴포넌트 변수
    private Animator animator;  // 사용할 애니메이터 컴포넌트 변수

    void Start()
    {
        // 게임 오브젝트로부터 사용할 컴포넌트를 가져와 변수에 할당
        characterRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 입력을 감지할 축 이름 설정
        string hAxisName = "Horizontal" + charName;
        string vAxisName = "Vertical" + charName;

        // 수평, 수직 축의 입력값을 감지해 저장
        float xInput = Input.GetAxis(hAxisName);
        float yInput = Input.GetAxis(vAxisName);

        // 입력 방향에 따른 애니메이션 파라미터 변경
        animator.SetInteger("GoFront", (int)yInput);
        animator.SetInteger("GoRight", (int)xInput);

        // 축 입력값과 속력을 이용해 Vector2 속도 생성
        Vector2 newVelocity = new Vector2(xInput * speed, yInput * speed);
        // 리지드바디 속도에 newVelocity 할당
        characterRigidbody.velocity = newVelocity;

        //캐릭터가 화면 밖으로 나가지 않도록 월드좌표를 뷰포트로 제한
        Vector3 worldPos = Camera.main.WorldToViewportPoint(transform.position);
        if (worldPos.x < 0.02f) worldPos.x = 0.02f;
        if (worldPos.y < 0.045f) worldPos.y = 0.045f;
        if (worldPos.x > 0.98f) worldPos.x = 0.98f;
        transform.position = Camera.main.ViewportToWorldPoint(worldPos);
    }
}