using UnityEngine;

public class temporaryObjectController : MonoBehaviour
{
    public float moveSpeed = 5f; // 움직임 속도

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal"); // 화살표 키의 가로 입력값
        float moveZ = Input.GetAxis("Vertical"); // 화살표 키의 세로 입력값

        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;
        Vector3 velocity = moveDirection * moveSpeed;

        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }
}
