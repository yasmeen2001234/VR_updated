using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftUIDisable : MonoBehaviour
{
    public GameObject LeftUI; 
    // Start is called before the first frame update

    void Awake ()
    {

        LeftUI.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
