using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomSocket : MonoBehaviour
{
    public void OnSocketed(SelectEnterEventArgs args)
    {
        Debug.Log("Socketed " + args.interactableObject.transform.name);
    }
}
