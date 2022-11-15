using Photon.Pun;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorChanger : MonoBehaviour
{
    public Material selectMaterial = null;

    private MeshRenderer meshRenderer = null;
    private XRBaseInteractable interactable = null;
    private Material originalMaterial = null;


    [SerializeField] GameObject chemicals;
    Vector3 position;

    [System.Obsolete]
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;

        interactable = GetComponent<XRBaseInteractable>();
        interactable.onHoverEntered.AddListener(SetSelectMaterial);
        interactable.onHoverExited.AddListener(SetOriginalMaterial);
        interactable.onSelectEntered.AddListener(translateingUp);
        interactable.onSelectExited.AddListener(translateingDown);
    }

    [System.Obsolete]
    private void OnDestroy()
    {
        interactable.onHoverEntered.RemoveListener(SetSelectMaterial);
        interactable.onHoverExited.RemoveListener(SetOriginalMaterial);
    }

    void Start()
    {
        position = new Vector3(-29.21f, 1.59f, -25.42f);


    }

    private void SetSelectMaterial(XRBaseInteractor interactor)
    {
        meshRenderer.material = selectMaterial;
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.Instantiate(chemicals.name, position, Quaternion.identity);
        }

    }

    private void translateingUp(XRBaseInteractor interactor)
    {
        transform.Translate(-Vector3.up * Time.deltaTime, Space.World);
        // transform.position = new Vector3(transform.position.x, 0.9f, transform.position.z);
       

    }
    private void translateingDown(XRBaseInteractor interactor)
    {
      //  transform.Translate(-Vector3.up * Time.deltaTime, Space.World);
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
    }

    private void SetOriginalMaterial(XRBaseInteractor interactor)
    {
        meshRenderer.material = originalMaterial;
    }
}
