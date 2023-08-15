using UnityEngine;
using System.IO.Ports;

public class ArduinoToUnity : MonoBehaviour
{
    // 변수 선언
    public Transform j1_1, j1_2, j1_3, j2_1, j2_2, j2_3, j3_1, j3_2, j3_3, j4_1, j4_2, j4_3, j5_1, j5_2;
    public float speed = 6f;

    SerialPort data_stream = new SerialPort("COM6", 9600); // 포트값과 보트레이트값 입력(수정 필요)
    public string receivedstring; // 아두이노에서 받은 정보를 저장할 문자열
    void Start()
    {
        data_stream.Open(); // Serial stream 초기화
    }

    void Update()
    {
        if (data_stream.IsOpen) // 시리얼 포트가 열려 있는지 확인
        {
            receivedstring = data_stream.ReadLine(); // 한줄씩 입력받기
            string[] datas = receivedstring.Split(','); // 아두이노 시리얼 포트에 나온 값들을 ','기준으로 split

            // 문자열을 실수형으로 변경, 그 후 각도를 나타내기 위해 정수형으로 반올림연산
            // 손가락 3개의 접어지는 각도를 각각 계산
            int recv_ang5 = Mathf.RoundToInt(float.Parse(datas[4])); // pin1값
            int recv_ang1 = Mathf.RoundToInt(float.Parse(datas[3])); // pin2값
            int recv_ang2 = Mathf.RoundToInt(float.Parse(datas[2])); // pin3값
            int recv_ang3 = Mathf.RoundToInt(float.Parse(datas[1])); // pin4값
            int recv_ang4 = Mathf.RoundToInt(float.Parse(datas[0])); // pin5값

            // 손가락 회전
            //엄지
            j5_1.transform.localEulerAngles = new Vector3(-recv_ang5, 0, 0); // j5_1의 회전
            j5_2.transform.localEulerAngles = new Vector3(j5_1.transform.localEulerAngles.z - recv_ang5, 0, 0); // j5_2의 회전

            //검지
            j1_1.transform.localEulerAngles = new Vector3(0, recv_ang1, 0); // j2_1의 회전
            j1_2.transform.localEulerAngles = new Vector3(0, j1_1.transform.localEulerAngles.z + recv_ang1, 0); // j1_1의 회전
            j1_3.transform.localEulerAngles = new Vector3(0, j1_2.transform.localEulerAngles.z + recv_ang1, 0); // j1_2의 회전

            //중지
            j2_1.transform.localEulerAngles = new Vector3(0, recv_ang2, 0); // j3_1의 회전
            j2_2.transform.localEulerAngles = new Vector3(0, j2_1.transform.localEulerAngles.z + recv_ang2, 0); // j2_1의 회전
            j2_3.transform.localEulerAngles = new Vector3(0, j2_2.transform.localEulerAngles.z + recv_ang2, 0); // j2_2의 회전

            //약지
            j3_1.transform.localEulerAngles = new Vector3(0, recv_ang3, 0); // j3_1의 회전
            j3_2.transform.localEulerAngles = new Vector3(0, j3_1.transform.localEulerAngles.z + recv_ang3, 0); // j3_1의 회전
            j3_3.transform.localEulerAngles = new Vector3(0, j3_2.transform.localEulerAngles.z + recv_ang3, 0); // j3_2의 회전

            //소지
            j4_1.transform.localEulerAngles = new Vector3(0, recv_ang4, 0); // j3_1의 회전
            j4_2.transform.localEulerAngles = new Vector3(0, j4_1.transform.localEulerAngles.z + recv_ang4, 0); // j4_1의 회전
            j4_3.transform.localEulerAngles = new Vector3(0, j4_2.transform.localEulerAngles.z + recv_ang4, 0); // j4_2의 회전
        }
    }

    void OnApplicationQuit()
    {
        if (data_stream != null && data_stream.IsOpen)
        {
            data_stream.Close();
        }
    }
}