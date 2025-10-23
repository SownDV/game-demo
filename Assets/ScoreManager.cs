using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    private float remainingTime;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public CharacterMovement player;

    private bool isGameOver = false; // 👈 tránh gọi GameOver nhiều lần

    public static void AddScore(int amount)
    {
        score += amount;
    }

    void Start()
    {
        remainingTime = 30f; // để 3f khi test, còn 30f là thời gian thật
        StartCoroutine(CountdownTimer());
    }

    void Update()
    {
        // Hiển thị thời gian & điểm
        scoreText.text = $"Score: {score} | Time: {Mathf.CeilToInt(remainingTime)}";

        // Cho phép restart khi Game Over
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private IEnumerator CountdownTimer()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }

        GameOver();
    }

    private void GameOver()
    {
        if (isGameOver) return; // 👈 tránh bị gọi lại nếu coroutine chạy trễ

        isGameOver = true;
        gameOverPanel.SetActive(true);
        gameOverText.text = $"Game Over!\nScore: {score}";

        if (player != null)
        {
            player.GameOver();
        }

        Time.timeScale = 0f;

    }
}
