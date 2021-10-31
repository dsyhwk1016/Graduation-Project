using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CreateTetrisButton은 Button 오브젝트로, 테트리스 조작 버튼을 생성
// 생성 함수 사용을 위해 AllCreate 클래스 상속
public class CreateTetrisButton : AllCreate
{
    [Header("Editor Object")]
    // 사용할 프리팹 변수
    public GameObject btnDownPrefab;
    public GameObject btnLeftPrefab;
    public GameObject btnRightPrefab;
    public GameObject btnRotationPrefab;
    public GameObject replayPrefab;

    [Space(10f)]
    // 버튼이 생성될 부모 오브젝트
    public Transform LeftButton;
    public Transform RightButton;
    public Transform replayButton;
    
    void Start()
    {        
        // 양쪽에 각각 테트리스 조작 버튼 생성
        Create(btnDownPrefab, LeftButton, new Vector2(-8.25f, -8.3f));  // L-하강
        Create(btnLeftPrefab, LeftButton, new Vector2(-10.75f, -6f));   // L-좌향 이동
        Create(btnRightPrefab, LeftButton, new Vector2(-5.75f, -6f));   // L-우향 이동
        Create(btnRotationPrefab, LeftButton, new Vector2(-8.25f, -3.7f));  // L-회전
        Create(btnDownPrefab, RightButton, new Vector2(8.25f, -8.3f));  // R-하강
        Create(btnLeftPrefab, RightButton, new Vector2(5.75f, -6f));    // R-좌향 이동
        Create(btnRightPrefab, RightButton, new Vector2(10.75f, -6f));  // R-우향 이동
        Create(btnRotationPrefab, RightButton, new Vector2(8.25f, -3.7f));  // R-회전

        // Replay 버튼 생성
        Create(replayPrefab, replayButton, new Vector2(-8.25f, -6f));
        Create(replayPrefab, replayButton, new Vector2(8.25f, -6f));
    }
}