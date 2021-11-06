using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NoteController는 박자에 맞춰 랜덤한 노트를 생성
// 생성 함수 사용을 위해 AllCreate 클래스 상속
public class NoteController : AllCreate
{
    [Header("Editor Object")]
    public GameObject[] noteList;   // 사용할 노트 프리팹 배열
    public Transform noteObj;   // 노트가 생성될 부모 오브젝트

    private int count = 0;  // 생성된 노트 개수
    private float noteCycle = 1.6f;  // 노트 생성 주기
    private float timeAfterCreate;  // 노트 생성 후 누적시간

    void Start()
    {
        timeAfterCreate = 1.1f; // 누적시간 초기화
    }

    void Update()
    {
        timeAfterCreate += Time.deltaTime;  // 누적시간 갱신

        // 누적시간이 주기 이상일 때
        if(timeAfterCreate >= noteCycle && count < 16)
        {
            Create(noteList, noteObj);  // 랜덤 노트 생성
            count++;
            timeAfterCreate = 0f;   // 누적시간 리셋
        }
    }
}