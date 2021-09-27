using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueDuo
{
    public string[] names;
    public Sprite[] charIcons;

    [TextArea(3, 10)]
    public string[] sentences;

    // Start is called before the first frame update

}
