using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BlockController는 테트리스의 현재 블록으로 LeftBlock, RightBlock 게임 오브젝트를 제어
public class BlockController : MonoBehaviour
{
    public float tileSize = 0.5f; // 유닛 기준 타일의 크기

    private float fallCycle = 1f;    // 기본 낙하 주기
    private float timeAfterFall;    // 마지막 낙하 후 누적 시간

    void Start()
    {
        // 마지막 낙하 후 누적 시간을 0으로 초기화
        timeAfterFall = 0f;
    }

    void Update()
    {
        // timeAfterFall 갱신
        timeAfterFall += Time.deltaTime;

        // 누적된 시간이 낙하 주기 이상이고 블럭의 y좌표가 -2보다 크면
        if ((timeAfterFall >= fallCycle) && (transform.position.y > -2))
        {
            // 누적된 시간 리셋
            timeAfterFall = 0f;

            // 블록을 타일크기만큼 낙하
            transform.Translate(new Vector2(0, -tileSize));
        }
    }

    // 블록의 좌우 이동 및 회전 함수
    public void Move(bool isRight, bool isRotate)
    {
        // 오른쪽이면(isRight == true) 오른쪽으로 타일크기만큼 이동
        if (isRight) transform.Translate(new Vector2(tileSize, 0));
        // 오른쪽이 아니면(isRight == false) 왼쪽으로 타일크기만큼 이동
        else transform.Translate(new Vector2(-tileSize, 0));

        // 회전이면(isRotate == true) 시계방향으로 90도 회전
        if (isRotate) transform.Rotate(new Vector3(0, 0, 90));
    }

    // 블록 낙하 속도 조절 함수
    public void ChangeSpeed(bool speedUp)
    {
        if (speedUp) fallCycle /= 2;    // 속도 상승
        else fallCycle *= 2;    // 속도 하강
    }
}

