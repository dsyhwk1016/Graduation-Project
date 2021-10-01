using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris : MonoBehaviour
{
    [Header("Editor Object")]
    public GameObject tileLeftprefab;//왼쪽프리팹 오브젝트
    public GameObject tileRightprefab;//오른쪽프리팹 오브젝트
    public Transform LeftBlock;
    public Transform RightBlock;

    [Header("Game Settings")]
    [Range(4, 40)]
    public int boardWidth = 5;
    [Range(5, 20)]
    public int boardHeight = 10;


    void Start()
    {
        CreateLeftBlock();
        CreateRightBlock();
    }

    //왼쪽타일 생성
    Tile CreateLeftTile(Transform parent, Vector2 position, Color color, int order=1)
    {
        var go = Instantiate(tileLeftprefab);//왼쪽타일프리팹 불러오기
        go.transform.parent = parent;//부모 오브젝트 아래 자식 오브젝트로 생성
        go.transform.localPosition = position;//오브젝트의 위치 설정

        var tile = go.GetComponent<Tile>();//타일 오브젝트 불러오기
        tile.color = color;//타일 색상지정
        tile.sortingOrder = order;//타일의 레이어

        return tile;
    }

    //왼쪽블록 생성
    void CreateLeftBlock()
    {
        int index = Random.Range(0, 7);//랜덤으로 블록생성
        Color32 color = Color.white;

        LeftBlock.rotation = Quaternion.identity;
        LeftBlock.position = new Vector2(-8, 8);//화면 중앙상단에

        switch(index)
        {
            case 0://분홍색(I-Block)
                color = new Color32(239, 115, 196, 255);
                CreateLeftTile(LeftBlock, new Vector2(-1f, 0.0f), color);
                CreateLeftTile(LeftBlock, new Vector2(-0.5f, 0.0f), color);
                CreateLeftTile(LeftBlock, new Vector2(0f, 0.0f), color);
                CreateLeftTile(LeftBlock, new Vector2(0.5f, 0.0f), color);
                break;
                
            case 1://주황색(J-Block)
                color = new Color32(231,151,117, 255);
                CreateLeftTile(LeftBlock, new Vector2(-0.5f, 0.0f), color);
                CreateLeftTile(LeftBlock, new Vector2(0f, 0.0f), color);
                CreateLeftTile(LeftBlock, new Vector2(0f, 0.5f), color);
                CreateLeftTile(LeftBlock, new Vector2(0f, 1f), color);
                break;

            case 2://노란색(L-Block)
                color = new Color32(255,236,143, 255);
                CreateLeftTile(LeftBlock, new Vector2(0f, 1f), color);
                CreateLeftTile(LeftBlock, new Vector2(0f, 0.5f), color);
                CreateLeftTile(LeftBlock, new Vector2(0f, 0.0f), color);
                CreateLeftTile(LeftBlock, new Vector2(0.5f, 0.0f), color);
                break;

            case 3://파란색(O-Block)
                color = new Color32(56,71,232, 255);
                CreateLeftTile(LeftBlock, new Vector2(0f, 0.0f), color);
                CreateLeftTile(LeftBlock, new Vector2(0.5f, 0.0f), color);
                CreateLeftTile(LeftBlock, new Vector2(0f, 0.5f), color);
                CreateLeftTile(LeftBlock, new Vector2(0.5f, 0.5f), color);
                break;

            case 4://초록색(S-Block)
                color = new Color32(166,241,172, 255);
                CreateLeftTile(LeftBlock, new Vector2(-0.5f, 0.0f), color);
                CreateLeftTile(LeftBlock, new Vector2(0f, 0.0f), color);
                CreateLeftTile(LeftBlock, new Vector2(0f, 0.5f), color);
                CreateLeftTile(LeftBlock, new Vector2(0.5f, 0.5f), color);
                break;

            case 5://하늘색(T-Block)
                color = new Color32(145,224,244, 255);
                CreateLeftTile(LeftBlock, new Vector2(-0.5f, 0.0f), color);
                CreateLeftTile(LeftBlock, new Vector2(0f, 0.0f), color);
                CreateLeftTile(LeftBlock, new Vector2(0.5f, 0.0f), color);
                CreateLeftTile(LeftBlock, new Vector2(0f, 0.5f), color);
                break;
            case 6://보라색(Z-Block)
                color = new Color32(132,111,223, 255);
                CreateLeftTile(LeftBlock, new Vector2(-0.5f, 0.5f), color);
                CreateLeftTile(LeftBlock, new Vector2(0f, 0.5f), color);
                CreateLeftTile(LeftBlock, new Vector2(0f, 0.0f), color);
                CreateLeftTile(LeftBlock, new Vector2(0.5f, 0.0f), color);
                break;
            
        }

    }

    //오른쪽타일 생성
    Tile CreateRightTile(Transform parent, Vector2 position, Color color, int order = 1)
    {
        var go = Instantiate(tileRightprefab);
        go.transform.parent = parent;
        go.transform.localPosition = position;

        var tile = go.GetComponent<Tile>();
        tile.color = color;
        tile.sortingOrder = order;

        return tile;
    }

    //오른쪽블록 생성
    void CreateRightBlock()
    {
        int index = Random.Range(0, 7);
        Color32 color = Color.white;

        RightBlock.rotation = Quaternion.identity;
        RightBlock.position = new Vector2(8, 8);//화면 중앙상단에

        switch (index)
        {
            case 0://분홍색(I-Block)
                color = new Color32(239, 115, 196, 255);
                CreateRightTile(RightBlock, new Vector2(-1f, 0.0f), color);
                CreateRightTile(RightBlock, new Vector2(-0.5f, 0.0f), color);
                CreateRightTile(RightBlock, new Vector2(0f, 0.0f), color);
                CreateRightTile(RightBlock, new Vector2(0.5f, 0.0f), color);
                break;

            case 1://주황색(J-Block)
                color = new Color32(231, 151, 117, 255);
                CreateRightTile(RightBlock, new Vector2(-0.5f, 0.0f), color);
                CreateRightTile(RightBlock, new Vector2(0f, 0.0f), color);
                CreateRightTile(RightBlock, new Vector2(0f, 0.5f), color);
                CreateRightTile(RightBlock, new Vector2(0f, 1f), color);
                break;

            case 2://노란색(L-Block)
                color = new Color32(255, 236, 143, 255);
                CreateRightTile(RightBlock, new Vector2(0f, 1f), color);
                CreateRightTile(RightBlock, new Vector2(0f, 0.5f), color);
                CreateRightTile(RightBlock, new Vector2(0f, 0.0f), color);
                CreateRightTile(RightBlock, new Vector2(0.5f, 0.0f), color);
                break;

            case 3://파란색(O-Block)
                color = new Color32(56, 71, 232, 255);
                CreateRightTile(RightBlock, new Vector2(0f, 0.0f), color);
                CreateRightTile(RightBlock, new Vector2(0.5f, 0.0f), color);
                CreateRightTile(RightBlock, new Vector2(0f, 0.5f), color);
                CreateRightTile(RightBlock, new Vector2(0.5f, 0.5f), color);
                break;

            case 4://초록색(S-Block)
                color = new Color32(166, 241, 172, 255);
                CreateRightTile(RightBlock, new Vector2(-0.5f, 0.0f), color);
                CreateRightTile(RightBlock, new Vector2(0f, 0.0f), color);
                CreateRightTile(RightBlock, new Vector2(0f, 0.5f), color);
                CreateRightTile(RightBlock, new Vector2(0.5f, 0.5f), color);
                break;

            case 5://하늘색(T-Block)
                color = new Color32(145, 224, 244, 255);
                CreateRightTile(RightBlock, new Vector2(-0.5f, 0.0f), color);
                CreateRightTile(RightBlock, new Vector2(0f, 0.0f), color);
                CreateRightTile(RightBlock, new Vector2(0.5f, 0.0f), color);
                CreateRightTile(RightBlock, new Vector2(0f, 0.5f), color);
                break;
            case 6://보라색(Z-Block)
                color = new Color32(132, 111, 223, 255);
                CreateRightTile(RightBlock, new Vector2(-0.5f, 0.5f), color);
                CreateRightTile(RightBlock, new Vector2(0f, 0.5f), color);
                CreateRightTile(RightBlock, new Vector2(0f, 0.0f), color);
                CreateRightTile(RightBlock, new Vector2(0.5f, 0.0f), color);
                break;

        }

    }
    
    void Update()
    {
        
    }
}
