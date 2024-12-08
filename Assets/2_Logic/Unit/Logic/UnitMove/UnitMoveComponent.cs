using System;
using System.Collections;
using UnityEngine;

public class UnitMoveComponent : MonoBehaviour
{
    public Action<UnitMovePointMarker> DetectNewUnitMovePointMarkerAction;
    private Coroutine _moveCor;
    public Transform test;

    public void MoveToPoint(Transform pointTargetTrn)
    {
        if (_moveCor != null) StopCoroutine(_moveCor);
        _moveCor = StartCoroutine(MoveCor(pointTargetTrn));
    }

    public IEnumerator MoveCor(Transform pointTargetTrn)
    {

        while (Vector3.Distance(transform.position, pointTargetTrn.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointTargetTrn.position, Time.deltaTime * 10);
            yield return null;
        }
        transform.position = pointTargetTrn.position;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out UnitMovePointMarker result))
        {
            DetectNewUnitMovePointMarkerAction?.Invoke(result);
            test = result.transform;
        }
    }
}
