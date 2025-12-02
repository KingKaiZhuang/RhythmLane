using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float laneBottomY;
    public void SetLane(Transform lane)
    {
        laneBottomY = lane.position.y - 6f;
    }

    void Update()
    {
        // 超出底部自動刪除
        if (transform.position.y < laneBottomY)
        {
            Destroy(gameObject);
        }
    }
}
