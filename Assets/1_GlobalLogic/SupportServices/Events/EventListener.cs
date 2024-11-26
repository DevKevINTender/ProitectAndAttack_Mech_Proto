using UniRx;
using Zenject;
using UnityEngine;
using System;

public class EventListener : MonoBehaviour
{
    [Inject] private EventService _eventService;
    private IDisposable item;

    private void Start()
    {
        // Подписываемся на события
        item = _eventService.ObserveEvent<EventDataA>().Subscribe(OnEventAReceived).AddTo(this);
        _eventService.ObserveEvent<EventDataB>().Subscribe(OnEventBReceived).AddTo(this);

        // Публикуем события
        _eventService.PublishEvent(new EventDataA { MessageA = "Hello from Event A!", ValueA = 42 });
        _eventService.PublishEvent(new EventDataB { MessageB = "Greetings from Event B!", ValueB = 3.14f });

        // Отписка.
        item?.Dispose();
    }

    private void OnEventAReceived(EventDataA eventData)
    {
        // Обрабатываем событие A
        Debug.Log($"Received Event A - Message: {eventData.MessageA}, Value: {eventData.ValueA}");
    }

    private void OnEventBReceived(EventDataB eventData)
    {
        // Обрабатываем событие B
        Debug.Log($"Received Event B - Message: {eventData.MessageB}, Value: {eventData.ValueB}");
    }
}

public class EventDataA
{
    public string MessageA { get; set; }
    public int ValueA { get; set; }
}

public class EventDataB
{
    public string MessageB { get; set; }
    public float ValueB { get; set; }
}
