using UnityEngine;

public class AutoBounceStart : MonoBehaviour
{
    public float moveSpeed = 5f; // 可以隨時調整速度

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // 隨機產生一個方向（避免完全垂直或水平，否則會死循環彈跳）
        float randomX = Random.Range(0.4f, 1f) * (Random.value > 0.5f ? 1 : -1);
        float randomY = Random.Range(0.4f, 1f) * (Random.value > 0.5f ? 1 : -1);
        Vector2 randomDirection = new Vector2(randomX, randomY).normalized;

        // 給予初始速度
        rb.velocity = randomDirection * moveSpeed;
    }
}
