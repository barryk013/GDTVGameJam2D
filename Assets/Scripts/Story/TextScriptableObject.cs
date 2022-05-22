using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName ="Story Text")]
public class TextScriptableObject : ScriptableObject
{
    [Range(0f, 20f)]
    public float LettersPerSecond = 2;
    [Multiline(40)]
    public string Text;
    
}

