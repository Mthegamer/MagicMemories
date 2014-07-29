/*============================================================================== 
 * Copyright (c) 2012-2014 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/

using UnityEngine;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class ImageTargetTrackableEventHandler : MonoBehaviour,
                                            ITrackableEventHandler
{
    private UIManager UIM;


    #region PUBLIC_MEMBER_VARIABLES
    public bool isBeingTracked;
    #endregion PUBLIC_MEMBER_VARIABLES
    
    #region PRIVATE_MEMBER_VARIABLES
    private TrackableBehaviour mTrackableBehaviour;
    #endregion // PRIVATE_MEMBER_VARIABLES

    #region PUBLIC_METODS
    void Start()
    {
        UIM = GameObject.Find("Manager").GetComponent<UIManager>();


        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
    

    /// <summary>
    /// Implementation of the ITrackableEventHandler function called when the
    /// tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS



    #region PRIVATE_METHODS
    private void OnTrackingFound()
    {
        UIM.SetCurrentlyTracking(true);

        isBeingTracked = true;
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Enable rendering:
     /*   
     foreach (Renderer component in rendererComponents)
        {

             if(component.gameObject.name == "Shark_prefab")
            {
                component.enabled = true;
            }

            if(component.gameObject.name == "Cube")
            {
                component.enabled = true;
            }

            component.enabled = true;
        }

        // Enable colliders:
        foreach (Collider component in colliderComponents)
        {

            component.enabled = true;

             if(component.gameObject.name == "Shark_prefab")
            {
                component.enabled = true;
            }

            if(component.gameObject.name == "Cube")
            {
                component.enabled = true;
            }
        }
        */

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
    }


    private void OnTrackingLost()
    {
        UIM.SetCurrentlyTracking(false);

        isBeingTracked = false;
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Disable rendering:
        /*
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = false;
        }

        // Disable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = false;
        }
        */
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
    }

    #endregion // PRIVATE_METHODS
}
