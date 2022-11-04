using System.Linq;
using UnityEngine;
using Photon.Pun;
using System.Collections;

public class Whiteboard : MonoBehaviour
{
    private int textureSize = 1024;
    private int penSize = 6;
    private int penSizeD2 = 3;
    private Texture2D texture;
    private Color[] color;
    new Renderer renderer;

    private bool touching, touchingLastFrame;
    private float posX, posY;
    private float lastX, lastY;
    bool everyOthrFrame;

    //The bigger whiteboards to copy what is drawn in the small one.
    public Renderer[] otherWhiteboars;
    PhotonView pv;

    private Texture2D receivedTexture;
    [Tooltip("The time it takes to send the whiteboard info through the network, to students.")]
    public float refreshRate = 2;
    float counter = 0;
    bool count;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        texture = new Texture2D(textureSize, textureSize, TextureFormat.RGBA32, false);

        texture.filterMode = FilterMode.Trilinear;
        texture.anisoLevel = 3;

        renderer.material.mainTexture = texture;

        foreach (var item in otherWhiteboars)
        {
            item.material.mainTexture = texture;
        }

        pv = GetComponent<PhotonView>();
    }

    //The code below handles drawing in the whiteboard
    void Update()
    {
      // if (!pv.IsMine || PlatformManager.instance.mode == PlatformManager.Mode.StudentVR
                   //    || PlatformManager.instance.mode == PlatformManager.Mode.StudentPhone) return;
        int x = (int)(posX * textureSize - penSizeD2);
        int y = (int)(posY * textureSize - penSizeD2);

        if (touchingLastFrame)
        {
            texture.SetPixels(x, y, penSize, penSize, color);

            for (float t = 0.01f; t < 1.00f; t += 0.1f)
            {
                int lerpX = (int)Mathf.Lerp(lastX, (float)x, t);
                int lerpY = (int)Mathf.Lerp(lastY, (float)y, t);
                texture.SetPixels(lerpX, lerpY, penSize, penSize, color);
            }
            if (!everyOthrFrame)
            {
                everyOthrFrame = true;
            }
            else if (everyOthrFrame)
            {
                texture.Apply();
                everyOthrFrame = false;
            }
        }

        lastX = (float)x;
        lastY = (float)y;

        //This code below handles that the whiteboard texture is sync'd through the network x seconds(refreshRate) after the last marker touch
        if (counter >= refreshRate)
        {
            StartCoroutine(SendTextureOverNetwork());
            counter = 0;
            count = false;
        }
        if (touchingLastFrame && !touching)
            count = true;

        if (!touchingLastFrame && touching)
        {
            count = false;
            counter = 0;
        }

        if (count && !touching)
            counter += Time.deltaTime;

        touchingLastFrame = touching;
    }

    //Called from Marker.cs
    public void ToggleTouch(bool touching)
    {
        this.touching = touching;
    }

    //Receives the position of the raycast from the marker to the whiteboard
    public void SetTouchPosition(float x, float y)
    {
        posX = x;
        posY = y;
    }

    //Receives the color from the marker
    public void SetColor(Color color)
    {
        this.color = Enumerable.Repeat(color, penSize * penSize).ToArray();
    }

    public void ClearWhiteboard()
    {
        Debug.Log("Clearing whiteboard");
        texture = new Texture2D(textureSize, textureSize, TextureFormat.RGBA32, false);
        renderer.material.mainTexture = texture;

        foreach (var item in otherWhiteboars)
        {
            item.material.mainTexture = texture;
        }
        counter = 0;
        count = false;
        texture.Apply();
    }

    //Sends the texture through the network using a photon RPC, to everyone else (RPCTarget.Others)
    IEnumerator SendTextureOverNetwork()
    {
        pv.RPC("Send", RpcTarget.Others, texture.EncodeToPNG());
        yield return null;
    }

    public void SetPenSize(int n)
    {
        penSize = n;
        penSizeD2 = n / 2;
    }

    [PunRPC]
    private void Send(byte[] receivedByte)
    {
        receivedTexture = new Texture2D(1, 1);
        receivedTexture.LoadImage(receivedByte);
        ApplyReceivedTexture();
    }

   
    void ApplyReceivedTexture()
    {
        foreach (var item in otherWhiteboars)
        {
            item.material.mainTexture = receivedTexture;
        }
        GetComponent<Renderer>().material.mainTexture = receivedTexture;
    }
}
