using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Animator animator;
    private bool isGameOver = false;
    public float jumpPower = 10f;
    public Rigidbody2D rb;

    // Biến cho Double Jump
    public int maxJumps = 2;       // Số lần nhảy tối đa (Nhảy đơn + Nhảy kép)
    private int currentJumps = 0;   // Số lần nhảy đã dùng
    private float Move;

    void Start()
    {
        animator = GetComponent<Animator>(); // Lấy Animator
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        // Nếu Game Over thì không cho nhân vật di chuyển nữa
        if (isGameOver)
        {
            animator.SetBool("isMoving", false);
            return;
        }

        Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        // 2. LOGIC NHẢY KÉP (DOUBLE JUMP)
        // Chỉ cho phép nhảy nếu currentJumps < maxJumps
        if (Input.GetButtonDown("Jump") && currentJumps < maxJumps)
        {
            // Reset vận tốc Y về 0 trước khi nhảy để đảm bảo lực nhảy nhất quán
            rb.velocity = new Vector2(rb.velocity.x, 0f);

            // Thực hiện nhảy với lực jumpPower
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);

            // Tăng số lần nhảy đã thực hiện
            currentJumps++;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra xem nhân vật có chạm vào mặt đất (có tag "Ground") hay không
        // *Bạn phải đảm bảo rằng nền đất của bạn đã được đặt Tag là "Ground" trong Unity!*
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Reset số lần nhảy về 0 khi chạm đất
            currentJumps = 0;
        }
    }
}
