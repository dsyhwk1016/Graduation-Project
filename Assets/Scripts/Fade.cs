using UnityEngine;
using UnityEngine.UI;   // UI 관련 라이브러리

// 페이드 인, 페이드 아웃을 구현
public class Fade : MonoBehaviour
{
    public GameObject fade;    // 페이드 효과를 적용할 게임 오브젝트

    protected int playFade = 0;    // 페이드 종류(-1 : 페이드아웃, 0 : 노 페이드, 1 : 페이드인)
    
    private float time = 0f;    // 누적시간
    private Color color;    // 색상 변수
    private Image panel;    // 이미지 컴포넌트 변수

    void Start()
    {
        panel = fade.GetComponent<Image>(); // 이미지 컴포넌트 할당
        color = panel.color;    // 색상 할당
    }

    protected virtual void Update()
    {
        if(playFade > 0)    // 페이드 인
        {
            fade.SetActive(true);  // 오브젝트 활성화
            FadeIn();   // 페이드 인 함수 실행
        }
        else if(playFade < 0)   // 페이드 아웃
        {
            fade.SetActive(true);  // 오브젝트 활성화
            FadeOut();  // 페이드 아웃 함수 실행
        }
    }

    void FadeIn()
    {
        time += Time.deltaTime; // 누적시간 갱신

        // 투명도를 높임(알파값 감소)
        color.a = 1f - time;
        panel.color = color;

        // 1초가 지나면
        if (time >= 1f)
        {
            time = 0f;  // 누적시간 초기화
            fade.SetActive(false); // 오브젝트 비활성화
            playFade = 0;   // 페이드 종료
        }
    }

    void FadeOut()
    {
        time += Time.deltaTime; // 누적시간 갱신

        // 투명도를 낮춤(알파값 증가)
        color.a = time;
        panel.color = color;

        // 1초가 지나면
        if (time >= 1f)
        {
            time = 0f;  // 누적시간 초기화
            fade.SetActive(false); // 오브젝트 비활성화
            playFade = 0;   // 페이드 종료
        }
    }
}