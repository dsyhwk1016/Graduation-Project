using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // 씬 관리 관련 라이브러리

// PlayerController는 플레이어의 캐릭터로서 Player 게임 오브젝트를 제어
public class PlayerController : MonoBehaviour
{
    // 두 캐릭터의 싱글턴을 할당할 전역 변수
    public static PlayerController[] instance = new PlayerController[2];

    [Header("Editor Object")]
    public float speed; // 이동 속력
    public string charName; // 캐릭터 이름

    private float playCycle = 0.5f;    // 오디오를 재생할 주기
    private float timeAfterPlay = 0f;    // 마지막 재생 후 누적시간
    private Rigidbody2D characterRigidbody; // 사용할 리지드바디 컴포넌트 변수
    private Animator animator;  // 사용할 애니메이터 컴포넌트 변수
    private AudioSource audioSource;    // 사용할 오디오 소스 컴포넌트 변수

    void Awake()
    {
        // 두 캐릭터가 처음 생성될 때 instance 배열에 할당
        if (instance[0] == null) instance[0] = this;
        else if (instance[1] == null) instance[1] = this;
        else Destroy(gameObject);   // 이후 생성되는 캐릭터는 파괴

        DontDestroyOnLoad(gameObject);  // 씬 전환 시 오브젝트 파괴 방지
    }

    void Start()
    {
        // 게임 오브젝트로부터 사용할 컴포넌트를 가져와 변수에 할당
        characterRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // 씬이 로드될 때마다 실행
    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인 걺
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 로드된 씬이 Tutorial이면
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            // 캐릭터 별 시작 위치 설정
            if (charName == "Ohm")
                transform.position = new Vector2(-1, -9);
            else if (charName == "Mho")
                transform.position = new Vector2(1, -9);
            else
                Debug.LogWarning("없는 캐릭터입니다.");
        }
    }

    void OnDisable()
    {
        // sceneLoaded에서 체인 제거
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Update()
    {
        // 입력을 감지할 축 이름 설정
        string hAxisName = "Horizontal" + charName;
        string vAxisName = "Vertical" + charName;

        // 수평, 수직 축의 입력값을 감지해 저장
        float xInput = Input.GetAxis(hAxisName);
        float yInput = Input.GetAxis(vAxisName);

        // 입력 방향에 따른 애니메이션 파라미터 변경
        animator.SetInteger("GoFront", (int)yInput);
        animator.SetInteger("GoRight", (int)xInput);

        // 축 입력값과 속력을 이용해 Vector2 속도 생성
        Vector2 newVelocity = new Vector2(xInput * speed, yInput * speed);
        // 리지드바디 속도에 newVelocity 할당
        characterRigidbody.velocity = newVelocity;

        // 캐릭터가 움직일 때 특정 시간 간격으로 효과음 반복 재생
        if (xInput != 0 || yInput != 0)
        {
            timeAfterPlay += Time.deltaTime;    // 누적시간 갱신
            
            if (timeAfterPlay >= playCycle) // 누적시간이 주기 이상이면
            {
                timeAfterPlay = 0;  // 누적시간 초기화

                audioSource.Play(); //오디오 재생
            }
        }

        //캐릭터가 화면 밖으로 나가지 않도록 월드좌표를 뷰포트로 제한
        Vector3 worldPos = Camera.main.WorldToViewportPoint(transform.position);
        if (worldPos.x < 0.02f) worldPos.x = 0.02f;
        if (worldPos.y < 0.045f) worldPos.y = 0.045f;
        if (worldPos.x > 0.98f) worldPos.x = 0.98f;
        if (worldPos.y > 0.4f) worldPos.y = 0.4f;
        transform.position = Camera.main.ViewportToWorldPoint(worldPos);
    }
}