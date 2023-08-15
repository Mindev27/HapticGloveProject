using UnityEngine;

public class temporaryObjectController : MonoBehaviour
{
    public float moveSpeed = 5f; // ������ �ӵ�

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal"); // ȭ��ǥ Ű�� ���� �Է°�
        float moveZ = Input.GetAxis("Vertical"); // ȭ��ǥ Ű�� ���� �Է°�

        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;
        Vector3 velocity = moveDirection * moveSpeed;

        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }
}
