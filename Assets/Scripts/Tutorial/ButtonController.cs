using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 버튼 오브젝트로서 Start 버튼을 생성
public class ButtonController : MonoBehaviour
{
    [Header("Editor Object")]
    // 사용할 프리팹 변수
    public GameObject startPrefab;

    [Space(10f)]
    // 버튼이 생성될 부모 오브젝트
    public Transform startButton;

    void Start()
    {
        // 버튼 생성 함수 호출
        ButtonCreate(startPrefab, startButton, new Vector2(-8.25f, -6f));
        ButtonCreate(startPrefab, startButton, new Vector2(8.25f, -6f));
    }

    // 버튼생성 
    void ButtonCreate(GameObject prefab, Transform parent, Vector2 position, int order = 1)
    {
        var load = Instantiate(prefab); // 프리팹 복제
        load.transform.parent = parent; // 부모 오브젝트 지정
        load.transform.localPosition = position;    // 오브젝트의 위치 설정

        var Btn = load.GetComponent<SpriteRenderer>();  // SpriteRenderer 컴포넌트 할당
        Btn.sortingOrder = order;   // 레이어 순서 지정
    }
}
