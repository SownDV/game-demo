using System.Collections;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Di chuyển & Nhảy")]
    public float speed = 5.0f;
    public float jumpPower = 10f;
    public Rigidbody2D rb;
    private Animator animator;
    private bool isGameOver = false;
    private float Move;

    [Header("Double Jump")]
    public int maxJumps = 2;       // Số lần nhảy tối đa (nhảy đơn + nhảy kép)
    private int currentJumps = 0;  // Số lần nhảy đã dùng

    [Header("Dash Settings")]
    public float dashSpeed = 20f;        // tốc độ dash
    public float dashDuration = 0.15f;   // thời gian dash (giây)
    public float dashCooldown = 1f;      // thời gian hồi dash (giây)
    private bool isDashing = false;      // đang dash hay không
    private bool dashOnCooldown = false; // đang chờ hồi dash
    private bool facingRight = true;     // hướng nhân vật

    void Start()
    {
        animator = GetComponent<Animator>();
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Nếu Game Over thì không di chuyển
        if (isGameOver)
        {
            animator.SetBool("isMoving", false);
            return;
        }

        // Nếu đang dash thì bỏ qua input di chuyển thường
        if (isDashing) return;

        // Di chuyển trái phải
        Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        // Cập nhật hướng nhân vật
        if (Move > 0 && !facingRight)
            Flip();
        else if (Move < 0 && facingRight)
            Flip();

        // Animation di chuyển
        animator.SetBool("isMoving", Move != 0);

        // Nhảy / Double Jump
        if (Input.GetButtonDown("Jump") && currentJumps < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            currentJumps++;
        }

        // Dash bằng phím Shift
        if (Input.GetKeyDown(KeyCode.LeftShift) && !dashOnCooldown && !isDashing)
        {
            StartCoroutine(DoDash());
        }
    }

    private IEnumerator DoDash()
    {
        isDashing = true;
        dashOnCooldown = true;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        // Xác định hướng dash (theo hướng đang quay mặt)
        float dashDirection = facingRight ? 1f : -1f;
        rb.velocity = new Vector2(dashDirection * dashSpeed, 0f);

        // Có thể thêm hiệu ứng ở đây 
        yield return new WaitForSeconds(dashDuration);

        // Kết thúc dash, khôi phục trạng thái
        rb.gravityScale = originalGravity;
        rb.velocity = new Vector2(0, 0);
        isDashing = false;

        // Đợi cooldown
        yield return new WaitForSeconds(dashCooldown);
        dashOnCooldown = false;
    }

    // Đổi hướng nhân vật
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Khi chạm đất reset số lần nhảy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            currentJumps = 0;
        }
    }

    // Khi Game Over
    public void GameOver()
    {
        isGameOver = true;
        animator.SetBool("isMoving", false);
        Time.timeScale = 0f;
    }
}
