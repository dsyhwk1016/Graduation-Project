using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
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
        // 기준 위치 및 크기 지정
        float xPos = 8.5f;  // 보드의 x좌표
        float yPos = 3.25f; // 보드의 y좌표
        Vector2 prePos = new Vector2(0, 1); // 프리뷰 위치
        Vector2 boardScale = new Vector2((boardWidth / 2f), boardHeight / 2f);  // 보드 크기
        Vector2 preScale = new Vector2(3, 3);   // 프리뷰 크기

        // 백그라운드 및 라인 생성
        CreateBoard(new Vector2(0, yPos), new Vector2(Screen.width, boardHeight / 2f + 0.2f), lineColor);
        CreateBoard(new Vector2(0, yPos), new Vector2(Screen.width, boardHeight / 2f), backgroundColor);

        // 라인 생성
        CreateBoard(new Vector2(-1 * xPos, yPos), boardScale + new Vector2(0.2f, 0.2f), lineColor); // 왼쪽 보드 라인
        CreateBoard(new Vector2(xPos, yPos), boardScale + new Vector2(0.2f, 0.2f), lineColor);  // 오른쪽 보드 라인
        CreateBoard(prePos, preScale + new Vector2(0.2f, 0.2f), lineColor); // 프리뷰 라인

        // 보드 생성
        CreateBoard(new Vector2(-1 * xPos, yPos), boardScale, boardColor);  // 왼쪽 게임 보드
        CreateBoard(new Vector2(xPos, yPos), boardScale, boardColor);   // 오른쪽 게임 보드
        CreateBoard(prePos, preScale, boardColor);  // 프리뷰 보드
    }

    void CreateBoard(Vector2 position, Vector2 scale, Color color)
    {
        var go = Instantiate(boardPrefab);   // 프리팹 복제
        go.transform.parent = transform;   // 부모 오브젝트 지정
        go.transform.position = position;  // 오브젝트의 위치 설정
        go.transform.localScale = scale;    // 오브젝트 크기 설정

        go.GetComponent<SpriteRenderer>().color = color; // 색상 지정
    }
}