using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class cshSettingWeapon : MonoBehaviour
{
    private bool[,] weapons = new bool[2, 3] { { false, false, false }, { false, false, false } };
    private GameObject rightHand;
    private GameObject leftHand;
    private GameObject curSword;
    private Animator animator;
    //private GameObject ovrCamera;
    public PhotonView PV;
    public bool isReady = false;
    public Button[] rightButtons = new Button[3];
    public Button[] leftButtons = new Button[3];
    public Button selectButton;

    // Start is called before the first frame update
    void Start()
    {
        rightHand = transform.Find("PlayerCharacter/root/pelvis/spine_01/spine_02/spine_03/clavicle_r/upperarm_r/lowerarm_r/hand_r").gameObject;
        leftHand = transform.Find("PlayerCharacter/root/pelvis/spine_01/spine_02/spine_03/clavicle_l/upperarm_l/lowerarm_l/hand_l").gameObject;
        animator = transform.Find("PlayerCharacter").gameObject.GetComponent<Animator>();
        PV = gameObject.GetComponent<PhotonView>();
        //ovrCamera = GameObject.Find("OVRPlayerCamera").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //PV.RPC("ActiveWeapon", RpcTarget.All, 1, false);
    }

    public void unequipSword()
    {
        if (!curSword) return;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (weapons[i, j])
                {
                    if (i == 0) PV.RPC("DeactiveWeapon", RpcTarget.All, j, true);
                    else PV.RPC("DeactiveWeapon", RpcTarget.All, j, false);
                    weapons[i, j] = false;
                }
            }
        }
        curSword = null;
    }

    public void equipSword(int swordIndex, bool isRight)
    {
        if (swordIndex > 2 || curSword)
        {
            unequipSword();
            return;
        }

        if (isRight)
        {
            curSword = rightHand.transform.GetChild(swordIndex + 5).gameObject;
            //curSword.SetActive(true);
            PV.RPC("ActiveWeapon", RpcTarget.All, swordIndex, true);
            weapons[0, swordIndex] = true;
            //animator.SetBool("rightGrabing", true);
        }
        else
        {
            curSword = leftHand.transform.GetChild(swordIndex + 5).gameObject;
            //curSword.SetActive(true);
            PV.RPC("ActiveWeapon", RpcTarget.All, swordIndex, false);
            weapons[1, swordIndex] = true;
            //animator.SetBool("leftGrabing", true);
        }
    }

    public bool isEquiped()
    {
        if (curSword) return true;
        else return false;
    }

    [PunRPC]
    void ActiveWeapon(int weaponIndex, bool isRight)
    {
        Debug.Log(isRight);
        if (isRight)
        {
            rightHand.transform.GetChild(weaponIndex + 5).gameObject.SetActive(true);
            animator.SetBool("rightGrabing", true);
        }
        else
        {
            leftHand.transform.GetChild(weaponIndex + 5).gameObject.SetActive(true);
            animator.SetBool("leftGrabing", true);
        }
    }

    [PunRPC]
    void DeactiveWeapon(int weaponIndex, bool isRight)
    {
        if (isRight)
        {
            rightHand.transform.GetChild(weaponIndex + 5).gameObject.SetActive(false);
        }
        else
        {
            leftHand.transform.GetChild(weaponIndex + 5).gameObject.SetActive(false);
        }
        animator.SetBool("rightGrabing", false);
        animator.SetBool("leftGrabing", false);
    }

    public void SynchroButton()
    {
        rightButtons[0].onClick.AddListener(() => equipSword(0, true));
        rightButtons[1].onClick.AddListener(() => equipSword(1, true));
        rightButtons[2].onClick.AddListener(() => equipSword(2, true));

        leftButtons[0].onClick.AddListener(() => equipSword(0, false));
        leftButtons[1].onClick.AddListener(() => equipSword(1, false));
        leftButtons[2].onClick.AddListener(() => equipSword(2, false));

        //selectButton.onClick.AddListener(CompleteSetting);
    }

    void CompleteSetting()
    {
        //ovrCamera.GetComponent<cshVrHeadMove>().isSetting = false;
    }
}
