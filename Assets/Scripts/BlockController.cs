using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BlockController는 테트리스의 현재 블록으로 LeftBlock, RightBlock 게임 오브젝트를 제어
public class BlockController : MonoBehaviour
{
    [Header("Editor Object")]
    public float tileSize = 0.5f; // 유닛 기준 타일의 크기
    public float changeFallCycle = 0.5f;    // 아래버튼에 의한 하강 주기
    public Transform stopObject;  // 착지 시 이동할 오브젝트

    private bool isFinish = false;   // 착지했는지 여부
    private bool xMove = false;  // 좌우 이동 여부
    private float moveCycle = 1.5f;    // 기본 낙하 주기
    private float timeAfterFall;    // 마지막 낙하 후 누적 시간
    private Tetris tetrisScript;    // 사용할 Tetris 컴포넌트

    void Start()
    {
        timeAfterFall = 0f; // 누적 시간 초기화
        // Tetris 컴포넌트를 갖고있는 오브젝트를 찾아 Tetris 컴포넌트 할당
        tetrisScript = GameObject.FindObjectOfType<Tetris>().GetComponent<Tetris>();
    }

    void Update()
    {
        // timeAfterFall 갱신
        timeAfterFall += Time.deltaTime;

        xMove = false;  // xMove 초기화

        // 오브젝트의 현재 위치, 회전 값 저장 
        Vector3 oldPos = transform.position;
        Quaternion oldRot = transform.rotation;

        // 누적된 시간이 낙하 주기 이상이고 착지 전이면
        if ((timeAfterFall >= moveCycle) && !isFinish)
        {
            // 누적된 시간 리셋
            timeAfterFall = 0f;

            // 블록을 타일크기만큼 하강
            transform.position += new Vector3(0, -tileSize, 0);

            // 1칸 하강할 때마다 19점 추가
            GameManager.instance.AddScore(19);

            // 이동 불가 시 이전 위치, 회전으로 돌아가기
            if (!CanMove())
            {
                transform.position = oldPos;
                transform.rotation = oldRot;

                GameManager.instance.AddScore(-19); // 추가된 점수 취소
            }
        }
        else if (isFinish)  // 블록이 착지했으면
        {
            // 현재 오브젝트의 자식 오브젝트를 모두
            foreach (Transform child in transform)
            {
                if(child.position.y >= 8)   // 데드라인을 넘었으면
                {
                    GameManager.instance.OnGameOver();
                    break;
                }

                child.parent = stopObject;    // 착지 오브젝트의 자식으로 이동
                child.name = child.position.ToString(); // 이름을 좌표값으로 설정
            }

            Invoke("NewBlockCreate", 0.1f); // 0.1초 뒤 NewBlockCreate 함수 호출
        }
    }

    // 블록의 좌우 이동 및 회전 함수
    public void Move(int xDirection, bool isRotate)
    {
        // 착지하지 않았을 때만 동작
        if (!isFinish)
        {
            if (xDirection > 0) xDirection = 1; // x축 값이 양수면 1로 설정
            else if (xDirection < 0) xDirection = -1;   // x축 값이 음수면 -1로 설정

            // xDirection이 0이 아니면 x축 움직임 true
            if (xDirection != 0) xMove = true;

            // 오브젝트의 현재 위치, 회전 값 저장 
            Vector3 oldPos = transform.position;
            Quaternion oldRot = transform.rotation;

            // 입력된 x축 방향으로 타일 크기만큼 이동
            transform.position += new Vector3(xDirection * tileSize, 0, 0);

            // 회전이면(isRotate == true) 시계방향으로 90도 회전
            if (isRotate) transform.Rotate(new Vector3(0, 0, 90));

            // 이동 불가 시 이전 위치, 회전으로 돌아가기
            if (!CanMove())
            {
                transform.position = oldPos;
                transform.rotation = oldRot;
            }
        }
    }

    // 블록 낙하 속도 조절 함수
    public void ChangeSpeed(bool speedUp)
    {
        if (speedUp) moveCycle = changeFallCycle;    // 속도 상승
        else moveCycle = 1.5f;    // 속도 하강
    }

    void NewBlockCreate()
    {
        // 새 블록 생성
        if (gameObject.name == "LeftBlock")
            tetrisScript.CreateBlock(gameObject.transform, new Vector2(-8, 7.5f));
        else if (gameObject.name == "RightBlock")
            tetrisScript.CreateBlock(gameObject.transform, new Vector2(8, 7.5f));
        else Debug.LogWarning("없는 오브젝트 입니다.");

        if (!CanMove())
        {
            transform.position += new Vector3(0, 0.5f, 0);
        }

        // 착지할 때마다 267점 추가
        GameManager.instance.AddScore(267);

        isFinish = false;   // 착지 여부 초기화

        CancelInvoke("NewBlockCreate"); // 반복되고 있는 Invoke 취소
    }

    // 이동 가능 여부 확인. 가능하면 true, 불가능하면 false 반환 
    bool CanMove()
    {
        // 블럭의 자식 타일을 모두 검사
        foreach (Transform node in transform)
        {
            // 자식 오브젝트의 x, y값 저장
            float x = node.position.x;
            float y = node.position.y;

            if (gameObject.name == "LeftBlock")
            {
                // 이동 가능한 좌표인지 확인 후 반환
                if (x < -11 || x >-5 )  // 실제 가능 좌표는 -11.25~-5.25
                    return false;
            }

            if (gameObject.name == "RightBlock")
            {
                // 이동 가능한 좌표인지 확인 후 반환
                if (x < 5 || x > 11)    // 실제 가능 좌표는 5.25~11.25
                    return false;
            }

            if (y < -2) // 바닥에 닿았는지 확인
            {
                isFinish = true;    // 착지 설정
                return false;
            }

            // 특정 위치에 타일이 존재하는지 확인
            if (stopObject.Find(node.position.ToString()) != null)
            {
                // x축 움직임이 없을 때만 착지 설정
                isFinish = !xMove;
                return false;
            }
        }
        return true;
    }
}