using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{
    public Text text;
    public StringVariable stringText;

    // Update is called once per frame
    void Update()
    {
        text.text = stringText.Value;
    }
}
