using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Line
{
    [TextArea(2, 5)]
    public string text;
}

public class Conversation : MonoBehaviour
{
    public Line[] lines; 

}
