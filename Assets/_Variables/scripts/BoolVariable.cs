using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bool Variable", menuName = "Variables/Bool")]
[System.Serializable]
public class BoolVariable : ScriptableObject {

    [SerializeField]
    private bool value;

    public bool Value
    {
        get { return value; }
        set { this.value = value; }
    }
}
