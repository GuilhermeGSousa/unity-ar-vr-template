using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class TwoHandedGrabInteractable : XRGrabInteractable
{
    public List<XRBaseInteractable> secondHandGrabPoints = new List<XRBaseInteractable>();
    private IXRSelectInteractor secondInteractor;
    private Quaternion attachInitialRotation;
    private void Start() {
        secondHandGrabPoints.ForEach(interactable => 
        {
            interactable.selectEntered.AddListener(OnSecondHandGrab);
            interactable.selectExited.AddListener(OnSecondHandRelease);
        });
    }



    public override bool IsSelectableBy(IXRSelectInteractor interactor)
    {
        var nonSocketInteractors = interactorsSelecting.FindAll(interactor => {
            return interactor.GetType() != typeof(XRSocketInteractor);
        });

        bool isGrabbed = nonSocketInteractors.Count > 0 && !interactorsSelecting.Contains(interactor);
        return base.IsSelectableBy(interactor) && !isGrabbed;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        attachInitialRotation = args.interactorObject.GetAttachTransform(this).localRotation;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        secondInteractor = null;
        args.interactorObject.GetAttachTransform(this).localRotation = attachInitialRotation;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if(secondInteractor != null && interactorsSelecting.Count > 0)
        {
            Transform firstHandTransform = interactorsSelecting[0].GetAttachTransform(this);
            Transform secondHandTransform = secondInteractor.GetAttachTransform(this);

            firstHandTransform.rotation = Quaternion.LookRotation(
                secondHandTransform.position - firstHandTransform.position,
                secondHandTransform.up);
        }
        base.ProcessInteractable(updatePhase);
    }

    private void OnSecondHandGrab(SelectEnterEventArgs args)
    {
        secondInteractor = args.interactorObject;
    }

    private void OnSecondHandRelease(SelectExitEventArgs args)
    {
        secondInteractor = null;
        if(interactorsSelecting.Count > 0) interactorsSelecting[0].GetAttachTransform(this).localRotation = attachInitialRotation;
    }

}
