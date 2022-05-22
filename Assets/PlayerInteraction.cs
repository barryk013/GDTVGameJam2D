using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private InputScriptableObject input;
    [SerializeField] private LayerMask itemLayer;
    [SerializeField] private LayerMask graveLayer;

    private Grave nearbyGrave = null;
    private ItemManager nearbyItem = null;

    private ItemManager itemInHand;


    private void OnEnable()
    {
        input.InteractionPerformed += OnInteractionPerformed;
        input.InteractionCanceled += OnInteractionCanceled;
        input.PickUpActionPerformed += OnItemPickUp;
    }
    private void OnDisable()
    {
        input.InteractionPerformed -= OnInteractionPerformed;
        input.InteractionCanceled -= OnInteractionCanceled;
        input.PickUpActionPerformed -= OnItemPickUp;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        int isItem = (int)Mathf.Pow(2, other.gameObject.layer) & itemLayer;
        int isGrave = (int)Mathf.Pow(2, other.gameObject.layer) & graveLayer;

        if (isItem != 0)
        {
            nearbyItem = other.GetComponent<ItemManager>();
        }
        if (isGrave != 0)
        {
            nearbyGrave = other.GetComponent<Grave>();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        int isItem = (int)Mathf.Pow(2, other.gameObject.layer) & itemLayer;
        int isGrave = (int)Mathf.Pow(2, other.gameObject.layer) & graveLayer;

        if (isItem != 0)
        {
            if(nearbyItem != null)
                nearbyItem.HideDescription();

            nearbyItem = null;
        }
        if (isGrave != 0)
        {
            if (nearbyGrave != null)
                nearbyGrave.InteractionCanceled();
            nearbyGrave = null;
        }
    }

    private void OnInteractionPerformed()
    {
        if (nearbyGrave == null)
            return;
        print("test");
        nearbyGrave.InteractionPerformed();
    }
    private void OnInteractionCanceled()
    {
        if (nearbyGrave == null)
            return;

        nearbyGrave.InteractionCanceled();
    }
    private void OnItemPickUp()
    {
        if (nearbyItem == null) return;

        if (itemInHand != null)
        {
            //drop current item and pick up new item
            itemInHand.transform.position = transform.position;
            itemInHand.gameObject.SetActive(true);

            itemInHand = nearbyItem;
        }
        else
        {
            itemInHand = nearbyItem;
            itemInHand.gameObject.SetActive(false);
        }

        nearbyItem = null;
    }
}
