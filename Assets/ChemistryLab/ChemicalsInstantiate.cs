using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Management;


public class ChemicalsInstantiate : MonoBehaviour
{
    [SerializeField] GameObject chemicals;
    Vector3 position;
    public static ChemicalsInstantiate Instance;

    [SerializeField] GameObject MainCamera; 
  

    [SerializeField] GameObject Canvas;

    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(-29.21f, 1.59f, -25.42f);
      

    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.ActivateButton == true)
        {
            Canvas.SetActive(true);
       
        }
        else
        {
            Canvas.SetActive(false);
            Checkxr();
        }

    }

    void Checkxr()
    {
        var xrSettings = XRGeneralSettings.Instance;
        var xrManager = xrSettings.Manager;
        var xrLoader = xrManager.activeLoader;

        if (xrLoader == null)
            MainCamera.SetActive(true);
        else MainCamera.SetActive(false);
    }


    public void OnButtonClick()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.Instantiate(chemicals.name, position, Quaternion.identity);
            //  Debug.Log(view.Owner.NickName + " Spawned a Non VR Avatar");
         //   SecondCamera.SetActive(true);
            MainCamera.SetActive(false);
        }
        return;

    }
    public void OnButtonClickDestroy()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
         //   PhotonNetwork.Destroy(chemicals.name);
          
        }
        return;

    }
    
   public void DestroyObject(GameObject gameObject)
    {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
        }
    }

