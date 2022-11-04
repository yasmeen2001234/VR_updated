using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using TMPro;
public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.PlayerActions onFoot;
    private MoveCtrl motion;
    private FirstPersonCamLook look;
    public Rigidbody rb;

    PhotonView view;
    //private DragAndDrop DragDrop;

    // Start is called before the first frame update

    private void Awake() {
        this.rb = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();

        playerInput = new PlayerInput();
        onFoot = playerInput.Player;

        motion = GetComponent<MoveCtrl>();
        look = GetComponent<FirstPersonCamLook>();
        //DragDrop = GetComponent<DragAndDrop>();



    }


    // Update is called once per frame
    void Update()
    {
        onFoot.Jump.performed += ctx => motion.Jump();
        //onFoot.Interact.performed += DragAndDrop.Mou;
        //Camera toggle
        onFoot.CameraToggle.performed += ctx => motion.CamToggle();
    }

    void FixedUpdate() {
        if(view.IsMine)
        {
            motion.MovementProcess(onFoot.Move.ReadValue<Vector2>());
        }

    }

    private void LateUpdate() {
        if(view.IsMine)
        {
            look.LookProcess(onFoot.Look.ReadValue<Vector2>());
        }
    }

    private void OnEnable() {
        onFoot.Enable();
        
    }

    private void OnDisable() {
        onFoot.Disable();
    }
}
