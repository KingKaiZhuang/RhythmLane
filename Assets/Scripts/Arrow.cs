using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int laneIndex;      // 很重要：這顆箭屬於第幾條 Lane

    private float laneBottomY;

    public void SetLane(Transform lane)
    {
        laneBottomY = lane.position.y - 6f;
    }

    void Update()
    {
        if (transform.position.y < laneBottomY)
        {
            Destroy(gameObject);
        }
    }
}
