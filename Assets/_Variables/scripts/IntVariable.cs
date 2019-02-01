using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Int Variable", menuName = "Variables/Int")][System.Serializable]
public class IntVariable : ScriptableObject {

    [SerializeField]
    private int value = 0;

    public int Value {

        get { return value; }
        set {
            if (this.value == value) return;

            this.value = value;

            OnVariableChange?.Invoke(this.value);
            if (Event != null)
                Event.Raise();
        }

    }

    public delegate void OnVariableChangeDelegate(int newVal);
    public event OnVariableChangeDelegate OnVariableChange;

    [Tooltip("Event to be called when the value of the variable changes")]
    public GameEvent Event;

}
