using TMPro;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float laneBottomY;
    private bool isInsideHitZone = false;
    public int score = 0;
    public TextMeshPro ScoreText;

    void Start()
    {
        Transform lane1 = GameObject.Find("Lane1").transform;
        laneBottomY = lane1.position.y - 6f;
    }

    void Update()
    {
        // 超出底部則刪除
        if (transform.position.y < laneBottomY)
        {
            Destroy(gameObject);
        }

        // HitZone 內按上鍵刪除
        if (isInsideHitZone && Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddScore(10);
            Destroy(gameObject);
        }
    }

    // 進入HitZone範圍
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HitZone"))
        {
            isInsideHitZone = true;
        }
    }
    // 離開HitZone範圍
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("HitZone"))
        {
            isInsideHitZone = false;
        }
    }
    // 刪除時加分
    void AddScore(int amount)
    {
        GameObject scoreObj = GameObject.FindGameObjectWithTag("Score");
        if(scoreObj != null)
        {
            ScoreDisplay sd = scoreObj.GetComponent<ScoreDisplay>();
            if (sd != null)
            {
                sd.AddScore(amount);
            }
        }
    }
}
