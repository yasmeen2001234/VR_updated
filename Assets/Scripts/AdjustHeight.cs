using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustHeight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // To see the player's feet 
        if ( transform.position.y < 1 )
        {
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        }
    }
}
