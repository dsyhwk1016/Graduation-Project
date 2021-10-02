using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [Header("Editor Object")]
    public GameObject btnDownprefab;
    public GameObject btnLeftprefab;
    public GameObject btnRightprefab;
    public GameObject btnRoationprefab;

    public Transform LeftButton;
    public Transform RightButton;

    
    private SpriteRenderer spriterenderer;
    void Start()
    {
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
        
        ButtonCreate(btnDownprefab, LeftButton, new Vector2(-8f, -8.3f));
        ButtonCreate(btnLeftprefab, LeftButton, new Vector2(-10.5f, -6f));
        ButtonCreate(btnRightprefab, LeftButton, new Vector2(-5.5f, -6f));
        ButtonCreate(btnRoationprefab, LeftButton, new Vector2(-8f, -3.7f));
        ButtonCreate(btnDownprefab, RightButton, new Vector2(8f, -8.3f));
        ButtonCreate(btnLeftprefab, RightButton, new Vector2(5.5f, -6f));
        ButtonCreate(btnRightprefab, RightButton, new Vector2(10.5f, -6f));
        ButtonCreate(btnRoationprefab, RightButton, new Vector2(8f, -3.7f));
    }

    void Update()
    {
        
    }
    //버튼 생성
    void ButtonCreate(GameObject sprite, Transform parent, Vector2 position, int order = 1)
    {
        var load = Instantiate(sprite);//해당프리팹 불러오기
        load.transform.parent = parent;//부모 오브젝트 아래 자식 오브젝트로 생성
        load.transform.localPosition = position;//오브젝트의 위치 설정

        var btn = load.GetComponent<SpriteRenderer>();//버튼 오브젝트 불러오기
        btn.sortingOrder = order;//버튼의 레이어
    }
}

