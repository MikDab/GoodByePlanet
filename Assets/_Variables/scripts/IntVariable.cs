using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Int Variable", menuName = "Variables/Int")][System.Serializable]
public class IntVariable : ScriptableObject {

    [SerializeField]
    private int value = 0;

    public int Value {

        get { return value; }
        set { this.value = value; }

    }

}
