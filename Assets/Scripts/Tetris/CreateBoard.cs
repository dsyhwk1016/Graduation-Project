using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Board 오브젝트로서 테트리스 보드를 생성
// 생성 함수 사용을 위해 AllCreate 클래스 상속
public class CreateBoard : AllCreate
{
    [Header("Editor Object")]
    public GameObject boardPrefab;  // 사용할 프리팹
    // 사용할 색상 설정
    public Color32 lineColor = new Color32(255, 255, 255, 255);
    public Color32 boardColor = new Color32(140, 140, 140, 255);
    public Color32 backgroundColor = new Color32(76, 76, 76, 255);

    [Header("Game Settings")]
    // 테트리스 게임 보드의 너비를 4~26로 제한
    [Range(4, 26)]
    public int boardWidth = 12;
    // 테트리스 게임 보드의 높이를 4~24로 제한
    [Range(4, 24)]
    public int boardHeight = 20;

    void Start()
    {
        float xOffset = 8.5f;   // 보드의 x좌표 오프셋
        
        Vector2 boardPos = new Vector2(0, 0);   // 보드 위치 초기화
        Vector2 prePos = new Vector2(0, -2.25f);    // 프리뷰 위치
        Vector2 boardScale = new Vector2((boardWidth / 2f), boardHeight / 2f);  // 보드 크기
        Vector2 preScale = new Vector2(3, 3);   // 프리뷰 크기

        // 백그라운드 및 라인 생성
        Create(boardPrefab, transform, boardPos, lineColor, new Vector2(Screen.width, boardHeight / 2f + 0.2f), 0);
        Create(boardPrefab, transform, boardPos, backgroundColor, new Vector2(Screen.width, boardHeight / 2f), 0);

        boardPos.x = xOffset;   // 오프셋으로 보드 위치 설정

        // 라인 생성
        Create(boardPrefab, transform, -1 * boardPos, lineColor, boardScale + new Vector2(0.2f, 0.2f), 0); // 왼쪽 보드 라인
        Create(boardPrefab, transform, boardPos, lineColor, boardScale + new Vector2(0.2f, 0.2f), 0);  // 오른쪽 보드 라인
        Create(boardPrefab, transform, prePos, lineColor, preScale + new Vector2(0.2f, 0.2f), 0);  // 프리뷰 라인

        // 보드 생성
        Create(boardPrefab, transform, -1 * boardPos, boardColor, boardScale, 0);  // 왼쪽 게임 보드
        Create(boardPrefab, transform, boardPos, boardColor, boardScale, 0);   // 오른쪽 게임 보드
        Create(boardPrefab, transform, prePos, boardColor, preScale, 0);   // 프리뷰 보드
    }
}