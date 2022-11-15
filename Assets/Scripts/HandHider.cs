using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandHider : MonoBehaviour
{
    private SkinnedMeshRenderer meshRenderer = null;
    private XRDirectInteractor interactor = null;

    [System.Obsolete]
    private void Awake()
    {
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        interactor = GetComponent<XRDirectInteractor>();

        interactor.onHoverEntered.AddListener(Hide);
        interactor.onHoverExited.AddListener(Show);
    }

    [System.Obsolete]
    private void OnDestroy()
    {
        interactor.onHoverEntered.RemoveListener(Hide);
        interactor.onHoverExited.RemoveListener(Show);
    }

    private void Show(XRBaseInteractable interactable)
    {
        meshRenderer.enabled = true;
    }

    private void Hide(XRBaseInteractable interactable)
    {
        meshRenderer.enabled = false;
    }
}
