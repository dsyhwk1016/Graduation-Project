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
    // 테트리스 게임 보드의 너비를 4~20으로 제한
    [Range(4, 31)]
    public int boardWidth = 12;
    // 테트리스 게임 보드의 높이를 5~40으로 제한
    [Range(4, 24)]
    public int boardHeight = 20;

    void Start()
    {
        // 왼쪽과 오른쪽 보드의 기준 위치 및 보드 크기 설정
        Vector2 leftPos = new Vector3(-8.25f, 3.25f);
        Vector2 rightPos = new Vector3(8.25f, 3.25f);
        Vector2 boardScale = new Vector3(boardWidth / 2f, boardHeight / 2f);

        // 백그라운드 생성
        CreateBoard(new Vector2(0, 3.25f), new Vector2(Screen.width, boardHeight / 2f), backgroundColor);

        // 보드 생성
        CreateBoard(leftPos, boardScale, boardColor);
        CreateBoard(rightPos, boardScale, boardColor);

        // 라인 생성
        CreateBoard(new Vector2(0, 3.25f + boardHeight / 4f), new Vector2(Screen.width, 0.1f), lineColor);   // Top
        CreateBoard(new Vector2(0, 3.25f - boardHeight / 4f), new Vector2(Screen.width, 0.1f), lineColor);   // Bottom
        CreateBoard(new Vector2(-8.25f - boardWidth / 4f, 3.25f), new Vector2(0.1f, boardHeight / 2f), lineColor);   // L-Left
        CreateBoard(new Vector2(-8.25f + boardWidth / 4f, 3.25f), new Vector2(0.1f, boardHeight / 2f), lineColor);   // L-Right
        CreateBoard(new Vector2(8.25f - boardWidth / 4f, 3.25f), new Vector2(0.1f, boardHeight / 2f), lineColor);   // R-Left
        CreateBoard(new Vector2(8.25f + boardWidth / 4f, 3.25f), new Vector2(0.1f, boardHeight / 2f), lineColor);   // R-Rigt
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