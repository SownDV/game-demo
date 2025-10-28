using UnityEngine;

public class TimeItem : MonoBehaviour
{
    public float timeChange = 5f; // +5 là thêm, -5 là mất
    public float lifeTime = 10f;  // tự biến mất sau 10 giây

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // tìm đối tượng quản lý thời gian (ví dụ ScoreManager hoặc GameManager)
            ScoreManager manager = FindObjectOfType<ScoreManager>();

            if (manager != null)
            {
                manager.AddTime(timeChange);
            }

            // phát âm thanh (nếu có)
            AudioSource audio = other.GetComponent<AudioSource>();
            if (audio != null) audio.Play();

            Destroy(gameObject);
        }
    }
}
