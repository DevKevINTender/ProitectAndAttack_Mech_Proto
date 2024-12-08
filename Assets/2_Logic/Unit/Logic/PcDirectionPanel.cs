using System;
using UnityEngine;

public class PcDirectionPanel : MonoBehaviour
{
    public Action<Vector3> NewCurrentDirectionAction;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            NewCurrentDirectionAction?.Invoke(Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            NewCurrentDirectionAction?.Invoke(Vector3.down);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            NewCurrentDirectionAction?.Invoke(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            NewCurrentDirectionAction?.Invoke(Vector3.left);
        }
    }

}