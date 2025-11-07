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
    public TextMeshProUGUI timerText;

    private bool isGameOver = false; // 👈 tránh gọi GameOver nhiều lần

    public static void AddScore(int amount)
    {
        score += amount;
    }
    // FORK
    void Start()
    {
        remainingTime = 60f; // để 3f khi test, còn 30f là thời gian thật
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

        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0)
        {
            remainingTime = 0;
            GameOver();
        }

        if (timerText != null)
        {

            timerText.text = "Time: " + Mathf.CeilToInt(remainingTime);
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

    public void AddTime(float value)
    {
        remainingTime += value;

        // Giới hạn để không âm hoặc quá cao
        remainingTime = Mathf.Clamp(remainingTime, 0, 999);

        if (value > 0)
            Debug.Log("⏱️ + " + value + " giây!");
        else
            Debug.Log("⏱️ - " + Mathf.Abs(value) + " giây!");
    }
}
