using UnityEngine;

public class AimPointView: MonoBehaviour
{
    private Transform CurrentAimPointTargetTrn;
    public void Update()
    {
        UpdateAimPointPos();
    }
    private void UpdateAimPointPos()
    {
        if (CurrentAimPointTargetTrn != null)
        {
            transform.position = CurrentAimPointTargetTrn.position;
        }
        else
        {
            transform.position = transform.parent.right * 5;
        }
    }

    public void ChangeAimPoint(Transform AimPointTargetTrn)
    {
        CurrentAimPointTargetTrn = AimPointTargetTrn;
        if (CurrentAimPointTargetTrn != null)
            transform.right = Vector3.right;
    }
}
