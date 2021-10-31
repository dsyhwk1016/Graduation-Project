using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tetris는 랜덤한 블록을 생성
// 생성 함수 사용을 위해 AllCreate 클래스 상속
public class Tetris : AllCreate
{
    [Header("Editor Object")]
    public GameObject tilePrefab;   // 타일 프리팹

    [Space(10f)]
    public Transform LeftBlock; // 타일이 생성될 왼쪽 부모 오브젝트
    public Transform RightBlock;    // 타일이 생성될 오른쪽 부모 오브젝트
    public Transform preview;   // 프리뷰 블럭이 생성될 부모 오브젝트

    private int preindex = -1;  // 프리뷰 블럭의 인덱스값
    private float blockHeight;  // 블록이 생성될 높이
    private CreateBoard tetrisSize; // CreateBoard 컴포넌트 변수
    private BlockController leftCtrl;   // 왼쪽 BlockController 컴포넌트 변수
    private BlockController rightCtrl;  // 오른쪽 BlockController 컴포넌트 변수

    void Start()
    {
        // 사용할 컴포넌트들을 가져와 변수에 할당
        tetrisSize = GameObject.FindObjectOfType<CreateBoard>().GetComponent<CreateBoard>();
        leftCtrl = LeftBlock.GetComponent<BlockController>();
        rightCtrl = RightBlock.GetComponent<BlockController>();

        // 테트리스 보드 크기에 맞춰 블록 생성 높이 지정
        blockHeight = tetrisSize.boardHeight / 4f + 2.5f;

        // 랜덤한 테트리스 블록 생성
        NewBlock(LeftBlock);
        NewBlock(RightBlock);
    }

    // 프리뷰 블록 생성
    void NewPreview()
    {
        // 기존 프리뷰 삭제
        foreach (Transform tile in preview)
        {
            Destroy(tile.gameObject);
        }
        preview.DetachChildren();   // 부모 자식 관계 해제

        // 프리뷰 블록 랜덤 생성
        preindex = Random.Range(0, 7);
        CreateBlock(tilePrefab, preview, new Vector2(0, 1), preindex);

        // I 블록과 O 블록일 경우 프리뷰 위치 추가 조정
        if(preindex == 0)
            preview.position += new Vector3(0.25f, -0.5f, 0);
        else if(preindex == 3)
            preview.position -= new Vector3(0.25f, 0.25f, 0);
    }

    // 랜덤 블록 생성
    public void NewBlock(Transform parent)
    {
        // 부모 오브젝트의 이름을 비교해 서로 다른 위치에 블록 생성
        if(parent.name == LeftBlock.name)
            CreateBlock(tilePrefab, parent, new Vector2(-8.25f, blockHeight), preindex);
        else if(parent.name == RightBlock.name)
            CreateBlock(tilePrefab, parent, new Vector2(8.25f, blockHeight), preindex);
        else    // 존재하지 않는 부모 오브젝트일 경우
            Debug.LogWarning("없는 블록입니다.");   // 경고 메시지 출력
        
        // 양쪽 블록이 동시에 착지하지 않는 경우에만
        if (!(leftCtrl.IsFinish && rightCtrl.IsFinish))
            NewPreview();    // 프리뷰 생성
    }
}