using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour {

    public GameEvent Event;
    public UnityEvent Response;

    private void OnEnable()
    {
        if (Event != null)
        {
            Event.RegisterListener(this);
        }
    }

    private void OnDisable()
    {
        if (Event != null)
        {
            Event.UnregisterListener(this);
        }
    }

    public void OnEventRaised() {

        Response.Invoke();

    }

    public void ReplaceEvent(GameEvent newEvent) {

        if (Event != null)
        {
            Event.UnregisterListener(this);
        }

        Event = newEvent;
        Response = new UnityEvent();

        Event.RegisterListener(this);
    }

}
