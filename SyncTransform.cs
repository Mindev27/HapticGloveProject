using UnityEngine;

public class SyncTransform : MonoBehaviour
{
    public Transform emptyObject;
    public Transform targetObject;

    void Update()
    {
        // �� ������Ʈ�� ��ġ�� ȸ������ �Ϲ� ������Ʈ�� ����
        emptyObject.position = targetObject.position;
        emptyObject.rotation = targetObject.rotation;
    }
}
