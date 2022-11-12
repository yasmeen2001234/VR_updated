using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class Drag : MonoBehaviourPunCallbacks
{
    float rotationSpeed = 6f;
    PhotonView m_photonView;
    bool isBeingHeld = false;
    Rigidbody rb;

    //Rigidbody rb;
    void OnMouseDrag()
    {

        float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
        transform.Rotate(Vector3.right, XaxisRotation);
        transform.Rotate(Vector3.right, YaxisRotation);


    }
    private void OnMouseDown()
    {
        TransferOwnership();
        OnMouseDrag();

    }


    // Start is called before the first frame update


    // Update is called once per frame
    /*  void Update()
      {
          if(base.photonView.Owner == PhotonNetwork.LocalPlayer)
          {
              OnMouseDrag();
          }
      }


    */

    private void Awake()
    {
        m_photonView = GetComponent<PhotonView>();
    }

    void Start()
    {
      //  rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {/*
        if (isBeingHeld)
        {
          //  OnMouseDrag();
            //Object is being grabbbed
            rb.isKinematic = true;
            gameObject.layer = 11;

        }
        else
        {
            //Object is not being grabbed
            rb.isKinematic = false;
            gameObject.layer = 9;

        }
        */
        if (m_photonView.Owner == PhotonNetwork.LocalPlayer)
        {
            Debug.Log("We do not request the ownership. Already mine.");
        }
       
    }

    
    private void TransferOwnership()
    {
        m_photonView.RequestOwnership();
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        if (targetView != m_photonView)
        {
            return;
        }

        Debug.Log("Ownership Requested for: " + targetView.name + " from " + requestingPlayer.NickName);
        m_photonView.TransferOwnership(requestingPlayer);
    }

    /* for XR
    public void OnSelectEntered()
    {
        Debug.Log("Grabbed");
        m_photonView.RPC("StartNetworkGrabbing", RpcTarget.AllBuffered);

      
    }


    public void OnSelectedExited()
    {
        Debug.Log("Released");
        m_photonView.RPC("StopNetworkGrabbing", RpcTarget.AllBuffered);
    }




    [PunRPC]
    public void StartNetworkGrabbing()
    {
        isBeingHeld = true;
       // OnMouseDrag();
    }


    [PunRPC]
    public void StopNetworkGrabbing()
    {
        isBeingHeld = false;
    }
    */
}
