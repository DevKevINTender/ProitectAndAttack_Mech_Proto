using UnityEngine;

public class UnitMovePointMarker : Marker
{
    public UnitMovePointMarker UpMarker;
    public UnitMovePointMarker DownMarker;
    public UnitMovePointMarker RightMarker;
    public UnitMovePointMarker LeftMarker;


    // ������ ���� (���������� � ������� ��� Raycast)
    private float raycastDistance = 8;

    public void Start()
    {
        UpMarker = CheckMarker(Vector3.up);
        DownMarker = CheckMarker(Vector3.down);
        RightMarker = CheckMarker(Vector3.right);
        LeftMarker = CheckMarker(Vector3.left);
    }

    public UnitMovePointMarker CheckMarker(Vector3 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + dir, dir, raycastDistance, LayerMask.GetMask("MovePointMarker"));

        // ���������, ��� �� ������ ������ � ����� �� �� ��������� UnitMovePointMarker
        if (hit.collider != null)
        {
            UnitMovePointMarker hitMarker = hit.collider.GetComponent<UnitMovePointMarker>();

            // ��������, ��� ��� �� ��� ������, � �������� �� ������� �����
            if (hitMarker != null)
            {
                return hitMarker; // ���������� ������ ��������� ������
            }
        }
        return null;
    }
}
