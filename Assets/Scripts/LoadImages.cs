using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadImages : MonoBehaviour
{
    public string url = "https://opensea.io/assets/ethereum/0x57a204aa1042f6e66dd7730813f4024114d74f37/146/";
    public Renderer thisRenderer;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(LoadFromLikeCoroutine());//executethesectionindependently
        thisRenderer.material.color = Color.red;
    }
    private IEnumerator LoadFromLikeCoroutine() {

        Debug.Log("Loading");
        WWW wwwLoader = new WWW(url);
        yield return wwwLoader;
        // create Www object pointing to the url
     
        Debug.Log("Loaded");
        thisRenderer.material.color = Color.white;
        thisRenderer.material.mainTexture = wwwLoader.texture;


    }
  
}

