using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Stats Upgrade")]
public class StatsUpgrade : Upgrade
{
    public List<Stats> unitsToUpgrade = new List<Stats>();
    public List<StatInfo> upgradeToApply;
    public bool isPercentageUpgrade = false;

    public override void DoUpgrade()
    {
        foreach (var unitToUpgrade in unitsToUpgrade)
        {
            unitToUpgrade.UnlockUpgrade(this);
        }
    }
}
