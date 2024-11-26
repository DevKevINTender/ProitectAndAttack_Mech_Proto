using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneContainerAccessor : MonoBehaviour
{
   private static DiContainer _sceneContainer;

    private void Awake()
    {   
        // �������� ������� �������� �����
        SceneContext sceneContext = FindObjectOfType<SceneContext>();
        if (sceneContext != null)
        {
            // �������� ��������� Scene �� ��������� �����
            _sceneContainer = sceneContext.Container;
        }
    }

    public static DiContainer SceneContainer
    {
        get { return _sceneContainer; }
    }
}