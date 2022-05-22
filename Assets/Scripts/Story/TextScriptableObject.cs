using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName ="Story Text")]
public class TextScriptableObject : ScriptableObject
{
    public string Text;
    public float LettersPerSecond = 2;
}

