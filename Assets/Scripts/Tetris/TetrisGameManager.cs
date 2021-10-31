using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // 씬 관리 관련 라이브러리
using UnityEngine.UI;   // UI 관련 라이브러리

// 테트리스의 게임오버 상태를 표현하고, 게임 점수와 UI를 관리하는 게임 매니저
public class TetrisGameManager : MonoBehaviour
{
    public static TetrisGameManager instance; // 싱글턴을 할당할 전역 변수

    [Header("Editor Object")]
    public Text scoreText;  // 플레이 점수를 출력할 UI 텍스트
    public Text bestScoreText;  // 최고점을 출력할 UI 텍스트

    [Space(10f)]
    // 게임 오버 시 활성화 할 오브젝트
    public GameObject gameoverUI;
    public GameObject replay;

    [Space(10f)]
    // 게임 오버 시 비활성화 할 오브젝트 및 컴포넌트
    public GameObject leftBtn;
    public GameObject rightBtn;
    public BlockController leftBlock;
    public BlockController rightBlock;

    [HideInInspector]
    public int replayButton = 0;    // 두 Replay 버튼이 모두 눌렸는지 체크

    private bool isGameover = false; // 게임오버 상태
    private int score = 0;  // 플레이 점수
    private float surviveTime = 0;  // 생존 시간
    
    // 게임 시작과 동시에 싱글턴 구성
    void Awake()
    {
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
        if (Input.GetKeyDown("escape") == true)
            Application.Quit();
        
        // 게임오버가 아니면
        if (!isGameover)
        {
            // 생존 시간 갱신
            surviveTime += Time.deltaTime;

            // 15초마다 98점 추가
            if (surviveTime >= 15)
            {
                surviveTime = 0;
                AddScore(98);
            }
        }
        else
        {
            // 두 개의 Replay 버튼을 모두 눌렀다면
            if(replayButton == 2)
            {
                replayButton = 0;   // 0으로 초기화

                // 현재 씬 재로드
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    // 점수 추가 함수
    public void AddScore(int newScore)
    {
        // 게임 오버가 아니라면
        if (!isGameover)
        {
            score += newScore;  // 현재 점수 갱신
            scoreText.text = "SCORE\n" + score; // 현재 점수 출력
        }
    }

    // 게임 오버 시 동작
    public void OnGameOver()
    {
        // 현재 상태를 게임오버 상태로 변경
        isGameover = true;
        
        gameoverUI.SetActive(true); // 게임오버 UI 오브젝트 활성화
        scoreText.enabled = false;  // 현재 스코어 텍스트 컴포넌트 비활성화
        replay.SetActive(true); // 리플레이 버튼 활성화

        // 버튼 및 블록 동작 비활성화
        leftBlock.enabled = false;
        rightBlock.enabled = false;
        leftBtn.SetActive(false);
        rightBtn.SetActive(false);

        // BestScore 키로 저장된 최고 점수 가져오기
        int bestScore = PlayerPrefs.GetInt("BestScore");

        // 현재 점수가 최고 점수보다 크면
        if(score > bestScore)
        {
            // 최고 점수를 현재 점수로 변경
            bestScore = score;
            // 변경된 최고 점수를 BestScore 키로 저장
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        // 최고 점수와 플레이 점수 출력
        bestScoreText.text = "BEST SCORE : " + bestScore + "\nPLAY SCORE : " + score;
    }
}