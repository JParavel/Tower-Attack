using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Event System/GameEvent", order = 0)]
public class GameEvent : ScriptableObject
{

    private List<GameListener> _listeners = new List<GameListener>();
    public List<GameListener> listeners { get { return _listeners; } }
    private bool _canceled;
    public bool canceled { get { return _canceled; } set { _canceled = value; } }
    private bool _running;
    public bool running { get { return _running; } }

    private void Start() {
        _running = false;
        _canceled = false;
    }

    public void RegisterListener(GameListener listener)
    {
        if (_listeners.Contains(listener)) return;

        _listeners.Add(listener);
    }

    public void UnregisterListener(GameListener listener)
    {
        if (!_listeners.Contains(listener)) return;

        _listeners.Remove(listener);
    }

    public bool Execute()
    {
        if (_running) {
            Debug.LogWarning("An event call was executed before the lastone was done ["+ this+"]");
        }

        _canceled = false;
        _running = true;

        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i].OnEvent(this);
        }

        _running = false;

        return !_canceled;
    }

}
