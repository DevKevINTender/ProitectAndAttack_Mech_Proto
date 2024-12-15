using UnityEngine;

public class UnitMovePointMarker : Marker
{
    public UnitMovePointMarker UpMarker;
    public UnitMovePointMarker DownMarker;
    public UnitMovePointMarker RightMarker;
    public UnitMovePointMarker LeftMarker;


    // Размер шага (расстояние в клетках для Raycast)
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

        // Проверяем, был ли найден объект и имеет ли он компонент UnitMovePointMarker
        if (hit.collider != null)
        {
            UnitMovePointMarker hitMarker = hit.collider.GetComponent<UnitMovePointMarker>();

            // Убедимся, что это не сам объект, с которого мы вызвали метод
            if (hitMarker != null)
            {
                return hitMarker; // Возвращаем первый найденный объект
            }
        }
        return null;
    }
}
