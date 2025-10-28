using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public GameObject hightScorePrefab;
    public float speed = 5f;

    void Update()
    {
        // Vật phẩm rơi xuống
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Tạo hệ số nhân ngẫu nhiên từ 2 đến 3
            int multiplier = Random.Range(2, 4);

            int currentScore = ScoreManager.score;
            int newScore = currentScore * multiplier;
            ScoreManager.AddScore(newScore);

            // Cộng điểm theo hệ số nhân
            // ScoreManager.AddScore(multiplier);
            // Phát âm thanh
            AudioSource audioSource = other.GetComponent<AudioSource>();
            if (audioSource != null)
                audioSource.Play();

            // Xóa vật phẩm sau khi nhặt
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
