using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class LoginManager : MonoBehaviourPunCallbacks
{

    public TMP_InputField PlayerName_InputName; 

    #region Unity Methods 
    // Start is called before the first frame update
    void Start()
    {
      //  PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {

    }

   

    #endregion

    #region UI Callback Methods 

    public void ConnectAnonymously()
    {

        PhotonNetwork.ConnectUsingSettings();
    }

    public void ConnectToPhotonServer()
    {

        if(PlayerName_InputName != null)
        {
            PhotonNetwork.NickName = PlayerName_InputName.text;
            PhotonNetwork.ConnectUsingSettings();
        } 
    }


    #endregion


    #region Photon Callback Methods 

    public override void OnConnected()
    {

        Debug.Log("OnConnected is called . Ther server is avaliable"); 

    }

    public override void OnConnectedToMaster()
    {

        Debug.Log("Connected to Master Server with player name: " + PhotonNetwork.NickName);
        PhotonNetwork.LoadLevel("HomeScene");
    }

    #endregion
}
