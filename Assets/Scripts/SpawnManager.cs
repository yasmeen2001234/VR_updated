using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Management;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject xrOrigin;

    [SerializeField]
    GameObject ThirdPersonCamera;

    [SerializeField]
    GameObject GenericVRPlayerPrefab;

    [SerializeField]
    GameObject ThirdPersonAvatar;

    PhotonView view;

    private Vector3 spawnPositionVR;
    private Vector3 spawnPositionNONVR;



    





    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "SampleScene")
        {

            //Gallery scene
            spawnPositionNONVR = new Vector3(Random.Range(3.3f, 3f), 0.374f, Random.Range(12.24f, 13f));

        }
        else
        {

            if (scene.name == "Rome")

            {
                //Gallery scene
                spawnPositionNONVR = new Vector3(Random.Range(-28f, -29f), 0, Random.Range(-17f, -18f));
            }



        }

        
        spawnPositionVR = new Vector3(Random.Range(31f, 38f),180, Random.Range(65f, 72f));





        var xrSettings = XRGeneralSettings.Instance;
        var xrManager = xrSettings.Manager;
        var xrLoader = xrManager.activeLoader;


        if (xrSettings == null || XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.Log("XRGeneralSettings is null");
            
        }

        

        if(xrManager == null)
        {
            Debug.Log("XRManagerSettings is null");
        }

        if(xrLoader == null)
        {
            Debug.Log("XRLoader is null");
            xrOrigin.SetActive(false);
            ThirdPersonCamera.SetActive(true);
            
            if (PhotonNetwork.IsConnectedAndReady)
            {
                PhotonNetwork.Instantiate(ThirdPersonAvatar.name, spawnPositionNONVR, Quaternion.identity);
              //  Debug.Log(view.Owner.NickName + " Spawned a Non VR Avatar");
            }
            return;
        }

        else
        {
            Debug.Log("XRLoader is not null");
            xrOrigin.SetActive(true);
            ThirdPersonCamera.SetActive(false);
            
            if (PhotonNetwork.IsConnectedAndReady)
            {
                PhotonNetwork.Instantiate(GenericVRPlayerPrefab.name, spawnPositionVR, Quaternion.identity);
            }
        }

    }

}
