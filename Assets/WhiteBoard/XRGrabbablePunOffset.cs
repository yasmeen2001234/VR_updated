using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

//Custom Grabbable script that is visible over Photon's network
public class XRGrabbablePunOffset : XRGrabInteractable
{
    private Vector3 interactorPosition = Vector3.zero;
    private Quaternion interactorRotation = Quaternion.identity;
    private XRBaseInteractor grabInteractor;

    PhotonView pv;
    bool wasKinematic;
    protected override void Awake()
    {
        base.Awake();
        pv = GetComponent<PhotonView>();
        wasKinematic = GetComponent<Rigidbody>().isKinematic;
    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        //if it is a socket, don't offset
        if (interactor.GetComponent<XRSocketInteractor>() != null) return;
        StoreInteractor(interactor);
        MatchAttachmentPoints(interactor);
        pv.TransferOwnership(PhotonNetwork.LocalPlayer.ActorNumber);
        pv.RPC("SetKinematic", RpcTarget.OthersBuffered, true);
    }

    private void StoreInteractor(XRBaseInteractor interactor)
    {
        interactorPosition = interactor.attachTransform.localPosition;
        interactorRotation = interactor.attachTransform.localRotation;
        grabInteractor = interactor;
    }

    private void MatchAttachmentPoints(XRBaseInteractor interactor)
    {
        bool hasAttach = attachTransform != null;
        interactor.attachTransform.position = hasAttach ? attachTransform.position : transform.position;
        interactor.attachTransform.rotation = hasAttach ? attachTransform.rotation : transform.rotation;
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        if (interactor.GetComponent<XRSocketInteractor>() != null) return;
        ResetAttachmentPoint(interactor);
        ClearInteractor(interactor);
        pv.RPC("SetKinematic", RpcTarget.OthersBuffered, wasKinematic);
    }

    private void ResetAttachmentPoint(XRBaseInteractor interactor)
    {
        interactor.attachTransform.localPosition = interactorPosition;
        interactor.attachTransform.localRotation = interactorRotation;
    }

    private void ClearInteractor(XRBaseInteractor interactor)
    {
        interactorPosition = Vector3.zero;
        interactorRotation = Quaternion.identity;
        grabInteractor = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (grabInteractor != null)
        {
            grabInteractor.GetComponent<XRController>().SendHapticImpulse(collision.relativeVelocity.magnitude / 10f, 0.1f);
        }
    }

    [PunRPC]
    public void SetKinematic(bool state)
    {
        GetComponent<Rigidbody>().isKinematic = state;
    }
}
