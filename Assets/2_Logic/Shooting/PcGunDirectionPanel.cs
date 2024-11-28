using UniRx;
using UnityEngine;

public interface IGunDirectionPanel
{
    public ReactiveProperty<Vector3> GetLeftCurrentDirection { get; }
    public ReactiveProperty<Vector3> GetRightCurrentDirection { get; }
}

public class PcGunDirectionPanel: MonoBehaviour, IGunDirectionPanel
{
    private ReactiveProperty<Vector3> RightCurrentDirection = new();
    private ReactiveProperty<Vector3> LeftCurrentDirection = new();

    public ReactiveProperty<Vector3> GetLeftCurrentDirection => LeftCurrentDirection;
    public ReactiveProperty<Vector3> GetRightCurrentDirection => RightCurrentDirection;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            LeftCurrentDirection.Value = Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            LeftCurrentDirection.Value = Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            LeftCurrentDirection.Value = Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            LeftCurrentDirection.Value = Vector3.left;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            RightCurrentDirection.Value = Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            RightCurrentDirection.Value = Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightCurrentDirection.Value = Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RightCurrentDirection.Value = Vector3.left;
        }
    }

}