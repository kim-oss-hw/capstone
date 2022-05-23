using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class WeaponSystem : MonoBehaviour, IPunObservable
{
    public float Damage = 10.0f;
    public bool Attackable = true;
    public bool CoolTimeStart = false;
    public float CoolTime = 0.5f;

    public GameObject castbar;
    public bool Weaponbool = false;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //Debug.Log("나 : " + Weaponbool);
            stream.SendNext(Damage);
            stream.SendNext(Weaponbool);
        }
        else
        {
            this.Damage = (float)stream.ReceiveNext();
            this.Weaponbool = (bool)stream.ReceiveNext();

            //Debug.Log("상대방 : " + Weaponbool);
        }
    }

    IEnumerator CoolTimeLoad()
    {
        CoolTimeStart = false;
        castbar = GameObject.Find("cast");
        RectTransform castbarXY = castbar.GetComponent<RectTransform>();

        int i = 0;

        while (i < 100)
        {
            i += 1;
            float f = i * 1.0f;

            castbarXY.offsetMin = new Vector2(637.0f, 1618.0f + 500.0f - (i * 5.0f));
            castbarXY.offsetMax = new Vector2(2037.0f, 618.0f);

            //castbarXY.sizeDelta = new Vector2(i * 10.0f, f);
            yield return new WaitForSeconds(CoolTime / 100.0f);
        }

        Attackable = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable()
    {
        Weaponbool = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Weaponbool == true)
        {
            gameObject.SetActive(true);
        }

        if (CoolTimeStart == true)
        {
            StartCoroutine("CoolTimeLoad");
        }
    }
}
