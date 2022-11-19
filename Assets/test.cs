using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    [SerializeField]
    GameObject objectToFind;


    public PhotonView PVToBeDeaActivated;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    
        float minDist = 1f;
        float dist = Vector3.Distance(objectToFind.transform.position, transform.position);
        if (dist < minDist)
        {

         
            PVToBeDeaActivated.RPC("SetThisActive", RpcTarget.All, PVToBeDeaActivated.ViewID);
            print(PVToBeDeaActivated.ViewID);
        }
        else return;




    }


    [PunRPC]
    void SetThisActive(int ID)
    {
        PhotonView.Find(17).gameObject.SetActive(true); //WHEN IT IS NOT SAME OBJECT


        // objectToFind.SetActive(true);
        //  GrabbleGameobject.SetActive(false);
    }

}
