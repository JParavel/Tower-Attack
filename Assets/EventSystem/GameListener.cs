using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameListener : MonoBehaviour
{
    [SerializeField] private GameEvent _gameEvent;
    public GameEvent gameEvent { get { return _gameEvent; } }
    [SerializeField] private UnityEvent<GameEvent> _onEvent;
    public void OnEvent(GameEvent gameEvent)
    {
        _onEvent.Invoke(gameEvent);
    }

    private void OnEnable()
    {
        _gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        _gameEvent.UnregisterListener(this);
    }

}
