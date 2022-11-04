using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using UnityEngine.XR.Management;

public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{

    public GameObject LocalXRRigGameobject;
    public GameObject MainAvatarGameobject;

    public GameObject AvatarHeadGameobject;
    public GameObject AvatarBodyGameobject;
    public GameObject AvatarLeftEyeGameobject;
    public GameObject AvatarRightEyeGameobject;
    public GameObject AvatarGlassesGameobject;
    public GameObject AvatarHairGameobject;
    public GameObject AvatarTeethGameobject;
    /*
    [SerializeField]
    public GameObject Avatar;

    public GameObject generic;

    public GameObject VRrig;


    public GameObject[] AvatarModelPrefabs;

    public TextMeshProUGUI PlayerName_Text;*/

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            //The player is local





            //Getting the avatar selection data so that the correct avatar model can be instantiated.
            /*
            object avatarSelectionNumber;
            if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue(MultiplayerVRConstants.AVATAR_SELECTION_NUMBER,out avatarSelectionNumber ))
            {
                Debug.Log("Avatar selection number: "+ (int)avatarSelectionNumber);
                photonView.RPC("InitializeSelectedAvatarModel",RpcTarget.AllBuffered,(int)avatarSelectionNumber);
            }
            */

            SetLayerRecursively(AvatarHeadGameobject, 9);
            SetLayerRecursively(AvatarBodyGameobject, 9);
            SetLayerRecursively(AvatarLeftEyeGameobject, 9);
            SetLayerRecursively(AvatarRightEyeGameobject, 9);
            SetLayerRecursively(AvatarGlassesGameobject, 9);
            SetLayerRecursively(AvatarHairGameobject, 9);
            SetLayerRecursively(AvatarTeethGameobject, 9);

        }
        else
        {
            SetLayerRecursively(AvatarHeadGameobject, 0);
            SetLayerRecursively(AvatarBodyGameobject, 0);
            SetLayerRecursively(AvatarLeftEyeGameobject, 0);
            SetLayerRecursively(AvatarRightEyeGameobject, 0);
            SetLayerRecursively(AvatarGlassesGameobject, 0);
            SetLayerRecursively(AvatarHairGameobject, 0);
            SetLayerRecursively(AvatarTeethGameobject, 0);
        }
        /*
                    TeleportationArea[] teleportationAreas = GameObject.FindObjectsOfType<TeleportationArea>();
                    if (teleportationAreas.Length > 0)
                    {
                        Debug.Log("Found "+ teleportationAreas.Length+ " teleportation area. ");
                        foreach (var item in teleportationAreas)
                        {
                            item.teleportationProvider = LocalXRRigGameobject.GetComponent<TeleportationProvider>();
                        }
                    }
                    MainAvatarGameobject.AddComponent<AudioListener>();

                }
                else
                {
                    //The player is remote

         //           XRGeneralSettings.Instance.Manager.Equals(false) ; 

           //         Destroy(LocalXRRigGameobject);

                    SetLayerRecursively(AvatarHeadGameobject, 0);
                        SetLayerRecursively(AvatarBodyGameobject, 0);
                }
                void SetLayerRecursively(GameObject go, int layerNumber)
                {
                    if (go == null) return;
                    foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
                    {
                        trans.gameObject.layer = layerNumber;
                    }
                }

                    */

        /*
        if (PlayerName_Text !=null)
        {
            PlayerName_Text.text = photonView.Owner.NickName;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }



    [PunRPC]
    public void InitializeSelectedAvatarModel(int avatarSelectionNumber)
    {
        GameObject selectedAvatarGameobject = Instantiate(AvatarModelPrefabs[avatarSelectionNumber], LocalXRRigGameobject.transform);

        AvatarInputConverter avatarInputConverter = LocalXRRigGameobject.GetComponent<AvatarInputConverter>();
        AvatarHolder avatarHolder = selectedAvatarGameobject.GetComponent<AvatarHolder>();
        SetUpAvatarGameobject(avatarHolder.HeadTransform, avatarInputConverter.AvatarHead);
        SetUpAvatarGameobject(avatarHolder.BodyTransform, avatarInputConverter.AvatarBody);
        SetUpAvatarGameobject(avatarHolder.HandLeftTransform, avatarInputConverter.AvatarHand_Left);
        SetUpAvatarGameobject(avatarHolder.HandRightTransform, avatarInputConverter.AvatarHand_Right);
    }

    void SetUpAvatarGameobject(Transform avatarModelTransform, Transform mainAvatarTransform)
    {
        avatarModelTransform.SetParent(mainAvatarTransform);
        avatarModelTransform.localPosition = Vector3.zero;
        avatarModelTransform.localRotation = Quaternion.identity;
    }

        */
    }

        void SetLayerRecursively(GameObject go, int layerNumber)
        {
            if (go == null) return;
            foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
            {
                trans.gameObject.layer = layerNumber;
            }
        }
    }

