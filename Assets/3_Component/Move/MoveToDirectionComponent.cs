using UnityEngine;

public class MoveToDirectionComponent : MonoBehaviour
{
    private float _speedDelta;
    private Vector3 _targetDir;
    private Vector3 _moveDir;

    public void Activate(Vector3 targetDir, float speedDelta)
    {
        _speedDelta = speedDelta;
        _targetDir = targetDir;
        _moveDir = _targetDir - transform.position;
    }

    public void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _moveDir, _speedDelta * Time.fixedDeltaTime);
    }
    public void Deactivate()
    {
        _speedDelta = 0;
    }
}


