///*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshVrHeadMove : MonoBehaviour
{
    public GameObject settingWeaponTool;
    public float speedForward = 1;
    public float speedSide = 1;
    public float speedRota = 1;
    public float equipDistance = 6;

    public float RimitX_po = 1;
    public float RimitX_ne = 1;
    public float RimitY_po = 1;
    public float RimitY_ne = 1;
    public float RimitZ_po = 1;
    public float RimitZ_ne = 1;

    private Camera camera;
    private cshSettingWeapon settingWeapon;
    private GameObject player;
    private Transform tr;
    public bool isSetting = true;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        camera = transform.Find("TrackingSpace/CenterEyeAnchor").gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (!player) // player = null 일때
        {
            if (GameObject.Find("MyPlayer") || GameObject.Find("Player"))
            {
                if (GameObject.Find("MyPlayer")) player = GameObject.Find("MyPlayer");
                else player = GameObject.Find("Player");
                settingWeapon = player.GetComponent<cshSettingWeapon>();
                //rightHand = player.transform.
                //Find("PlayerCharacter/root/pelvis/spine_01/spine_02/spine_03/clavicle_r/upperarm_r/lowerarm_r/hand_r").gameObject;
                //leftHand = player.transform.
                //Find("PlayerCharacter/root/pelvis/spine_01/spine_02/spine_03/clavicle_l/upperarm_l/lowerarm_l/hand_l").gameObject;
                //animator = player.transform.Find("PlayerCharacter").gameObject.GetComponent<Animator>();
            }
        }

        MovePlayer();
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            if (isSetting)
            {
                if (!Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, equipDistance))
                {
                    if (settingWeapon.isEquiped())
                    {
                        settingWeapon.unequipSword();
                    }
                }
                else
                {
                    if (settingWeapon.isEquiped())
                    {
                        if(hit.transform.tag == "SetWeapon")
                        {
                            isSetting = false;
                            Destroy(hit.transform.parent.gameObject);
                            settingWeapon.isReady = true;
                        } else
                        {
                            settingWeapon.unequipSword();
                        }
                    }
                    else if (hit.transform.tag == "Broadsword")
                    {
                        settingWeapon.equipSword(0, true);
                    }
                    else if (hit.transform.tag == "Shortsword")
                    {
                        settingWeapon.equipSword(1, true);
                    }
                    else if (hit.transform.tag == "Falchion")
                    {
                        settingWeapon.equipSword(2, true);
                    }
                }
            }
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            if (isSetting)
            {
                if (!Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, equipDistance))
                {
                    if (settingWeapon.isEquiped())
                    {
                        settingWeapon.unequipSword();
                    }
                }
                else
                {
                    if (settingWeapon.isEquiped())
                    {
                        if (hit.transform.tag == "SetWeapon")
                        {
                            isSetting = false;
                            Destroy(hit.transform.parent.gameObject);
                            settingWeapon.isReady = true;
                        } else
                        {
                            settingWeapon.unequipSword();
                        }
                    }
                    else if (hit.transform.tag == "Broadsword")
                    {
                        settingWeapon.equipSword(0, false);
                    }
                    else if (hit.transform.tag == "Shortsword")
                    {
                        settingWeapon.equipSword(1, false);
                    }
                    else if (hit.transform.tag == "Falchion")
                    {
                        settingWeapon.equipSword(2, false);
                    }
                }
            }
        }
    }

    void MovePlayer()
    {
        Vector2 coordMove = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector2 coordRota = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        Vector3 moveDir = new Vector3(coordMove.x * speedSide, 0, coordMove.y * speedForward);
        Vector3 rotaDir = new Vector3(0f, coordRota.x * speedRota, 0f);

        if (!isSetting)
        {
            transform.Translate(moveDir * Time.deltaTime);
        }

        transform.Rotate(rotaDir * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, RimitX_ne, RimitX_po), Mathf.Clamp(transform.position.y, RimitY_ne, RimitY_po), Mathf.Clamp(transform.position.z, RimitZ_ne, RimitZ_po));
    }

    public void spawnSetTool()
    {
        // 무기 setting spawn
        Vector3 pos = new Vector3(0f, 2f, 7f);
        Vector3 rot = new Vector3(0f, 0f, 0f);
        GameObject temp = Instantiate(settingWeaponTool, transform.position, transform.rotation);
        temp.transform.Translate(pos);
        temp.transform.Rotate(rot);
    }
}
//*/