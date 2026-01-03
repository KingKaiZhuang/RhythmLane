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

    [Header("判定寬度 (距離)")]
    public float perfectThreshold = 0.25f;
    public float greatThreshold = 0.5f;
    public float goodThreshold = 0.8f;

    [Header("判定顏色")]
    public Color perfectColor = new Color(0, 1, 1);   // Cyan
    public Color greatColor = Color.green;
    public Color goodColor = Color.yellow;
    public Color badColor = Color.red;

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



            // 有箭在這條 Lane 的 HitZone 內才判定
            if (currentArrow != null)
            {
                // 計算與 HitZone 中心的距離
                float distance = Mathf.Abs(currentArrow.transform.position.y - transform.position.y);
                
                string rank = "Bad";
                int scoreToAdd = 0;

                if (distance <= perfectThreshold)
                {
                    rank = "Perfect";
                    scoreToAdd = 100;
                    if (spriteRenderer != null) spriteRenderer.color = perfectColor;
                }
                else if (distance <= greatThreshold)
                {
                    rank = "Great";
                    scoreToAdd = 50;
                    if (spriteRenderer != null) spriteRenderer.color = greatColor;
                }
                else if (distance <= goodThreshold)
                {
                    rank = "Good";
                    scoreToAdd = 20;
                    if (spriteRenderer != null) spriteRenderer.color = goodColor;
                }
                
                Debug.Log($"[HitZone {laneIndex}] Hit! Dist={distance:F3} => {rank}");

                if (scoreToAdd > 0)
                {
                    AddScore(scoreToAdd);
                    Destroy(currentArrow.gameObject);
                    currentArrow = null;
                }
                else
                {
                    // 雖然在 Trigger 內，但距離太遠視為 Bad (可選擇是否銷毀或只扣分/斷 Combo)
                    // 這邊範例：視為 Bad，銷毀
                    Debug.Log($"[HitZone {laneIndex}] Bad Hit... Dist={distance:F3}");
                    
                    if (spriteRenderer != null) spriteRenderer.color = badColor;

                    Destroy(currentArrow.gameObject);
                    currentArrow = null;
                }
            }
            else
            {
                // 空揮 (Empty Hit)
                if (spriteRenderer != null) spriteRenderer.color = badColor;
                AddScore(-10);
                Debug.Log($"[HitZone {laneIndex}] Empty Hit! -10");
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
