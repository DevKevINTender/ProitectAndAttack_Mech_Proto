using System;
using UnityEngine;

public class WallDetectComponent : MonoBehaviour
{
    public Action WallDetectedAction;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out WallComponent hpComponent))
        {
            WallDetectedAction.Invoke();
        }
    }
}

