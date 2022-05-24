using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IInteractable
{
    public Transform Transform { get; }
    public event Action InteractionFinished;
    public void StartInteraction(Inventory inventory);
    public void StopInteraction();
    public void Select();
    public void Deselect();
}

