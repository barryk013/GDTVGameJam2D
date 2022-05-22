using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName ="Story Text")]
public class TextScriptableObject : ScriptableObject
{
    [Multiline(40)]
    public string Text;
    
}

