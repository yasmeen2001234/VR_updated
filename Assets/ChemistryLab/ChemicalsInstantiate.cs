using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class ChemicalsInstantiate : MonoBehaviour
{
    [SerializeField] GameObject chemicals;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(-29.21f, 1.339f, -25.14f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonClick()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.Instantiate(chemicals.name, position, Quaternion.identity);
            //  Debug.Log(view.Owner.NickName + " Spawned a Non VR Avatar");
        }
        return;

    }
}
