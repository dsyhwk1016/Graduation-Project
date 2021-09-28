using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerController�� �÷��̾��� ĳ���ͷμ� Player ���� ������Ʈ�� ����
public class PlayerController : MonoBehaviour
{
    public float speed;   // �̵� �ӷ�
    public string charName;    // ĳ���� �̸�

    private bool isDead = false;    // ��� ����
    private Rigidbody2D characterRigidbody; // ����� ������ٵ� ������Ʈ ����
    private Animator animator;  // ����� �ִϸ����� ������Ʈ ����

    void Start()
    {
        // ���� ������Ʈ�κ��� ����� ������Ʈ�� ������ ������ �Ҵ�
        characterRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead) { return; } // ĳ���� ��� �� ����

        // �Է��� ������ �� �̸� ����
        string hAxisName = "Horizontal" + charName;
        string vAxisName = "Vertical" + charName;

        // ����, ���� ���� �Է°��� ������ ����
        float xInput = Input.GetAxis(hAxisName);
        float yInput = Input.GetAxis(vAxisName);

        // �Է� ���⿡ ���� �ִϸ��̼� �Ķ���� ����
        animator.SetInteger("GoFront", (int)yInput);
        animator.SetInteger("GoRight", (int)xInput);

        // �� �Է°��� �ӷ��� �̿��� Vector2 �ӵ� ����
        Vector2 newVelocity = new Vector2(xInput * speed, yInput * speed);
        // ������ٵ� �ӵ��� newVelocity �Ҵ�
        characterRigidbody.velocity = newVelocity;
    }
}