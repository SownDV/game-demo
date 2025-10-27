using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Biến speed quyết định tốc độ của nhân vật là một số thực, và có thể được truy cập từ giao diện Unity Editor.
    public float speed = 5.0f;
    // Update được gọi ở mỗi khung hình
    void Update()
    {
        // Lấy đầu vào từ bàn phím, ở đây là phím chiều ngang, phím A/D hoặc mũi tên trái/phải
        float horizontalInput = Input.GetAxis("Horizontal");

        // Tính vị trí mới của đối tượng dựa trên đầu vào và tốc độ
        float moveHorizontal = horizontalInput * speed * Time.deltaTime;

        // Cập nhật ví trí mới của đối tượng chuẩn bị để được render ở khung hình tiếp theo
        transform.position = new Vector2(transform.position.x + moveHorizontal, transform.position.y);
    }
}
