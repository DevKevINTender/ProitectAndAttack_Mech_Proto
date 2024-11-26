using UnityEngine;
using UnityEngine.EventSystems;

public class MoveToPositionComponent : MonoBehaviour
{
    private Vector3 _movePos;
    private float _speedDelta;

    public void Activate(Vector3 movePos, float speedDelta)
    {
        _speedDelta = speedDelta;
        _movePos = movePos;
    }

    public void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _movePos, _speedDelta * Time.fixedDeltaTime);
    }
    public void Deactivate()
    {
        _speedDelta = 0;
    }
}


