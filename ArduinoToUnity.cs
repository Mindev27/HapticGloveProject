using UnityEngine;
using System.IO.Ports;

public class ArduinoToUnity : MonoBehaviour
{
    // ���� ����
    public Transform j1_1, j1_2, j1_3, j2_1, j2_2, j2_3, j3_1, j3_2, j3_3, j4_1, j4_2, j4_3, j5_1, j5_2;
    public float speed = 6f;

    SerialPort data_stream = new SerialPort("COM6", 9600); // ��Ʈ���� ��Ʈ����Ʈ�� �Է�(���� �ʿ�)
    public string receivedstring; // �Ƶ��̳뿡�� ���� ������ ������ ���ڿ�
    void Start()
    {
        data_stream.Open(); // Serial stream �ʱ�ȭ
    }

    void Update()
    {
        if (data_stream.IsOpen) // �ø��� ��Ʈ�� ���� �ִ��� Ȯ��
        {
            receivedstring = data_stream.ReadLine(); // ���پ� �Է¹ޱ�
            string[] datas = receivedstring.Split(','); // �Ƶ��̳� �ø��� ��Ʈ�� ���� ������ ','�������� split

            // ���ڿ��� �Ǽ������� ����, �� �� ������ ��Ÿ���� ���� ���������� �ݿø�����
            // �հ��� 3���� �������� ������ ���� ���
            int recv_ang5 = Mathf.RoundToInt(float.Parse(datas[4])); // pin1��
            int recv_ang1 = Mathf.RoundToInt(float.Parse(datas[3])); // pin2��
            int recv_ang2 = Mathf.RoundToInt(float.Parse(datas[2])); // pin3��
            int recv_ang3 = Mathf.RoundToInt(float.Parse(datas[1])); // pin4��
            int recv_ang4 = Mathf.RoundToInt(float.Parse(datas[0])); // pin5��

            // �հ��� ȸ��
            //����
            j5_1.transform.localEulerAngles = new Vector3(-recv_ang5, 0, 0); // j5_1�� ȸ��
            j5_2.transform.localEulerAngles = new Vector3(j5_1.transform.localEulerAngles.z - recv_ang5, 0, 0); // j5_2�� ȸ��

            //����
            j1_1.transform.localEulerAngles = new Vector3(0, recv_ang1, 0); // j2_1�� ȸ��
            j1_2.transform.localEulerAngles = new Vector3(0, j1_1.transform.localEulerAngles.z + recv_ang1, 0); // j1_1�� ȸ��
            j1_3.transform.localEulerAngles = new Vector3(0, j1_2.transform.localEulerAngles.z + recv_ang1, 0); // j1_2�� ȸ��

            //����
            j2_1.transform.localEulerAngles = new Vector3(0, recv_ang2, 0); // j3_1�� ȸ��
            j2_2.transform.localEulerAngles = new Vector3(0, j2_1.transform.localEulerAngles.z + recv_ang2, 0); // j2_1�� ȸ��
            j2_3.transform.localEulerAngles = new Vector3(0, j2_2.transform.localEulerAngles.z + recv_ang2, 0); // j2_2�� ȸ��

            //����
            j3_1.transform.localEulerAngles = new Vector3(0, recv_ang3, 0); // j3_1�� ȸ��
            j3_2.transform.localEulerAngles = new Vector3(0, j3_1.transform.localEulerAngles.z + recv_ang3, 0); // j3_1�� ȸ��
            j3_3.transform.localEulerAngles = new Vector3(0, j3_2.transform.localEulerAngles.z + recv_ang3, 0); // j3_2�� ȸ��

            //����
            j4_1.transform.localEulerAngles = new Vector3(0, recv_ang4, 0); // j3_1�� ȸ��
            j4_2.transform.localEulerAngles = new Vector3(0, j4_1.transform.localEulerAngles.z + recv_ang4, 0); // j4_1�� ȸ��
            j4_3.transform.localEulerAngles = new Vector3(0, j4_2.transform.localEulerAngles.z + recv_ang4, 0); // j4_2�� ȸ��
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