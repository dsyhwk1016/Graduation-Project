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
    public Transform preview; // 프리뷰 블럭이 생성될 부모 오브젝트

    private int preindex = -1;  // 프리뷰 블럭의 인덱스값
    private int index;  // 기본 블럭의 인덱스값

    void Start()
    {
        // BoardController 컴포넌트 가져오기
        BoardController tetrisSize = GameObject.FindObjectOfType<BoardController>().GetComponent<BoardController>();

        // 테트리스 보드 크기에 맞춰 블록 생성 높이 지정
        float blockHeight = tetrisSize.boardHeight / 4f - 0.75f;

        // 랜덤한 테트리스 블록 생성
        CreateBlock(LeftBlock, new Vector2(-8.25f, 3.25f + blockHeight));
        CreateBlock(RightBlock, new Vector2(8.25f, 3.25f + blockHeight));
    }

    // 타일 생성
    Tile CreateTile(Transform parent, Vector2 position, Color color, int order = 1)
    {
        var go = Instantiate(tilePrefab);   // 프리팹 복제
        go.transform.parent = parent;   // 부모 오브젝트 지정
        go.transform.localPosition = position;  // 오브젝트의 위치 설정

        var tile = go.GetComponent<Tile>(); // Tile 컴포넌트 할당
        tile.color = color; // 색상 지정
        tile.sortingOrder = order;  // 레이어 순서 지정

        return tile;
    }

    // 프리뷰 블록 생성
    public void CreatePreview(Transform parent)
    {
        // 이미 있는 미리보기 삭제하기
        foreach (Transform tile in preview)
        {
            Destroy(tile.gameObject);
        }
        preview.DetachChildren(); // 부모 자식 관계 해제

        preindex = Random.Range(0, 7); // 프리뷰 인덱스 변환 

        Color32 color = Color.white;

        // 미리보기 테트리스 생성 위치 (중앙)
        preview.position = new Vector2(0, 1);

        // 랜덤으로 프리뷰 블록 생성 
        switch (preindex)
        {
            case 0: // 분홍색(I-Block)-완 
                color = new Color32(239, 115, 196, 255);    // 블록 색상 지정
                                                            // 블록 모양에 맞춰 타일 생성
                CreateTile(parent, new Vector2(-0.75f, 0.0f), color);
                CreateTile(parent, new Vector2(-0.25f, 0.0f), color);
                CreateTile(parent, new Vector2(0.25f, 0.0f), color);
                CreateTile(parent, new Vector2(0.75f, 0.0f), color);
                break;

            case 1: // 주황색(J-Block)-완 
                color = new Color32(231, 151, 117, 255);
                CreateTile(parent, new Vector2(-0.25f, -0.5f), color);
                CreateTile(parent, new Vector2(0.25f, -0.5f), color);
                CreateTile(parent, new Vector2(0.25f, 0f), color);
                CreateTile(parent, new Vector2(0.25f, 0.5f), color);
                break;

            case 2: // 노란색(L-Block)-완 
                color = new Color32(255, 236, 143, 255);
                CreateTile(parent, new Vector2(-0.25f, 0.5f), color);
                CreateTile(parent, new Vector2(-0.25f, 0f), color);
                CreateTile(parent, new Vector2(-0.25f, -0.5f), color);
                CreateTile(parent, new Vector2(0.25f, -0.5f), color);
                break;

            case 3: // 파란색(O-Block)
                color = new Color32(56, 71, 232, 255);
                CreateTile(parent, new Vector2(-0.25f, -0.25f), color);
                CreateTile(parent, new Vector2(0.25f, -0.25f), color);
                CreateTile(parent, new Vector2(-0.25f, 0.25f), color);
                CreateTile(parent, new Vector2(0.25f, 0.25f), color);
                break;

            case 4: // 초록색(S-Block)-완 
                color = new Color32(166, 241, 172, 255);
                CreateTile(parent, new Vector2(-0.5f, -0.25f), color);
                CreateTile(parent, new Vector2(0f, -0.25f), color);
                CreateTile(parent, new Vector2(0f, 0.25f), color);
                CreateTile(parent, new Vector2(0.5f, 0.25f), color);
                break;

            case 5: // 하늘색(T-Block)-완 
                color = new Color32(145, 224, 244, 255);
                CreateTile(parent, new Vector2(-0.5f, -0.25f), color);
                CreateTile(parent, new Vector2(0f, -0.25f), color);
                CreateTile(parent, new Vector2(0.5f, -0.25f), color);
                CreateTile(parent, new Vector2(0f, 0.25f), color);
                break;
            case 6: // 보라색(Z-Block)-완 
                color = new Color32(132, 111, 223, 255);
                CreateTile(parent, new Vector2(-0.5f, 0.25f), color);
                CreateTile(parent, new Vector2(0f, 0.25f), color);
                CreateTile(parent, new Vector2(0f, -0.25f), color);
                CreateTile(parent, new Vector2(0.5f, -0.25f), color);
                break;
        }

    }

    // 랜덤 블록 생성
    public void CreateBlock(Transform parent, Vector2 position)
    {
        // 처음 블록 생성 한다면
        if (preindex == -1)
            index = Random.Range(0, 7); // 랜덤으로 0~6 사이의 값 생성

        // 그 이후로 생성한다면 
        else index = preindex;  // preview의 값 가져오기

        Color32 color = Color.white;    // 색상 초기화

        parent.rotation = Quaternion.identity;   // 블록 방향 초기화
        parent.position = position;    // 블록 생성 위치 지정

        switch (index)
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
                color = new Color32(231, 151, 117, 255);
                CreateTile(parent, new Vector2(-0.5f, 0.0f), color);
                CreateTile(parent, new Vector2(0f, 0.0f), color);
                CreateTile(parent, new Vector2(0f, 0.5f), color);
                CreateTile(parent, new Vector2(0f, 1f), color);
                break;

            case 2: // 노란색(L-Block)
                parent.position -= new Vector3(0, 0.5f, 0);
                color = new Color32(255, 236, 143, 255);
                CreateTile(parent, new Vector2(0f, 1f), color);
                CreateTile(parent, new Vector2(0f, 0.5f), color);
                CreateTile(parent, new Vector2(0f, 0.0f), color);
                CreateTile(parent, new Vector2(0.5f, 0.0f), color);
                break;

            case 3: // 파란색(O-Block)
                color = new Color32(56, 71, 232, 255);
                CreateTile(parent, new Vector2(0f, 0.0f), color);
                CreateTile(parent, new Vector2(0.5f, 0.0f), color);
                CreateTile(parent, new Vector2(0f, 0.5f), color);
                CreateTile(parent, new Vector2(0.5f, 0.5f), color);
                break;

            case 4: // 초록색(S-Block)
                color = new Color32(166, 241, 172, 255);
                CreateTile(parent, new Vector2(-0.5f, 0.0f), color);
                CreateTile(parent, new Vector2(0f, 0.0f), color);
                CreateTile(parent, new Vector2(0f, 0.5f), color);
                CreateTile(parent, new Vector2(0.5f, 0.5f), color);
                break;

            case 5: // 하늘색(T-Block)
                color = new Color32(145, 224, 244, 255);
                CreateTile(parent, new Vector2(-0.5f, 0.0f), color);
                CreateTile(parent, new Vector2(0f, 0.0f), color);
                CreateTile(parent, new Vector2(0.5f, 0.0f), color);
                CreateTile(parent, new Vector2(0f, 0.5f), color);
                break;

            case 6: // 보라색(Z-Block)
                color = new Color32(132, 111, 223, 255);
                CreateTile(parent, new Vector2(-0.5f, 0.5f), color);
                CreateTile(parent, new Vector2(0f, 0.5f), color);
                CreateTile(parent, new Vector2(0f, 0.0f), color);
                CreateTile(parent, new Vector2(0.5f, 0.0f), color);
                break;
        }

        // 두 테트리스 블록이 동시에 착지한다면
        if (LeftBlock.GetComponent<BlockController>().IsFinish && RightBlock.GetComponent<BlockController>().IsFinish)
            index = preindex; // LeftBlock의 블록이 먼저 생성되고 RightBlock의 블록이 생성되므로 똑같은 index를 유지 

        // 동시에 착지하지 않거나 이미 LeftBlock의 블록을 생성했다면 
        else
            CreatePreview(preview); //프리뷰 블록 생성
    }
}