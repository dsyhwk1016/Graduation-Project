using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//노트 오브젝트로서 일정 속도로 낙하
public class Note : MonoBehaviour
{
    private float speed = 3f;   // 노트 낙하 속도
    private Rigidbody2D noteRigidbody;  // 사용할 리지드바디 컴포넌트 변수

    void Start()
    {
        // 리지드바디 컴포넌트를 가져와 변수에 할당
        noteRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // speed를 이용해 리지드바디 속도 설정
        noteRigidbody.velocity = new Vector2(0, -1 * speed);
    }
}