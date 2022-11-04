using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class DetectVR : MonoBehaviour
{
   // public Behaviour UI_VR;
    public GameObject XR_Origin; 
     public GameObject NonVR_Camera;

    void Start()
    {

        var xrSettings = XRGeneralSettings.Instance;
        var xrManager = xrSettings.Manager;
        var xrLoader = xrManager.activeLoader;
/*
        if (xrSettings == null && XRGeneralSettings.Instance.Manager.activeLoader == null)
            
        {
            Debug.Log("No VR headset");
            XR_Origin.SetActive(false);
            NonVR_Camera.SetActive(true);

         
        }
        else

        {
            Debug.Log(" VR headset");
            // XRGeneralSettings.Instance.Manager.InitializeLoader();
            XR_Origin.SetActive(true);
            NonVR_Camera.SetActive(false);

        } */
/*
        if (xrSettings == null || XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.Log("XRGeneralSettings is null");

        } */


        if (xrLoader == null || xrManager == null)
        {
            Debug.Log("XRManagerSettings is null");
            Debug.Log("No VR headset");
            XR_Origin.SetActive(false);
            NonVR_Camera.SetActive(true);
        } else
        {
            XR_Origin.SetActive(true);
            NonVR_Camera.SetActive(false);
        }

    }


    void Update()
    {
       
    }
}
