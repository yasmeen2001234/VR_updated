using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using Unity.XR.CoreUtils;



public class AvatarController : MonoBehaviour
{
    public Transform vrTargetHead;
    public Transform vrTargetRightHand;
    public Transform vrTargetLeftHand;

    public Transform IKTargetHead;
    public Transform IKTargetLeftHand;
    public Transform IKTargetRightHand;


    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;
    PhotonView photonView;



    [SerializeField] private AvatarController head;
    [SerializeField] private AvatarController leftHand;
    [SerializeField] private AvatarController rightHand;

    [SerializeField] private float turnSmoothness;

    [SerializeField] private Transform IKHead;

    [SerializeField] private Vector3 headBodyOffset;
  


    void Start()
    {

        photonView = GetComponent<PhotonView>();
        XROrigin rig = FindObjectOfType<XROrigin>();
        vrTargetHead = rig.transform.Find("Camera Offset/Main Camera");
        vrTargetLeftHand = rig.transform.Find("Camera Offset/LeftHand/LeftBaseController");
        vrTargetRightHand = rig.transform.Find("Camera Offset/RightHand/RightBaseController");

    }

    public void MapVRAvatar()
    {
        IKTargetHead.position = vrTargetHead.TransformPoint(trackingPositionOffset);
        IKTargetHead.rotation = vrTargetHead.rotation * Quaternion.Euler(trackingRotationOffset);


        IKTargetLeftHand.position = vrTargetLeftHand.TransformPoint(trackingPositionOffset);
        IKTargetLeftHand.rotation = vrTargetLeftHand.rotation * Quaternion.Euler(trackingRotationOffset);


        IKTargetRightHand.position = vrTargetRightHand.TransformPoint(trackingPositionOffset);
        IKTargetRightHand.rotation = vrTargetRightHand.rotation * Quaternion.Euler(trackingRotationOffset);

    }


   
    void LateUpdate()
    {

        if (photonView.IsMine)
        {
            transform.position = IKHead.position + headBodyOffset;
            transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(IKHead.forward, Vector3.up).normalized, Time.deltaTime * turnSmoothness); ;
            head.MapVRAvatar();
            leftHand.MapVRAvatar();
            rightHand.MapVRAvatar();
        }
        
    }
}
