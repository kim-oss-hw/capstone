using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHit : MonoBehaviour
{
    public HitJudgment HitJudgment;

    private void OnTriggerEnter(Collider collider)
    {
        HitJudgment.WeaponHitCalculation(collider);
    }
}
