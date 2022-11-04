using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class animatorMovement : MonoBehaviour
{
    bool isWalking = false;

    public Animator CelebrityAnimator;


    public TextMeshProUGUI PlayerName_text;



    float speed = 1.0f;
    public Rigidbody rb;

    PhotonView view;
    public GameObject cam;
    private Vector3 offset;
    public float sensitivity = 5f;
    private float clampAngle = 5f;
  //  [SerializeField] private FixedJoystick _joystick;
    [SerializeField] public GameObject MainAvatar;
   // public Canvas CanvasObject;

    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();
        cam = Camera.main.gameObject;

    //    MainAvatar.AddComponent<AudioListener>();
        offset = cam.transform.position - CelebrityAnimator.transform.position;

    }

    void Awake()
    {
        if (!Application.isMobilePlatform)
        {
        //    CanvasObject.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if (view.IsMine)
        {

        }
    
       // PlayerName_text.text = view.Owner.NickName;
        Debug.Log(view.Owner.NickName);

    }

    // Update is called once per frame

    void Update()
    {

        if (view.IsMine)
        {
            if (Input.GetKey(KeyCode.C))
            {

                Vector3 axis = new Vector3(0, 2, 0);
                cam.transform.RotateAround(rb.transform.position, axis, (-20 * Time.deltaTime));
                Debug.DrawRay(this.transform.position, this.transform.forward, Color.red);
            }
            if (Input.GetKey(KeyCode.V))
            {
                Vector3 axis = new Vector3(0, 2, 0);
                cam.transform.RotateAround(rb.transform.position, axis, (20 * Time.deltaTime));

            }
            float mouseY = Input.GetAxis("Mouse Y");
            cam.transform.Rotate(new Vector3(-mouseY * 0.9f, 0, 0));
        }
    }
}