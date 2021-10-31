using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // 씬 관리 관련 라이브러리
using UnityEngine.UI;   // UI 관련 라이브러리

// 튜토리얼의 게임오버 상태를 표현하고, 씬 전환을 관리하는 게임 매니저
public class TutorialGameManager : MonoBehaviour
{
    public static TutorialGameManager instance; // 싱글턴을 할당할 전역 변수
   
    [Header("Editor Object")]
    // 튜토리얼 시작 시 활성화 할 오브젝트
    public GameObject leftBtn;
    public GameObject rightBtn;
    public GameObject tutorialUI;

    [Space(10f)]
    // 튜토리얼 시작 시 비활성화 할 오브젝트
    public GameObject startButton;

    [Space(10f)]
    public GameObject note; // 노트 생성할 부모 오브젝트
    public Image[] UIHeart; // 목숨 나타낼 UI 이미지 배열

    [HideInInspector] public int startCnt = 0;  // 두 Start 버튼이 모두 눌렸는지 체크

    private int lifeCnt = 3;   // 튜토리얼 생명
    private bool isGameover = false;    // 게임오버 상태

    // 게임 시작과 동시에 싱글턴 구성
    void Awake()
    {
        // 게임 시작 시 Start 버튼 활성화
        startButton.SetActive(true);

        // 게임 시작 시 오브젝트 비활성화
        leftBtn.SetActive(false);
        rightBtn.SetActive(false);
        note.SetActive(false);
        tutorialUI.SetActive(false);

        // instance가 비어있으면 자신의 게임 오브젝트를 할당
        if (instance == null) instance = this;
        else
        {
            // instance에 이미 다른 GameManager 오브젝트가 할당되어 있는 경우
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다.");  // 경고 메시지 출력 후
            Destroy(gameObject);    // 자신의 게임 오브젝트를 파괴
        }
    }

    void Update()
    {
        // 게임오버가 아닐 때
        if (!isGameover)
        {
            // 두 개의 Start 버튼을 모두 눌렀다면
            if (startCnt == 2)
            {
                startButton.SetActive(false);   // 스타트 버튼 비활성화

                // 리듬게임 버튼 활성화
                leftBtn.SetActive(true);
                rightBtn.SetActive(true);

                // 노트 및 생명 오브젝트 활성화 
                note.SetActive(true);
                tutorialUI.SetActive(true);

                GameObject.Find("Judge Line").GetComponent<RhythmRule>().audioSource.Play();    // 음악 재생 
            }
        }
        // 게임오버일 때
        else
        {
            if (lifeCnt > 0)    // 생명이 남아있다면
                SceneManager.LoadScene("TetrisGame");   // 테트리스 게임 시작
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬 재로드
        }
    }

    // 게임 오버 동작
    public void OnGameOver()
    {
        // 현재 상태를 게임오버 상태로 변경
        isGameover = true;

        // 노트 오브젝트 비활성화
        note.SetActive(false);
    }

    // 생명 감소
    public void HeartDown()
    {
        UIHeart[--lifeCnt].color = new Color(0, 0, 0, 0.4f);    // 하트 이미지 색상 변경

        // 생명이 0이되는 순간 게임 오버 실행
        if (lifeCnt == 0)
            OnGameOver();
    }
}