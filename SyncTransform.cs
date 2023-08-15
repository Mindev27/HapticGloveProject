using UnityEngine;

public class SyncTransform : MonoBehaviour
{
    public Transform emptyObject;
    public Transform targetObject;

    void Update()
    {
        // 빈 오브젝트의 위치와 회전값을 일반 오브젝트에 적용
        emptyObject.position = targetObject.position;
        emptyObject.rotation = targetObject.rotation;
    }
}
