using UniRx;
using UnityEngine;

public class GunDirectionPanel: MonoBehaviour
{
    public ReactiveProperty<Vector3> CurrentDirection = new();
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            CurrentDirection.Value = Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            CurrentDirection.Value = Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            CurrentDirection.Value = Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            CurrentDirection.Value = Vector3.left;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CurrentDirection.Value = Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CurrentDirection.Value = Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CurrentDirection.Value = Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CurrentDirection.Value = Vector3.left;
        }
    }

}