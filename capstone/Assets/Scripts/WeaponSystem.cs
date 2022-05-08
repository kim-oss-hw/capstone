using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public float Damage = 10.0f;
    public bool Attackable = true;
    public bool CoolTimeStart = false;
    public float CoolTime = 3.0f;

    IEnumerator CoolTimeLoad()
    {
        CoolTimeStart = false;
        GameObject castbar = GameObject.Find("cast");
        RectTransform castbarXY = castbar.GetComponent<RectTransform>();

        int i = 0;

        while (i < 100)
        {
            i += 1;
            float f = i * 1.0f;
            castbarXY.sizeDelta = new Vector2(10.0f, f);
            yield return new WaitForSeconds(CoolTime / 100.0f);
        }

        Attackable = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CoolTimeStart == true)
        {
            StartCoroutine("CoolTimeLoad");
        }
    }
}
