using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "String Variable", menuName ="Variables/String")][System.Serializable]
public class StringVariable : ScriptableObject {

        [SerializeField]
        private string value = "";

        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
}
