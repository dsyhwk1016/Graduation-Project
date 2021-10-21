using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private bool isDel; // ��Ʈ ������Ʈ �ı� ���� �Ǵ�
    private float speed = 10f;  // ��Ʈ ���� �ӵ�
    private Rigidbody2D noteRigidbody; // ����� ������ٵ� ������Ʈ ����

    void Start()
    {
        // ������ٵ� ������Ʈ�� ������ ������ �Ҵ�
        noteRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // speed�� �̿��� ������ٵ� �ӵ� ����
        noteRigidbody.velocity = new Vector2(0, -1 * speed);

        // ��Ʈ�� Ŭ�����߰ų�(isDel) miss�Ǿ� -2���Ϸ� �������� ��
        if (isDel || transform.position.y <= -2)
            Destroy(gameObject);    // �ڽ��� ������Ʈ �ı�
    }

    // private�� ����� isDel�� �Ҵ�� ��ȯ�� ���� Ŭ����
    public bool IsDel
    {
        set { isDel = value; }  // isDel �Ҵ�
        get { return isDel; }   // isDel ��ȯ
    }
}