using UnityEngine;

// 모든 생성 함수들의 집합
public class AllCreate : MonoBehaviour
{
    // 프리팹을 이용해 오브젝트를 생성하는 함수 (Tetris Board, Tetris Tile, All Button)
    // 부모 오브젝트, local position, 색상, local scale, 레이어 순서를 전달 받아 할당
    public void Create(GameObject prefab, Transform parent, Vector2 position, Color color = new Color(), Vector2 scale = new Vector2(), int order = 1)
    {
        // 크기와 색상이 입력되지 않았을 경우 초기화
        if(scale == new Vector2())
            scale = new Vector2(1, 1);
        if(color == new Color())
            color = Color.white;
        
        GameObject dupe = Instantiate(prefab);  // 프리팹을 복제해 새 오브젝트 생성

        // 사용할 컴포넌트를 가져와 변수에 할당
        Transform dupeTrans = dupe.transform;
        SpriteRenderer dupeRend = dupe.GetComponent<SpriteRenderer>();

        dupeTrans.parent = parent;  // 부모 오브젝트 지정
        dupeTrans.localPosition = position; // 위치 설정
        dupeTrans.localScale = scale;   // 크기 설정

        dupeRend.color = color; // 색상 지정
        dupeRend.sortingOrder = order;  // 레이어 순서 지정
    }

    // 프리팹 배열을 이용해 랜덤 오브젝트를 생성하는 함수 (Rhythm Note)
    // 부모 오브젝트를 전달 받아 할당하고 local position을 지정
    public void Create(GameObject[] prefab, Transform parent)
    {
        int index = Random.Range(0, 8); // 랜덤 변수 생성
        float xPos = -14f;  // x좌표 기준 값 설정(가장 왼쪽 노트)

        var go = Instantiate(prefab[index]);    // 해당하는 프리팹 복제
        go.transform.parent = parent;   // 부모 오브젝트 지정
        go.transform.localPosition = new Vector2(xPos + index * 4, 8);  // 위치 설정
    }

    // 프리팹을 이용해 랜덤한 테트리스 블록을 생성하는 함수
    // 부모 오브젝트와 위치를 전달 받아 할당하고, 인덱스를 전달 받아 색상과 모양을 결정
    public void CreateBlock(GameObject prefab, Transform parent, Vector2 position, int index)
    {
        Color32 color = Color.white;    // 색상 초기화

        parent.rotation = Quaternion.identity;  // 블록 방향 초기화
        parent.position = position; // 블록 생성 위치 지정

        switch (index)
        {
            case 0: // 분홍색(I-Block)
                parent.position += new Vector3(0, 0.5f, 0); // 위치 조정
                color = new Color32(239, 115, 196, 255);    // 블록 색상 지정
                // 블록 모양에 맞춰 타일 생성
                Create(prefab, parent, new Vector2(-1f, 0.0f), color);
                Create(prefab, parent, new Vector2(-0.5f, 0.0f), color);
                Create(prefab, parent, new Vector2(0f, 0.0f), color);
                Create(prefab, parent, new Vector2(0.5f, 0.0f), color);
                break;

            case 1: // 주황색(J-Block)
                parent.position -= new Vector3(0, 0.5f, 0);
                color = new Color32(231, 151, 117, 255);
                Create(prefab, parent, new Vector2(-0.5f, 0.0f), color);
                Create(prefab, parent, new Vector2(0f, 0.0f), color);
                Create(prefab, parent, new Vector2(0f, 0.5f), color);
                Create(prefab, parent, new Vector2(0f, 1f), color);
                break;

            case 2: // 노란색(L-Block)
                parent.position -= new Vector3(0, 0.5f, 0);
                color = new Color32(255, 236, 143, 255);
                Create(prefab, parent, new Vector2(0f, 1f), color);
                Create(prefab, parent, new Vector2(0f, 0.5f), color);
                Create(prefab, parent, new Vector2(0f, 0.0f), color);
                Create(prefab, parent, new Vector2(0.5f, 0.0f), color);
                break;

            case 3: // 파란색(O-Block)
                color = new Color32(56, 71, 232, 255);
                Create(prefab, parent, new Vector2(0f, 0.0f), color);
                Create(prefab, parent, new Vector2(0.5f, 0.0f), color);
                Create(prefab, parent, new Vector2(0f, 0.5f), color);
                Create(prefab, parent, new Vector2(0.5f, 0.5f), color);
                break;

            case 4: // 초록색(S-Block)
                color = new Color32(166, 241, 172, 255);
                Create(prefab, parent, new Vector2(-0.5f, 0.0f), color);
                Create(prefab, parent, new Vector2(0f, 0.0f), color);
                Create(prefab, parent, new Vector2(0f, 0.5f), color);
                Create(prefab, parent, new Vector2(0.5f, 0.5f), color);
                break;

            case 5: // 하늘색(T-Block)
                color = new Color32(145, 224, 244, 255);
                Create(prefab, parent, new Vector2(-0.5f, 0.0f), color);
                Create(prefab, parent, new Vector2(0f, 0.0f), color);
                Create(prefab, parent, new Vector2(0.5f, 0.0f), color);
                Create(prefab, parent, new Vector2(0f, 0.5f), color);
                break;

            case 6: // 보라색(Z-Block)
                color = new Color32(132, 111, 223, 255);
                Create(prefab, parent, new Vector2(-0.5f, 0.5f), color);
                Create(prefab, parent, new Vector2(0f, 0.5f), color);
                Create(prefab, parent, new Vector2(0f, 0.0f), color);
                Create(prefab, parent, new Vector2(0.5f, 0.0f), color);
                break;

            default:    // 첫 블록(index = -1)일 경우
                index = Random.Range(0, 7); // 인덱스 할당
                CreateBlock(prefab, parent, position, index);   // 재귀
                break;
        }
    }
}