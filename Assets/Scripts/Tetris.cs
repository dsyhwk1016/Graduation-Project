using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tetris는 랜덤한 블록을 생성
public class Tetris : MonoBehaviour
{
    [Header("Editor Object")]
    public GameObject tilePrefab;   // 타일 프리팹
    public Transform LeftBlock; // 타일이 생성될 왼쪽 부모 오브젝트
    public Transform RightBlock;    // 타일이 생성될 오른쪽 부모 오브젝트

    void Start()
    {
        // BoardController 컴포넌트 가져오기
        BoardController tetrisSize = GameObject.FindObjectOfType<BoardController>().GetComponent<BoardController>();

        // 테트리스 보드 크기에 맞춰 블록 생성 높이 지정
        float blockHeight = tetrisSize.boardHeight / 4f - 0.75f;

        // 랜덤한 테트리스 블록 생성
        CreateBlock(LeftBlock, new Vector2(-8, 3.25f + blockHeight));
        CreateBlock(RightBlock, new Vector2(8, 3.25f + blockHeight));
    }

    // 타일 생성
    Tile CreateTile(Transform parent, Vector2 position, Color color, int order=1)
    {
        var go = Instantiate(tilePrefab);   // 프리팹 복제
        go.transform.parent = parent;   // 부모 오브젝트 지정
        go.transform.localPosition = position;  // 오브젝트의 위치 설정

        var tile = go.GetComponent<Tile>(); // Tile 컴포넌트 할당
        tile.color = color; // 색상 지정
        tile.sortingOrder = order;  // 레이어 순서 지정

        return tile;
    }

    // 랜덤 블록 생성
    public void CreateBlock(Transform parent, Vector2 position)
    {
        int index = Random.Range(0, 7); // 랜덤 변수 생성
        Color32 color = Color.white;    // 색상 초기화

        parent.rotation = Quaternion.identity;   // 블록 방향 초기화
        parent.position = position;    // 블록 생성 위치 지정

        switch(index)
        {
            case 0: // 분홍색(I-Block)
                parent.position += new Vector3(0, 0.5f, 0);    // 위치 조정
                color = new Color32(239, 115, 196, 255);    // 블록 색상 지정
                // 블록 모양에 맞춰 타일 생성
                CreateTile(parent, new Vector2(-1f, 0.0f), color);
                CreateTile(parent, new Vector2(-0.5f, 0.0f), color);
                CreateTile(parent, new Vector2(0f, 0.0f), color);
                CreateTile(parent, new Vector2(0.5f, 0.0f), color);
                break;
                
            case 1: // 주황색(J-Block)
                parent.position -= new Vector3(0, 0.5f, 0);
                color = new Color32(231,151,117, 255);
                CreateTile(parent, new Vector2(-0.5f, 0.0f), color);
                CreateTile(parent, new Vector2(0f, 0.0f), color);
                CreateTile(parent, new Vector2(0f, 0.5f), color);
                CreateTile(parent, new Vector2(0f, 1f), color);
                break;

            case 2: // 노란색(L-Block)
                parent.position -= new Vector3(0, 0.5f, 0);
                color = new Color32(255,236,143, 255);
                CreateTile(parent, new Vector2(0f, 1f), color);
                CreateTile(parent, new Vector2(0f, 0.5f), color);
                CreateTile(parent, new Vector2(0f, 0.0f), color);
                CreateTile(parent, new Vector2(0.5f, 0.0f), color);
                break;

            case 3: // 파란색(O-Block)
                color = new Color32(56,71,232, 255);
                CreateTile(parent, new Vector2(0f, 0.0f), color);
                CreateTile(parent, new Vector2(0.5f, 0.0f), color);
                CreateTile(parent, new Vector2(0f, 0.5f), color);
                CreateTile(parent, new Vector2(0.5f, 0.5f), color);
                break;

            case 4: // 초록색(S-Block)
                color = new Color32(166,241,172, 255);
                CreateTile(parent, new Vector2(-0.5f, 0.0f), color);
                CreateTile(parent, new Vector2(0f, 0.0f), color);
                CreateTile(parent, new Vector2(0f, 0.5f), color);
                CreateTile(parent, new Vector2(0.5f, 0.5f), color);
                break;

            case 5: // 하늘색(T-Block)
                color = new Color32(145,224,244, 255);
                CreateTile(parent, new Vector2(-0.5f, 0.0f), color);
                CreateTile(parent, new Vector2(0f, 0.0f), color);
                CreateTile(parent, new Vector2(0.5f, 0.0f), color);
                CreateTile(parent, new Vector2(0f, 0.5f), color);
                break;

            case 6: // 보라색(Z-Block)
                color = new Color32(132,111,223, 255);
                CreateTile(parent, new Vector2(-0.5f, 0.5f), color);
                CreateTile(parent, new Vector2(0f, 0.5f), color);
                CreateTile(parent, new Vector2(0f, 0.0f), color);
                CreateTile(parent, new Vector2(0.5f, 0.0f), color);
                break;
        }
    }
}