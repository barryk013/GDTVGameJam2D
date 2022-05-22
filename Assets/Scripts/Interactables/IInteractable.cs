using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IInteractable
{
    public Transform Transform { get; }
    public void StartInteraction();
    public void StopInteraction();
    public void Select();
    public void Deselect();
}

