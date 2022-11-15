using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class HandButton : XRBaseInteractable
{

    private float yMin = 0.0f; private float yMax = 0.0f;

    private float previousHandHeight = 0.0f; 
    private XRBaseInteractor hoverInteractor = null;

    [System.Obsolete]
    protected override void Awake()
    {

        base.Awake();
        onHoverEntered.AddListener(StartPress);

        onHoverExited.AddListener(EndPress); }

    [System.Obsolete]
    private void OnDestroy()
    {
        onHoverEntered.RemoveListener(StartPress);
        onHoverExited.RemoveListener(EndPress);

    }

    private void StartPress(XRBaseInteractor interactor)
    {
        hoverInteractor = interactor;

        previousHandHeight = interactor.transform.position.y;

    }

    private void EndPress(XRBaseInteractor interactor)

    {
        hoverInteractor = null;

        previousHandHeight = 0.0f;

    }

private void Start()
    {
        SetMinMax();
    }

private void SetMinMax()
    {
      
        Collider collider = GetComponent<Collider>();
        yMin = transform.position.y - (collider.bounds.size.y * 0.5f);
        yMax = transform.position.y;
    }
}
