using UnityEngine;
using Zenject;
using UniRx;
using DG.Tweening;

public class SessionManager : MonoBehaviour
{
    [Inject] private SessionStateMachine _stateMachine;
    [Inject] private IAudioService _audioService;
    [Inject] private IEventService _eventService;


    public void Start()
    {
        DOTween.SetTweensCapacity(2000, 200);
        _stateMachine.SetState<SupportServiceStartState>();
        _audioService.PlayAudio(AudioEnum.BackGroundMusic, true, AudioUnitDataView.AudioType.Music);

        _eventService.ObserveEvent<OnFinishSession>().Subscribe(OnFinishSession).AddTo(this);
        _eventService.ObserveEvent<OnLoseSession>().Subscribe(OnLoseSession).AddTo(this);
        _eventService.ObserveEvent<OnToMenu>().Subscribe(OnToMenu).AddTo(this);
        _eventService.ObserveEvent<OnNextLevel>().Subscribe(OnNextLevel).AddTo(this);
        _eventService.ObserveEvent<OnRestartLevel>().Subscribe(OnRestartLevel).AddTo(this);
    }

    public void OnFinishSession(OnFinishSession value)
    {
        _stateMachine.SetState<SessionFinishState>();
    }

    public void OnLoseSession(OnLoseSession value)
    {
        _stateMachine.SetState<SessionLoseState>();
    }

    public void OnToMenu(OnToMenu value)
    {
        LoaderSceneService.Instance.SetBufScene(GameScenes.MenuScene);
        _stateMachine.SetState<SessionEndState>();
    }

    public void OnNextLevel(OnNextLevel value)
    {
        LoaderSceneService.Instance.SetBufScene(GameScenes.SessionScene);
        _stateMachine.SetState<SessionEndState>();
    }

    public void OnRestartLevel(OnRestartLevel value)
    {
        LoaderSceneService.Instance.SetBufScene(GameScenes.SessionScene);
        _stateMachine.SetState<SessionEndState>();
    }

    private void OnApplicationQuit()
    {
        _stateMachine.SetState<SessionEndState>();
    }
}
