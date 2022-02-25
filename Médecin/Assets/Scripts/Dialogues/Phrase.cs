using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Phrase
{
    public TypeLigne type;
    [TextArea(3, 10)] public string phrase;
}
