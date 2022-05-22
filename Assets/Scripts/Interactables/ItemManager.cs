using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject nameCanvas;
    public GameObject descriptionCanvas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        ShowDescription();
    }

    private void OnTriggerExit2D(Collider2D other) {
        HideDescription();
    }

    public void ShowDescription()
    {
        nameCanvas.SetActive(true);
    }
    public void HideDescription()
    {
        nameCanvas.SetActive(false);
    }


}
