using UnityEngine;

public class DontDropObject : MonoBehaviour
{
    private Transform objectTransform; // 대상 오브젝트의 Transform 컴포넌트
    public Vector3 initialPosition = new Vector3(20f, 5f, 30f); // 초기 위치

    private void Start()
    {
        objectTransform = transform; // 해당 스크립트가 부착된 오브젝트의 Transform 컴포넌트를 사용
        objectTransform.position = initialPosition; // 초기 위치로 설정
    }

    private void Update()
    {
        float yPosition = objectTransform.position.y; // 오브젝트의 현재 y축 위치
        Debug.Log("Y Position: " + yPosition);

        if (yPosition < -10)
        {
            objectTransform.position = initialPosition; // 재생성을 위해 초기 위치로 이동
        }
    }
}
