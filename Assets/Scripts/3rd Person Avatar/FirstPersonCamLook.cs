using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FirstPersonCamLook : MonoBehaviour
{
    public GameObject cam;
    private float RotateX = 0f;

    private float SensitivityX = 30f;
    private float SensitivityY = 30f;
    
     void Start()
    {
        cam = Camera.main.gameObject;
    }
    public void LookProcess(Vector2 input){
        float mouseX = input.x;
        float mouseY = input.y;

        //calculate camera rotation for looking up and down
        RotateX -= (mouseY * Time.deltaTime) * SensitivityY;

        RotateX = Mathf.Clamp(RotateX, -80f, 80f);

        //apply to camera transform
        cam.transform.localRotation = Quaternion.Euler(RotateX, 0, 0);

        //Rotate Player
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * SensitivityX); 
    }

}
