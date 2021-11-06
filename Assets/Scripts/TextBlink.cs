using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBlink : MonoBehaviour
{
    public float blinkCycle = 1f;   // 깜빡임 주기

    private float time = 0f; // 누적 시간
    private int count = 0;  // 깜빡임 횟수
    private bool isHigh = true; // 알파값 확인
    private Text blinkText; // 깜빡일 텍스트
    private Color color;    // 오브젝트의 색상

    void Awake()
    {
        blinkText = GetComponent<Text>();
        color = blinkText.color;
    }

    void Update()
    {
        // 오브젝트가 활성화되어있고 횟수가 3 미만일 때
        if(gameObject.activeInHierarchy && count < 3)
        {
            time += Time.deltaTime; // 누적시간 갱신

            if(time >= blinkCycle)  // 누적시간이 주기 이상이면
            {
                time = 0f;  // 누적시간 초기화
                BlinkText();    // 깜빡임 함수 실행
            }
        }
    }

    // 깜빡이는 함수
    void BlinkText()
    {
        if(isHigh)
        {
            // 화면에 현재 표시된 상태라면(알파값이 1이면)
            color.a = 0f;   // 투명하게 조정(알파값 0)
            isHigh = false;
        }
        else
        {
            // 화면에 표시되지 않았다면(알파값이 0이면)
            color.a = 1f;   // 불투명하게 조정(알파값 1)
            count++;    // 횟수 1 증가
            isHigh = true;
        }

        blinkText.color = color;    // 설정된 색상 적용
    }
}