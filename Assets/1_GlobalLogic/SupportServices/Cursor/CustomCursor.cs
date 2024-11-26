using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    private Vector3 cursorPosition;

    private Animation anim;

    void Start()
    {
        anim = GetComponentInChildren<Animation>();
#if UNITY_EDITOR
        Cursor.visible = false; // �������� ������ ���� � ���������
#endif
    }

    void Update()
    {
        if(Camera.main)
        {
            // �������� ������� ������� ������� � ������� �����������
            cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // ������������� ������� ������� ������ ������� �������, �� ��������� z ���������� �������
            transform.position = new Vector3(cursorPosition.x, cursorPosition.y, transform.position.z);

            if (Input.GetMouseButtonDown(0))
            {
                anim?.Play("Click"); // ��������� ��������
            }
        }
    }
}
