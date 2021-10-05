using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BlockController는 테트리스의 현재 블록으로 LeftBlock, RightBlock 게임 오브젝트를 제어
public class BlockController : MonoBehaviour
{
    [Header("Editor Object")]
    public float tileSize = 0.5f; // 유닛 기준 타일의 크기
    public float changeFallCycle = 0.5f;    // 아래버튼에 의한 하강 주기

    private bool isFinish = false;   // 종료지점에 닿았는지 여부
    private float moveCycle = 1.5f;    // 기본 낙하 주기
    private float timeAfterFall;    // 마지막 낙하 후 누적 시간

    void Start()
    {
        // 누적 시간 초기화
        timeAfterFall = 0f;
    }

    void Update()
    {
        // timeAfterFall 갱신
        timeAfterFall += Time.deltaTime;

        // 누적된 시간이 낙하 주기 이상이고 finish가 아니면
        if ((timeAfterFall >= moveCycle) && !isFinish)
        {
            // 누적된 시간 리셋
            timeAfterFall = 0f;

            // 블록을 타일크기만큼 하강
            transform.position += new Vector3(0, -tileSize, 0);
        }
    }

    // 블록의 좌우 이동 및 회전 함수
    public void Move(int xDirection, bool isRotate)
    {
        // Finish라인에 닿지 않았을 때만 동작
        if (!isFinish)
        {
            if (xDirection > 0) xDirection = 1; // x축 값이 양수면 1로 설정
            else if (xDirection < 0) xDirection = -1;   // x축 값이 음수면 -1로 설정

            // 입력된 x축 방향으로 타일 크기만큼 이동
            transform.position += new Vector3(xDirection * tileSize, 0, 0);

            // 회전이면(isRotate == true) 시계방향으로 90도 회전
            if (isRotate) transform.Rotate(new Vector3(0, 0, 90));
        }
    }

    // 블록 낙하 속도 조절 함수
    public void ChangeSpeed(bool speedUp)
    {
        if (speedUp) moveCycle = changeFallCycle;    // 속도 상승
        else moveCycle = 1.5f;    // 속도 하강
    }

    public bool IsFinish
    {
        set
        {
            isFinish = value;    // isFinish 할당
        }

        get
        {
            return isFinish; // isFinish 반환
        }
    }
}

