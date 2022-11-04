using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

//This class sends a Raycast from the marker and detect if it's hitting the whiteboard (tag: Finish)
public class Markerss : MonoBehaviour
{
    public Whiteboard whiteboard;
    public Transform drawingPoint;
    public Renderer markerTip;
    private RaycastHit touch;
    bool touching;
    float drawingDistance = 0.015f;
    Quaternion lastAngle;
    PhotonView pv;
    XRGrabbablePun xrGrabbable;
    public Color color = Color.blue;
    bool grabbed;

    public void ToggleGrab(bool b)
    {
        if (b) grabbed = true;
        else grabbed = false;
    }

    private void Start()
    {
        pv = GetComponent<PhotonView>();
        xrGrabbable = GetComponent<XRGrabbablePun>();

        markerTip.material.color = color;
    }

    void Update()
    {
        if (!pv.IsMine) return;
        if (whiteboard == null) return;
        if (!grabbed) return;

        if (Physics.Raycast(drawingPoint.position, drawingPoint.up, out touch, drawingDistance))
        {
            if (touch.collider.CompareTag("Finish"))
            {
                if (!touching)
                {
                    touching = true;
                    lastAngle = transform.rotation;
                }
                whiteboard.SetPenSize(6);
                whiteboard.SetColor(color);
                whiteboard.SetTouchPosition(touch.textureCoord.x, touch.textureCoord.y);
                whiteboard.ToggleTouch(touching);
            }
        }
        else
        {
            touching = false;
            whiteboard.ToggleTouch(touching);
        }
    }

    private void LateUpdate()
    {
        if (!pv.IsMine) return;

        //lock rotation of marker when touching whiteboard
        if (touching)
        {
            transform.rotation = lastAngle;
        }
    }

}

