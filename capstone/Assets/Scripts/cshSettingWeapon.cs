using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class cshSettingWeapon : MonoBehaviour
{
    public bool[,] weapons = new bool[2, 3] { { false, false, false }, { false, false, false } };
    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject curSword;
    public Animator animator;
    public PhotonView PV;

    // Start is called before the first frame update
    void Start()
    {
        rightHand = transform.Find("PlayerCharacter/root/pelvis/spine_01/spine_02/spine_03/clavicle_r/upperarm_r/lowerarm_r/hand_r").gameObject;
        leftHand = transform.Find("PlayerCharacter/root/pelvis/spine_01/spine_02/spine_03/clavicle_l/upperarm_l/lowerarm_l/hand_l").gameObject;
        animator = transform.Find("PlayerCharacter").gameObject.GetComponent<Animator>();
        PV = gameObject.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        //PV.RPC("DeactivateWeapon", RpcTarget.All, 1, true);
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
                    if (i == 0) PV.RPC("DeactivateWeapon", RpcTarget.All, j, true);
                    else PV.RPC("DeactivateWeapon", RpcTarget.All, j, false);
                    weapons[i, j] = false;
                }
            }
        }
        curSword = null;
    }

    public void equipSword(int swordIndex, bool isRight)
    {
        if (swordIndex > 2)
        {
            unequipSword();
            return;
        }

        if (isRight)
        {
            curSword = rightHand.transform.GetChild(swordIndex + 5).gameObject;
            //curSword.SetActive(true);
            PV.RPC("ActivateWeapon", RpcTarget.All, swordIndex, true);
            weapons[0, swordIndex] = true;
            //animator.SetBool("rightGrabing", true);
        }
        else
        {
            curSword = leftHand.transform.GetChild(swordIndex + 5).gameObject;
            //curSword.SetActive(true);
            PV.RPC("ActivateWeapon", RpcTarget.All, swordIndex, false);
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
            rightHand.transform.GetChild(weaponIndex).gameObject.SetActive(false);
        }
        else
        {
            leftHand.transform.GetChild(weaponIndex).gameObject.SetActive(false);
        }
        animator.SetBool("rightGrabing", false);
        animator.SetBool("leftGrabing", false);
    }
}
