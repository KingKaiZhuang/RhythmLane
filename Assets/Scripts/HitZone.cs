using UnityEngine;

public class HitZone : MonoBehaviour
{
    [Header("這個 HitZone 負責哪一條 Lane (0~3)")]
    public int laneIndex;

    private Arrow currentArrow;

    [Header("每一條 Lane 對應的按鍵")]
    public KeyCode[] laneKeys = {
        KeyCode.LeftArrow,   // lane 0
        KeyCode.DownArrow,   // lane 1
        KeyCode.RightArrow,  // lane 2
        KeyCode.UpArrow,     // lane 3
    };

    [Header("顏色設定")]
    public SpriteRenderer spriteRenderer;  // 顯示 HitZone 的圖
    public Color normalColor = Color.white;
    public Color pressedColor = Color.yellow;

    void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.color = normalColor;
        }
    }

    void Update()
    {
        // LaneIndex 超出鍵盤表長度就不處理
        if (laneIndex < 0 || laneIndex >= laneKeys.Length)
            return;

        KeyCode keyForThisLane = laneKeys[laneIndex];

        // 按下鍵：顏色變化 + 嘗試判定
        if (Input.GetKeyDown(keyForThisLane))
        {
            Debug.Log($"[HitZone {laneIndex}] Key {keyForThisLane} Down");

            if (spriteRenderer != null)
                spriteRenderer.color = pressedColor;

            // 有箭在這條 Lane 的 HitZone 內才判定
            if (currentArrow != null)
            {
                AddScore(10);
                Destroy(currentArrow.gameObject);
                currentArrow = null;
            }
        }

        // 放開鍵：顏色還原
        if (Input.GetKeyUp(keyForThisLane))
        {
            Debug.Log($"[HitZone {laneIndex}] Key {keyForThisLane} Up");

            if (spriteRenderer != null)
                spriteRenderer.color = normalColor;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Arrow arrow = other.GetComponent<Arrow>();
        if (arrow != null)
        {
            Debug.Log($"[HitZone {laneIndex}] Enter Arrow lane={arrow.laneIndex}");

            if (arrow.laneIndex == laneIndex)
            {
                currentArrow = arrow;
                Debug.Log($"[HitZone {laneIndex}] Arrow 設為可判定目標");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Arrow arrow = other.GetComponent<Arrow>();
        if (arrow != null && arrow == currentArrow)
        {
            Debug.Log($"[HitZone {laneIndex}] Arrow 離開");
            currentArrow = null;
        }
    }

    void AddScore(int amount)
    {
        GameObject scoreObj = GameObject.FindGameObjectWithTag("Score");
        if (scoreObj != null)
        {
            ScoreDisplay sd = scoreObj.GetComponent<ScoreDisplay>();
            if (sd != null)
            {
                sd.AddScore(amount);
            }
        }
    }
}
