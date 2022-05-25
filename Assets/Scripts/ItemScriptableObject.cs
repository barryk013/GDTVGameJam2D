using UnityEngine;

[CreateAssetMenu(fileName = "ItemScriptableObject", menuName = "ScriptableObjects/Item")]
public class ItemScriptableObject : ScriptableObject
{
    public string Name;
    [TextArea(20,40)]
    public string Description;
    public Sprite ItemSprite;

}
