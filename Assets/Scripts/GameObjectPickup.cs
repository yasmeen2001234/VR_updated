using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(XRGrabInteractable))]
[DisallowMultipleComponent]
public class GameObjectPickup : MonoBehaviour
{
    private XRGrabInteractable XRGrab;
    private Collider[] Colliders;

    private void Start()
    {
        XRGrab = GetComponent<XRGrabInteractable>();
        Colliders = GetComponents<Collider>();

        XRGrab.selectEntered.AddListener(Grab);
        XRGrab.selectExited.AddListener(Drop);
    }

    public void Grab(SelectEnterEventArgs args)
    {
        foreach (Collider collider in Colliders)
            collider.isTrigger = true;
        Physics.IgnoreLayerCollision(7, 8);
        Physics.IgnoreLayerCollision(8, 7);

        var characterController = FindObjectOfType<CharacterController>();
        if (characterController != null)
        {
            foreach (var collider in Colliders)
            {
                Physics.IgnoreCollision(collider, characterController, true);
            }
        }
    }

    public void Drop(SelectExitEventArgs args)
    {
        foreach (Collider collider in Colliders)
            collider.isTrigger = false;
        Physics.IgnoreLayerCollision(7, 8);
        Physics.IgnoreLayerCollision(8, 7);

        var characterController = FindObjectOfType<CharacterController>();
        if (characterController != null)
        {
            foreach (var collider in Colliders)
            {
                Physics.IgnoreCollision(collider, characterController, true);
            }
        }

    }
}
