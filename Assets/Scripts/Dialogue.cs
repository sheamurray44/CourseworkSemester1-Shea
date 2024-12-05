using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class defines the dialogue, allowing a name to be assigned, expansion of the text area and allowing the dialogue sentences to be typed.

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;
}
