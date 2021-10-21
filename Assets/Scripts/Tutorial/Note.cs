using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private bool isDel; // 노트 오브젝트 파괴 여부 판단
    private float speed = 10f;  // 노트 낙하 속도
    private Rigidbody2D noteRigidbody; // 사용할 리지드바디 컴포넌트 변수

    void Start()
    {
        // 리지드바디 컴포넌트를 가져와 변수에 할당
        noteRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // speed를 이용해 리지드바디 속도 설정
        noteRigidbody.velocity = new Vector2(0, -1 * speed);

        // 노트를 클리어했거나(isDel) miss되어 -2이하로 내려왔을 때
        if (isDel || transform.position.y <= -2)
            Destroy(gameObject);    // 자신의 오브젝트 파괴
    }

    // private로 선언된 isDel의 할당과 반환을 위한 클래스
    public bool IsDel
    {
        set { isDel = value; }  // isDel 할당
        get { return isDel; }   // isDel 반환
    }
}