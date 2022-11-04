using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraLook : MonoBehaviour
{
    [SerializeField]
    private float lookspeed = 1f;
    public CinemachineFreeLook cinemachine;
    private PlayerInput Avatar;

    private void Awake() {
        Avatar = new PlayerInput();
        cinemachine = GetComponent<CinemachineFreeLook>();
    }

    private void OnEnable() {
        Avatar.Enable();
    }

    private void OnDisable() {
        Avatar.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 delta = Avatar.Player.Look.ReadValue<Vector2>();
        cinemachine.m_XAxis.Value += delta.x * 200 * lookspeed * Time.deltaTime;
        cinemachine.m_YAxis.Value += delta.y * lookspeed * Time.deltaTime;
    }
}
