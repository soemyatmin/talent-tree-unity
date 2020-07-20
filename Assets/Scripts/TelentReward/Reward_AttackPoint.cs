using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward_AttackPoint : Telent {
    public int AttackPoint;

    public override void Reward() {
        base.Reward();
        ShopManager.Instance.GainAttackPoint(AttackPoint);
    }
}
