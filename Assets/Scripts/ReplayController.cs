using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Replay ��ư���μ� �� ��ε�
public class ReplayController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        // �浹ü�� Player �±׸� ������ ������
        if (collider.tag == "Player")
        {
            GameManager.instance.replayButton++;  // ���� �Ŵ����� replayButton ���� 1 ����

            // ��ư On�� �� ���� ����
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 240, 180, 255);
        }
    }
}