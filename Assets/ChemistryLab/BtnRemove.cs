using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnRemove : MonoBehaviour
{
    public GameObject bottle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        bottle.GetComponent<UnitySimpleLiquid.RemoveLiquid>().enabled = true;
        print("Clicking remove");

    }
    public void onClick()
    {
        bottle.GetComponent<UnitySimpleLiquid.RemoveLiquid>().enabled = true;
        print("Clicking remove");

    }
}
