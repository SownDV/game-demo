using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeItemSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject timeBonusPrefab;   // Prefab vật phẩm
    public float spawnInterval = 5f;      // Thời gian giữa các lần spawn
    public float heightOffset = 1f;       // Độ cao vật phẩm so với mặt đất

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnBoostOnRandomGround();
        }
    }

    void SpawnBoostOnRandomGround()
    {
        // Lấy danh sách tất cả ground trong scene
        GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");

        if (grounds.Length == 0)
        {
            return;
        }

        // Chọn ngẫu nhiên 1 ground
        GameObject randomGround = grounds[Random.Range(0, grounds.Length)];

        // Lấy vị trí trung tâm của ground
        Vector3 groundPos = randomGround.transform.position;

        // Nếu ground có Collider2D, dùng kích thước để tính vị trí spawn hợp lý
        Collider2D groundCol = randomGround.GetComponent<Collider2D>();
        if (groundCol != null)
        {
            Bounds bounds = groundCol.bounds;
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float spawnY = bounds.max.y + heightOffset;

            Vector3 spawnPos = new Vector3(randomX, spawnY, 0);
            Instantiate(timeBonusPrefab, spawnPos, Quaternion.identity);

        }
        else
        {
            // fallback nếu ground không có collider
            Vector3 spawnPos = groundPos + Vector3.up * heightOffset;
            Instantiate(timeBonusPrefab, spawnPos, Quaternion.identity);
        }
    }
}
