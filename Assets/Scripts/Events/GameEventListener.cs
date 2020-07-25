using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public GameEvent @event;
    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent response;

    private void OnEnable()
    {
        @event.RegisterListener(this);
    }

    private void OnDisable()
    {
        @event.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        response.Invoke();
    }
}