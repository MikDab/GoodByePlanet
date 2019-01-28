using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Float Variable", menuName = "Variables/Float")]
[System.Serializable]
public class FloatVariable : ScriptableObject {

    [SerializeField]
    private float value;

    public float Value
    {
        get { return value; }
        set { this.value = value; }
    }

}
