using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAdd : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bottle ;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        bottle.GetComponent<UnitySimpleLiquid.AddLiquid>().enabled = true;
        print("Clicking add");


    }

}
