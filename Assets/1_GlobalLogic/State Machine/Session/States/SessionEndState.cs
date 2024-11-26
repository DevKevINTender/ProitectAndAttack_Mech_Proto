using Zenject;

public class SessionEndState : IBaseState
{

    public void Enter()
    {
        LoaderSceneService.Instance.LoadBufScene();
    }

    public void Exit()
    {

    }

    public void Update()
    {

    }

   
}

