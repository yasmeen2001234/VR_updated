using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeForce : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("RigidBodies")]
    [SerializeField]
    Rigidbody object1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        object1.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        object1.GetComponent<Rigidbody>().AddTorque(0, 0, 0);
        object1.angularVelocity = Vector3.zero;
    }
}
