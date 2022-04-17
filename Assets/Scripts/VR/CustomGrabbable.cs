using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomGrabbable : MonoBehaviour
{
    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Selected");
    }

    public void OnActivate(ActivateEventArgs args)
    {
        Debug.Log("Activated");
    }
}
