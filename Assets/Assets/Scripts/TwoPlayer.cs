using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Photon.Pun;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
public class TwoPlayer : MonoBehaviour
{
    public PhotonView photonView;
    [SerializeField] private ThirdPersonController tpc;
    [SerializeField] private PlayerInput pi;
    public BasicRigidBodyPush brp;
    public StarterAssetsInputs starterAssetsInputs;
    public Transform CameraRoot;
    public CinemachineVirtualCamera vcam;

    public SkinnedMeshRenderer skmr;
    // Start is called before the first frame update
    private void Start()
    {
        vcam = GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
        Check();
    }
    private void Check()
    {
        if (!photonView.IsMine)
        {
            Destroy(tpc);
            Destroy(pi);
            Destroy(brp);
            Destroy(starterAssetsInputs);
        }
        else if(photonView.IsMine)
        {
            vcam.Follow = CameraRoot;
            skmr.enabled = false;
        }
    }


}
