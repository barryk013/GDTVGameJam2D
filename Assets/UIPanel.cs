using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    public Selectable DefaultSelection;
    public void SetActive(bool active)
    {
        if (DefaultSelection != null) { DefaultSelection.Select(); }
        gameObject.SetActive(active);
    }
}
