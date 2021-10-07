using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // �� ���� ���� ���̺귯��
using UnityEngine.UI;   // UI ���� ���̺귯��

// ���ӿ��� ���¸� ǥ���ϰ�, ���� ������ UI�� �����ϴ� ���� �Ŵ���
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // �̱����� �Ҵ��� ���� ����

    [Header("Editor Object")]
    public Text scoreText;  // �÷��� ������ ����� UI �ؽ�Ʈ
    public Text bestScoreText;  // �ְ����� ����� UI �ؽ�Ʈ
    public GameObject gameoverUI;   // ���� ���� �� Ȱ��ȭ�� UI ���� ������Ʈ
    public GameObject replayPrefab;   // Replay ��ư ������
    [HideInInspector]
    public int replayButton;    // �� Replay ��ư�� ��� ���ȴ��� üũ

    private bool isGameover = false; // ���ӿ��� ����
    private int score = 0;  // �÷��� ����
    private float surviveTime = 0;  // ���� �ð�
    
    // ���� ���۰� ���ÿ� �̱��� ����
    void Awake()
    {
        // instance�� ��������� �ڽ��� ���� ������Ʈ�� �Ҵ�
        if (instance == null) instance = this;
        else
        {
            // instance�� �̹� �ٸ� GameManager ������Ʈ�� �Ҵ�Ǿ� �ִ� ���
            Debug.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�.");  // ��� �޽��� ��� ��
            Destroy(gameObject);    // �ڽ��� ���� ������Ʈ�� �ı�
        }
    }

    void Start()
    {
        replayButton = 0;   // ��ư ��ġ ī��Ʈ �ʱ�ȭ

        // ���ӿ��� UI�� �ڽ����� Replay ��ư ����
        ButtonCreate(replayPrefab, gameoverUI.transform, new Vector2(-302.5f, -281.5f));
        ButtonCreate(replayPrefab, gameoverUI.transform, new Vector2(-286.5f, -281.5f));
    }

    void Update()
    {
        // ���ӿ����� �ƴϸ�
        if (!isGameover)
        {
            // ���� �ð� ����
            surviveTime += Time.deltaTime;

            // 15�ʸ��� 98�� �߰�
            if (surviveTime >= 15)
            {
                surviveTime = 0;
                AddScore(98);
            }
        }
        else
        {
            // �� ���� Replay ��ư�� ��� �����ٸ�
            if(replayButton == 2)
            {
                replayButton = 0;   // 0���� �ʱ�ȭ

                // ���� �� ��ε�
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    // ��ư ���� �Լ�
    void ButtonCreate(GameObject prefab, Transform parent, Vector2 position, int order = 1)
    {
        var load = Instantiate(prefab); // ������ ����
        load.transform.parent = parent; // �θ� ������Ʈ ����
        load.transform.localPosition = position;    // ������Ʈ�� ��ġ ����

        var btn = load.GetComponent<SpriteRenderer>();  // SpriteRenderer ������Ʈ �Ҵ�
        btn.sortingOrder = order;   // ���̾� ���� ����
    }

    // ���� �߰� �Լ�
    public void AddScore(int newScore)
    {
        // ���� ������ �ƴ϶��
        if (!isGameover)
        {
            score += newScore;  // ���� ���� ����
            scoreText.text = "SCORE\n" + score; // ���� ���� ���
        }
    }

    // ���� ���� �� ����
    public void OnGameOver()
    {
        // ���� ���¸� ���ӿ��� ���·� ����
        isGameover = true;
        
        gameoverUI.SetActive(true); // ���ӿ��� UI ������Ʈ Ȱ��ȭ
        scoreText.enabled = false;  // ���� ���ھ� �ؽ�Ʈ ������Ʈ ��Ȱ��ȭ

        // BestScore Ű�� ����� �ְ� ���� ��������
        int bestScore = PlayerPrefs.GetInt("BestScore");

        // ���� ������ �ְ� �������� ũ��
        if(score > bestScore)
        {
            // �ְ� ������ ���� ������ ����
            bestScore = score;
            // ����� �ְ� ������ BestScore Ű�� ����
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        // �ְ� ������ �÷��� ���� ���
        bestScoreText.text = "BEST SCORE : " + bestScore + "\nPLAY SCORE : " + score;
    }
}