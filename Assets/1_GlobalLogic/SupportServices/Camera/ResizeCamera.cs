using UnityEngine;

public class ResizeCamera : MonoBehaviour
{
    // ������� �������� ������ � �������� ��� ������ �������
    public float targetWidth = 1080f;

    void Start()
    {
        // �������� ������� ������ ������
        float screenHeight = Screen.height;
        float screenWidth = Screen.width;

        // ������������ ����� ������ ������, �������� �������� ������
        float targetHeight = targetWidth / screenWidth * screenHeight;
        float resiltSize = targetHeight / 200f; ;
        Camera.main.orthographicSize = resiltSize < 10f ? 10f : resiltSize;

        // ���� �� ����������� perspective ������, ����������������� ��������� ������:
        // Camera.main.fieldOfView = 2f * Mathf.Atan(targetHeight / (2f * Camera.main.transform.position.z)) * Mathf.Rad2Deg;
    }
}
