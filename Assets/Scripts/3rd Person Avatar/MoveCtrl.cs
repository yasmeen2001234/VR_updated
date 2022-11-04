using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;

public class MoveCtrl : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private PhotonView photonView;
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private Transform MainCamera;
    private PlayerInput Avatar; 
    [SerializeField]
    private CinemachineFreeLook Cam3rdPerson;
    [SerializeField]
    private CinemachineVirtualCamera Cam1stPerson;
    private bool toggle = true;
    [SerializeField] private Animator MaximeAnimator;
    bool isWalking = true;
    //bool isRunning = false;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        Debug.Log("start");
        CinemachineBrain cam = FindObjectOfType<CinemachineBrain>();
        MainCamera = cam.transform;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        //Debug.Log("Grounded");
    }

    public void MovementProcess(Vector2 input )
    {
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if(photonView.IsMine)
        {
            Vector3 move = (this.MainCamera.forward * input.y + this.MainCamera.right * input.x);
            move.y = 0f;
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                if(toggle)
                    gameObject.transform.forward = move;
                Debug.Log("Moving");
                isWalking = true;
            }
            else
            {
                //Debug.Log("Idle");
                isWalking = false;
            }
    

            this.playerVelocity.y += gravityValue * Time.deltaTime;
            this.controller.Move(playerVelocity * Time.deltaTime);

            MaximeAnimator.SetBool("isWalking", isWalking);

        }
    }

    public void Jump()
    {
        // Changes the height position of the player..
        if (groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

    }

    public void CamToggle()
    {
        toggle = !toggle;

        if(toggle)
        {
            //switch to third person cam
            Cam3rdPerson.Priority = 1;
            Cam1stPerson.Priority = 0;
        }
        else
        {
            //switch to first person cam
            Cam3rdPerson.Priority = 0;
            Cam1stPerson.Priority = 1;
        }

        Debug.Log(toggle);
    }



}
