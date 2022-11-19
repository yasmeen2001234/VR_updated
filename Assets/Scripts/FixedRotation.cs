using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotation : MonoBehaviour
{
    [SerializeField]
    GameObject GrabbleGameobject;

    [SerializeField]
    GameObject objectToFind;

    [SerializeField]
    GameObject instantiatedObject;


    public PhotonView PVToBeDeActivated;

    [SerializeField]
    Vector3 position;



    Quaternion rot;


    [SerializeField]
    Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        rot.eulerAngles = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        float z = GrabbleGameobject.transform.rotation.z;

        GrabbleGameobject.transform.rotation = new Quaternion(GrabbleGameobject.transform.rotation.x * Time.deltaTime, 0, z * Time.deltaTime, 30); 
        */

        float minDist = 1f;
        float dist = Vector3.Distance(objectToFind.transform.position, transform.position);
        if (dist < minDist)
        {

            PVToBeDeActivated.RPC("SetThisInactive", RpcTarget.All, PVToBeDeActivated.ViewID);
        
      
        }
        else return;


     

    }

    [PunRPC]
    void SetThisInactive(int ID)
    {
        PhotonView.Find(ID).gameObject.SetActive(false); //WHEN IT IS NOT SAME OBJECT

        PhotonNetwork.Instantiate(objectToFind.name, position, rot);
        // objectToFind.SetActive(true);
        //  GrabbleGameobject.SetActive(false);
    }

    [PunRPC]
    void SetThisActive(int ID)
    {
        PhotonView.Find(17).gameObject.SetActive(true); //WHEN IT IS NOT SAME OBJECT
      

        // objectToFind.SetActive(true);
        //  GrabbleGameobject.SetActive(false);
    }

}
