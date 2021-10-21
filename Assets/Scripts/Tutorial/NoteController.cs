using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note는 박자에 맞춰 랜덤한 노트를 생성
public class NoteController : MonoBehaviour
{
    [Header("Editor Object")]
    public GameObject[] noteList;  // 사용할 노트 프리팹 배열
    public Transform noteObj; // 노트가 생성될 부모 오브젝트

    [Header("Game Settings")]
    public float noteCycle = 1.2f; // 노트 생성 주기

    private float timeAfterCreate;  // 노트 생성 후 누적시간

    void Start()
    {
        // 첫 노트 생성
        RandNote(noteObj);

        timeAfterCreate = 0f;    // 누적시간 초기화
    }

    void Update()
    {
        timeAfterCreate += Time.deltaTime;  // 누적시간 갱신

        // 누적시간이 주기 이상일 때
        if(timeAfterCreate >= noteCycle)
        {
            RandNote(noteObj);  // 랜덤 노트 생성
            timeAfterCreate = 0f;   // 누적시간 리셋
        }
    }

    // 랜덤 노트 생성
    public void RandNote(Transform parent)
    {
        int index = Random.Range(0, 8); // 랜덤 변수 생성
        float xPos = -14f;  // x좌표 기준 값 설정(가장 왼쪽 노트)

        var go = Instantiate(noteList[index]);  // 해당하는 프리팹 복제
        go.transform.parent = parent;   // 부모 오브젝트 지정
        go.transform.localPosition = new Vector2(xPos + index * 4, 8);    // 노트 생성 위치
    }
}