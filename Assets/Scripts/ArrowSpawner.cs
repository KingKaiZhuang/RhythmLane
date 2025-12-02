using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [System.Serializable]
    public class LaneSetting
    {
        public Transform lane;
        public float spawnInterval = 1f;
        [HideInInspector]
        public float timer = 0f;
    }
    // Lane1, Lane2, Lane3, Lane4
    public LaneSetting[] lanes;
    public GameObject arrowPrefab;
    public float spawnOffset = 3f;
    
    void Update()
    {
        foreach (LaneSetting lane in lanes)
        {
            lane.timer += Time.deltaTime;

            if(lane.timer >= lane.spawnInterval)
            {
                SpawnArrow(lane.lane);
                lane.timer = 0f;
            }
        }
    }
    // 將軌道的Position傳到Arrow.cs的SetLane，根據位置來生成arrowPrefab
    void SpawnArrow(Transform lane)
    {
        Vector3 spawnPos = new Vector3(lane.position.x, lane.position.y + spawnOffset, lane.position.z);
        
        GameObject arrowObj = Instantiate(arrowPrefab, spawnPos, Quaternion.identity);
        Arrow arrow = arrowObj.GetComponent<Arrow>();
        // 傳到Arrow.cs的SetLane
        arrow.SetLane(lane);
    }
}
