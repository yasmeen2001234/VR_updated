using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using Unity.XR.CoreUtils;

public class NetworkPlayer : MonoBehaviour
{

    public Transform head;
    public Transform lefthand;
    public Transform righthand;
    private PhotonView photonView;

    public GameObject MainAvatar;

  

    private Transform headrig;
    private Transform leftHandrig;
    private Transform rightHandrig;

    public Vector3 trackingPositionOffsetRight;
    public Vector3 trackingRotationOffsetRight;

    public Vector3 trackingPositionOffsetLeft;
    public Vector3 trackingRotationOffsetLeft;

    public Vector3 trackingPositionOffsetHead;
    public Vector3 trackingRotationOffsetHead;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
    
        photonView = GetComponent<PhotonView>();
        XROrigin rig = FindObjectOfType<XROrigin>();
        headrig = rig.transform.Find("Camera Offset/Main Camera");
        leftHandrig = rig.transform.Find("Camera Offset/LeftHand/LeftBaseController");
        rightHandrig = rig.transform.Find("Camera Offset/RightHand/RightBaseController");
    }

    // Update is called once per frame 
    void Update()
    {
        if ( photonView.IsMine)
        {
            /*
            righthand.gameObject.SetActive(false); 
            lefthand.gameObject.SetActive(false);
            head.gameObject.SetActive(false);
            */
          
            MapPositionHead(head, headrig);
            MapPositionLeft(lefthand, leftHandrig);
            MapPositionRight(righthand, rightHandrig);

     //       MainAvatar.transform.position = headrig.position;
            MainAvatar.transform.position = new Vector3(headrig.transform.position.x, 0.65f, headrig.transform.position.z);
            //MainAvatar.transform.rotation = headrig.rotation;

            transform.position = headrig.position + new Vector3(0,-1.65f,0);
            transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(headrig.forward, Vector3.up).normalized, Time.deltaTime * 5); ;
        }


    }

    void MapPositionRight(Transform target , Transform rigTransform)
    {

        //target.position = rigTransform.position;
        //target.rotation = rigTransform.rotation;
        target.position = rigTransform.TransformPoint(trackingPositionOffsetRight);
        target.rotation = rigTransform.rotation * Quaternion.Euler(trackingRotationOffsetRight);


    }

    void MapPositionLeft(Transform target, Transform rigTransform)
    {

        //target.position = rigTransform.position;
        //target.rotation = rigTransform.rotation;
        target.position = rigTransform.TransformPoint(trackingPositionOffsetLeft);
        target.rotation = rigTransform.rotation * Quaternion.Euler(trackingRotationOffsetLeft);


    }

    void MapPositionHead(Transform target, Transform rigTransform)
    {

        //target.position = rigTransform.position;
        //target.rotation = rigTransform.rotation;
        target.position = rigTransform.TransformPoint(trackingPositionOffsetHead);
        target.rotation = rigTransform.rotation * Quaternion.Euler(trackingRotationOffsetHead);


    }
}
