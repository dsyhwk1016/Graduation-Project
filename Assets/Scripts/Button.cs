using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Button은 버튼 프리팹으로, 테트리스 조작 버튼 생성
public class Button : MonoBehaviour
{
    [Header("Editor Object")]
    // 사용할 프리팹 변수
    public GameObject btnDownPrefab;
    public GameObject btnLeftPrefab;
    public GameObject btnRightPrefab;
    public GameObject btnRotationPrefab;

    // 버튼이 생성될 부모 오브젝트
    public Transform LeftButton;
    public Transform RightButton;
    
    void Start()
    {        
        // 버튼 생성 함수 호출
        ButtonCreate(btnDownPrefab, LeftButton, new Vector2(-8f, -8.3f));
        ButtonCreate(btnLeftPrefab, LeftButton, new Vector2(-10.5f, -6f));
        ButtonCreate(btnRightPrefab, LeftButton, new Vector2(-5.5f, -6f));
        ButtonCreate(btnRotationPrefab, LeftButton, new Vector2(-8f, -3.7f));
        ButtonCreate(btnDownPrefab, RightButton, new Vector2(8f, -8.3f));
        ButtonCreate(btnLeftPrefab, RightButton, new Vector2(5.5f, -6f));
        ButtonCreate(btnRightPrefab, RightButton, new Vector2(10.5f, -6f));
        ButtonCreate(btnRotationPrefab, RightButton, new Vector2(8f, -3.7f));
    }

    // 버튼 생성
    void ButtonCreate(GameObject prefab, Transform parent, Vector2 position, int order = 1)
    {
        var load = Instantiate(prefab); // 프리팹 복제
        load.transform.parent = parent; // 부모 오브젝트 지정
        load.transform.localPosition = position;    // 오브젝트의 위치 설정

        var btn = load.GetComponent<SpriteRenderer>();  // SpriteRenderer 컴포넌트 할당
        btn.sortingOrder = order;   // 레이어 순서 지정
    }
}

