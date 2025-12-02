using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public Transform lane1;
    public GameObject arrowPrefab;
    public float spawnOffset = 3f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnArrow();
    }

    void SpawnArrow()
    {
        Vector3 spawnPos = new Vector3(lane1.position.x, lane1.position.y + spawnOffset, lane1.position.z);
        GameObject arrow = Instantiate(arrowPrefab, spawnPos, Quaternion.identity);
    }
}
