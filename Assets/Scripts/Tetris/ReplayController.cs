using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Replay 버튼으로서 씬 재로드
public class ReplayController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        // 충돌체가 Player 태그를 가지고 있으면
        if (collider.tag == "Player")
        {
            TetrisGameManager.instance.replayButton++;  // 게임 매니저의 replayButton 값을 1 증가

            // 버튼 On일 때 색상 변경
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 240, 180, 255);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        // 충돌체가 Player 태그를 가지고 있으면
        if (collider.tag == "Player")
        {
            TetrisGameManager.instance.replayButton--;  // 게임 매니저의 replayButton 값을 1 감소

            // 버튼 Off일 때 색상 변경
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
    }
}