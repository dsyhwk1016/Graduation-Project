using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public float tileSize = 0.5f; // 유닛 기준 타일의 크기

    private float fallCycle = 1f;    // 기본 낙하 주기
    private float timeAfterFall;    // 마지막 낙하 후 누적 시간

    void Start()
    {
        // 마지막 낙하 후 누적 시간을 0으로 초기화
        timeAfterFall = 0f;
    }

    void Update()
    {
        // timeAfterFall 갱신
        timeAfterFall += Time.deltaTime;

        // 최근 낙하 시점부터 누적된 시간이 낙하 주기 이상이면
        if ((timeAfterFall >= fallCycle) && (transform.position.y > -2))
        {
            // 누적된 시간 리셋
            timeAfterFall = 0f;

            // 블록을 타일크기만큼 낙하
            transform.Translate(new Vector2(0, -tileSize));
        }
    }

    public void move(int xDirection, int isRotate)
    {
        transform.Translate(new Vector2(xDirection * tileSize, 0));
        transform.Rotate(new Vector3(0, 0, isRotate * 90));
    }
}