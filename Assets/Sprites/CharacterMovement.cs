using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Animator animator;
    private bool isGameOver = false;

    void Start()
    {
        animator = GetComponent<Animator>(); // Lấy Animator
    }

    void Update()
    {
        // Nếu Game Over thì không cho nhân vật di chuyển nữa
        if (isGameOver)
        {
            animator.SetBool("isMoving", false);
            return;
        }



        float moveHorizontal = Input.GetAxis("Horizontal");
        bool isMoving = moveHorizontal != 0;
        animator.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            transform.position += new Vector3(moveHorizontal * speed * Time.deltaTime, 0f, 0f);
        }
    }

    // 👉 Hàm được gọi khi Game Over (từ ScoreManager hoặc script khác)
    public void GameOver()
    {
        isGameOver = true; // Dừng nhân vật
        animator.SetBool("isMoving", false);

        // Dừng toàn bộ chuyển động trong game
        Time.timeScale = 0f;

    }
}
