using UnityEngine;

public class DontDropObject : MonoBehaviour
{
    private Transform objectTransform; // ��� ������Ʈ�� Transform ������Ʈ
    public Vector3 initialPosition = new Vector3(20f, 5f, 30f); // �ʱ� ��ġ

    private void Start()
    {
        objectTransform = transform; // �ش� ��ũ��Ʈ�� ������ ������Ʈ�� Transform ������Ʈ�� ���
        objectTransform.position = initialPosition; // �ʱ� ��ġ�� ����
    }

    private void Update()
    {
        float yPosition = objectTransform.position.y; // ������Ʈ�� ���� y�� ��ġ
        Debug.Log("Y Position: " + yPosition);

        if (yPosition < -10)
        {
            objectTransform.position = initialPosition; // ������� ���� �ʱ� ��ġ�� �̵�
        }
    }
}
