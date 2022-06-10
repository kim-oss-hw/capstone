using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public HitJudgment HitJudgment;

    private void OnTriggerEnter(Collider collider)
    {
        HitJudgment.HitCalculation(collider);
    }

}
