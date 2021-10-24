using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI 관련 라이브러리

// 씬 전환 시 페이드 인 구현
public class Fade : MonoBehaviour
{
    private Image panel;    // 이미지 컴포넌트 변수
    private float time = 0f;    // 누적시간

    void Awake()
    {
        panel = gameObject.GetComponent<Image>();   // 이미지 컴포넌트 할당
    }

    void Start()
    {
        panel.color = new Color(0, 0, 0, 0);    // 투명도 초기화
    }

    void Update()
    {
        // 1초동안 투명도를 높임
        panel.color = new Color(0, 0, 0, 1f - time / 1f);

        // 1초가 지나면
        if (time >= 1f)
            Destroy(gameObject);    // 판넬 오브젝트 파괴

        time += Time.deltaTime; // 누적시간 갱신
    }
}