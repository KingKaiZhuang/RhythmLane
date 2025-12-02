using UnityEngine;

public class HitZone : MonoBehaviour
{
    private Arrow currentArrow;

    void Update()
    {
        // 玩家在 HitZone 內按上鍵時
        if (currentArrow != null && Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddScore(10);

            Destroy(currentArrow.gameObject);
            currentArrow = null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 若進入的是 Arrow
        Arrow arrow = other.GetComponent<Arrow>();
        if (arrow != null)
        {
            currentArrow = arrow;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Arrow 離開 HitZone
        Arrow arrow = other.GetComponent<Arrow>();
        if (arrow != null && arrow == currentArrow)
        {
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
