using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class playerMovement : MonoBehaviour
{
    bool isWalking = false;

    public Animator CelebrityAnimator;

    float speed = 1.0f;

    public Rigidbody rb;

    PhotonView view;

    private GameObject cam;

    private Vector3 offset;
    public float sensitivity = 5f;
    private float clampAngle = 5f;
   


    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();
        cam = Camera.main.gameObject;
        offset = cam.transform.position - rb.transform.position;

    }

    private void FixedUpdate()
    {
        if (view.IsMine)
        {

            //  Move();
            cam.transform.position = rb.transform.position + offset;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                isWalking = true;
                CelebrityAnimator.SetBool("isWalking", isWalking);

                transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
            }
            else
            {
                if (isWalking == true)
                {
                    isWalking = false;
                    CelebrityAnimator.SetBool("isWalking", isWalking);
                }
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, -60 * Time.deltaTime, 0);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, 60 * Time.deltaTime, 0);
            }

        }
       
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
            // cam.transform.Rotate(new Vector3(-mouseY * 0.9f, 0, 0));




        } // end Update


    }
    private void Move()
    {

        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
        movement.Normalize();
        this.transform.position += movement * 0.04f;

        this.CelebrityAnimator.SetFloat("vertical", verticalAxis);
        this.CelebrityAnimator.SetFloat("horizontal", horizontalAxis);



    }

    
}
