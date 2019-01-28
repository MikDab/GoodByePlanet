using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject {

    [Tooltip("The description describes what the event is used for and is for inspector use only")][Multiline(7)]
    public string Description;

    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise() {

        for (int i = listeners.Count - 1; i >= 0; i--) {

            listeners[i].OnEventRaised();

        }

    }

    public void RegisterListener(GameEventListener listener) {

        listeners.Add(listener);

    }

    public void UnregisterListener(GameEventListener listener) {

        listeners.Remove(listener);

    }

}
