using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnController : MonoBehaviour
{
    public Sprite[] newsprite;

    private bool onButton = false;  // 버튼 on 여부
    private string collisionTag;    // 충돌한 오브젝트의 태그명
    private float cycle = 1.5f; // 블록 함수 호출 주기
    private float timeAfterMove;    //마지막 호출 후 누적 시간
    private SpriteRenderer spriterenderer;

    void Start()
    {
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (onButton)   // 버튼이 on 상태이면
        {
            timeAfterMove += Time.deltaTime;    // 누적 시간 갱신

            if(timeAfterMove >= cycle)  // 누적 시간이 주기 이상이면
            {
                timeAfterMove = 0f; // 누적 시간 초기화

                // 블록 함수 호출
                if (collisionTag == "Player")//충돌체의 Player 태그 확인
                    if (gameObject.transform.parent.name == "LeftButton")//부모 오브젝트의 이름 확인
                    {                                                    //본인의 태그 확인
                        if (gameObject.tag == "Left")
                            GameObject.Find("LeftBlock").GetComponent<BlockController>().Move(-1, false);
                        else if (gameObject.tag == "Right")
                            GameObject.Find("LeftBlock").GetComponent<BlockController>().Move(1, false);
                        else if (gameObject.tag == "Rotation")
                            GameObject.Find("LeftBlock").GetComponent<BlockController>().Move(0, true);
                        else if (gameObject.tag != "Down") Debug.LogError("");
                    }

                    else if (gameObject.transform.parent.name == "RightButton")
                    {
                        if (gameObject.tag == "Left")
                            GameObject.Find("RightBlock").GetComponent<BlockController>().Move(-1, false);
                        else if (gameObject.tag == "Right")
                            GameObject.Find("RightBlock").GetComponent<BlockController>().Move(1, false);
                        else if (gameObject.tag == "Rotation")
                            GameObject.Find("RightBlock").GetComponent<BlockController>().Move(0, true);
                        else if (gameObject.tag != "Down") Debug.LogError("");
                    }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//버튼 On
    {
        collisionTag = collision.gameObject.tag;    // 충돌한 객체의 태그명 가져오기
        if (collisionTag == "Player")
        {
            onButton = true;    // 버튼 on
            timeAfterMove = cycle;  // 누적 시간을 주기로 초기화
            ButtonOn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)//버튼 Off
    {
        if (collision.gameObject.tag == "Player")
        {
            onButton = false;   //버튼 off
            ButtonOut();
        }
    }

    void ButtonOn()//충돌 발생시 오브젝트 이미지 변경
     {
        spriterenderer.sprite = newsprite[0];

        // Down 버튼이 On이면 블록의 하강 속도 상승
        if (gameObject.tag == "Down")
            if (gameObject.transform.parent.name == "LeftButton")
                GameObject.Find("LeftBlock").GetComponent<BlockController>().ChangeSpeed(true);
            else if (gameObject.transform.parent.name == "RightButton")
                    GameObject.Find("RightBlock").GetComponent<BlockController>().ChangeSpeed(true);
    }

    void ButtonOut()
    {
        spriterenderer.sprite = newsprite[1];

        // Down 버튼이 On이면 블록의 하강 속도 원상복구
        if (gameObject.tag == "Down")
            if (gameObject.transform.parent.name == "LeftButton")
                GameObject.Find("LeftBlock").GetComponent<BlockController>().ChangeSpeed(false);
            else if (gameObject.transform.parent.name == "RightButton")
                GameObject.Find("RightBlock").GetComponent<BlockController>().ChangeSpeed(false);
    }
}
