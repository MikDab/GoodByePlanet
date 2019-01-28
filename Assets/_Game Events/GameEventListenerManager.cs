using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventListenerManager : MonoBehaviour {

    // you can choose what type of events the object should receive when it is created
    public enum eventTypes {

        OnClick, OnMouseEnter, OnMouseExit

    }

    // this is where you input the events in the inspector
    public List<eventTypes> LocalEventNames;

    // this is where you can input global events in inspector
    public List<GameEvent> GlobalEvents = new List<GameEvent>();

    // a merged list of all events
    public Dictionary<string, GameEventListener> AllEvents = new Dictionary<string, GameEventListener>();

    void Awake()
    {
        // creating and registering new event based on inputs in inspector
        foreach (eventTypes type in LocalEventNames) {
            AddNewEventAndListener(type.ToString());
        }

        // just adding the global events to a single list
        foreach (GameEvent eve in GlobalEvents)
        {
            AddNewListener(eve);
        }
    }

    // this method returns the GameEventListener by the name of the needed event
    // so that objects could register themselves programatically
    public GameEventListener ReturnEventListenerByName(string eventName)
    {
        GameEventListener listener;
        AllEvents.TryGetValue(eventName, out listener);
        return listener;
    }

    // method creates a new GameEventListener component, creates a new event for it, sets its name
    public void AddNewEventAndListener(string eventName)
    {
        GameEventListener listener = this.gameObject.AddComponent(typeof(GameEventListener)) as GameEventListener;
        GameEvent newEvent = ScriptableObject.CreateInstance(typeof(GameEvent)) as GameEvent;
        newEvent.name = eventName;
        listener.ReplaceEvent(newEvent);
        AllEvents.Add(eventName, listener);
    }


    public void AddNewListener(GameEvent newEvent)
    {
        GameEventListener listener = this.gameObject.AddComponent(typeof(GameEventListener)) as GameEventListener;
        listener.ReplaceEvent(newEvent);
        AllEvents.Add(newEvent.name, listener);
    }

    // raises all events on this object by the event name programmatically
    public void RaiseEventsByName(string EventName) {

        foreach (KeyValuePair<string, GameEventListener> pair in AllEvents) {

            if (pair.Key == EventName) {

                pair.Value.Event.Raise();
            }
        }
    }
}
