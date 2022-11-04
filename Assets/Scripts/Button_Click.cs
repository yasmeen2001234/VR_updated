using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Click : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onButtonPressed()
    {

        transform.position = new Vector3( 5 ,transform.position.y, transform.position.z);
    }
}
