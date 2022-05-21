using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSpecs : MonoBehaviour
{   
    public ItemScriptableObject item;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public Sprite itemImage;
    void Start()
    {
        nameText.text = item.itemName;
        descriptionText.text = item.description;
    }


}
