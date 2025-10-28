using System.Collections;
using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    public float boostMultiplier = 2f;   // Nhân tốc độ (x2)
    public float boostDuration = 3f;     // Thời gian tăng tốc
    public float lifeTime = 10f;         // Tồn tại tối đa 10 giây

    void Start()
    {
        // Tự hủy sau một thời gian
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterMovement movement = other.GetComponent<CharacterMovement>();
            if (movement != null)
            {
                movement.StartCoroutine(ApplySpeedBoost(movement));
            }

            // Phát âm thanh (nếu có)
            AudioSource audio = other.GetComponent<AudioSource>();
            if (audio != null) audio.Play();

            // Xóa vật phẩm sau khi nhặt
            Destroy(gameObject);
        }
    }

    IEnumerator ApplySpeedBoost(CharacterMovement movement)
    {
        float originalSpeed = movement.speed;
        movement.speed *= boostMultiplier;

        yield return new WaitForSeconds(boostDuration);

        movement.speed = originalSpeed;
    }
}
