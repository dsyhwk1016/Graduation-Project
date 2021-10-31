using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Button 오브젝트로서 Start 버튼을 생성
// 생성 함수 사용을 위해 AllCreate 클래스 상속
public class CreateStart : AllCreate
{
    [Header("Editor Object")]
    // 사용할 프리팹 변수
    public GameObject startPrefab;

    [Space(10f)]
    // 버튼이 생성될 부모 오브젝트
    public Transform startButton;

    void Start()
    {
        // 생성 함수를 호출해 Start 버튼 생성
        Create(startPrefab, startButton, new Vector2(-8.25f, -6f));
        Create(startPrefab, startButton, new Vector2(8.25f, -6f));
    }
}