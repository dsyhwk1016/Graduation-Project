using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Judge Line 오브젝트로, 오디오를 재생하고 노트 클리어 여부를 판정
public class RhythmRule : MonoBehaviour
{
    [HideInInspector] public bool noteIn; // 판정라인에서 버튼 눌렀는지 여부
    [HideInInspector] public string collisionTag; // 충돌한 오브젝트의 태그명
    [HideInInspector] public AudioSource audioSource; // 가져올 오디오 소스

    void Start()
    {
        // 오디오 소스 컴포넌트 추가
        audioSource = gameObject.GetComponent<AudioSource>();

        // 뮤트: true일 경우 소리가 나지 않음
        audioSource.mute = false;

        // 루핑: true일 경우 반복 재생
        audioSource.loop = false;

        // 자동 재생: true일 경우 자동 재생
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        // 오디오가 재생 중이고 Joystick의 START 키를 눌렀으면
        if (audioSource.isPlaying && Input.GetKeyDown(KeyCode.JoystickButton7))
            TutorialGameManager.instance.OnGameOver();  // 게임오버 실행(튜토리얼 스킵)

        // 오디오의 현재 재생시간이 총 길이 이상일 때
        if (audioSource.time >= audioSource.clip.length)
            TutorialGameManager.instance.OnGameOver();  // 게임오버 실행
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collisionTag = collision.tag;    // 충돌한 객체의 태그명 가져오기
        noteIn = false; // false로 초기화
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (noteIn == false)    // 노트를 놓쳤다면
        {
            Destroy(GameObject.Find("Note").transform.GetChild(0).gameObject);  // 노트 삭제
            TutorialGameManager.instance.HeartDown();   // 생명 1 감소
        }
        
        collisionTag = null;    // 태그 초기화
    }
}