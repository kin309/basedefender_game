using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stats
{
    [SerializeField] private List<StatInfo> stats = new List<StatInfo>();
    [SerializeField] private List<StatInfo> instanceStats = new List<StatInfo>();
    private List<StatsUpgrade> appliedUpgrades = new List<StatsUpgrade>();
    public static event Action StatsChanged;

    public List<StatInfo> GetStats()
    {
        return stats;
    }
    public float GetStat(CharacterStat stat)
    {
        foreach (var s in this.instanceStats)
        {
            if (s.type == stat)
            {
                return GetUpgradedValue(s);
            }
        }
        foreach (var s in this.stats)
        {
            if (s.type == stat)
            {
                return GetUpgradedValue(s);
            }
        }

        Debug.LogError($"No stat value found for {stat} on stats");
        return 0;
    }

    public void SetStat(CharacterStat stat, float value)
    {
        foreach (var s in instanceStats)
        {
            if (s.type == stat)
            {
                Debug.Log("Yes");
                s.value = value;
                StatsChanged?.Invoke();
                return;
            }
        }
        foreach (var s in stats)
        {
            if (s.type == stat)
            {
                s.value += value;
                StatsChanged?.Invoke();
                return;
            }
        }
    }

    public void ModifyStat(CharacterStat stat, float value)
    {
        foreach (var s in instanceStats)
        {
            if (s.type == stat)
            {
                s.value += value;
                StatsChanged?.Invoke();
                return;
            }
        }
        foreach (var s in stats)
        {
            if (s.type == stat)
            {
                s.value += value;
                StatsChanged?.Invoke();
                return;
            }
        }
    }

    public void UnlockUpgrade(StatsUpgrade upgrade)
    {
        if (!appliedUpgrades.Contains(upgrade))
        {
            appliedUpgrades.Add(upgrade);
        }
    }

    public void ApplyBuff(StatInfo buff)
    {
        foreach (var stat in stats)
        {
            if (stat.type == buff.type)
            {
                stat.value += buff.value;
                StatsChanged?.Invoke();
            }
        }
    }

    public void ApplyDeBuff(StatInfo buff)
    {
        foreach (var stat in stats)
        {
            if (stat.type == buff.type)
            {
                stat.value -= buff.value;
            }
        }
    }

    public float GetUpgradedValue(StatInfo stat)
    {
        float baseValue = stat.value;
        foreach (var upgrade in appliedUpgrades)
        {
            foreach (StatInfo upgradeStat in upgrade.upgradeToApply)
            {
                
                if (stat.type == upgradeStat.type)
                {
                    if (upgrade.isPercentageUpgrade)
                    {
                        baseValue *= (upgradeStat.value);
                    }
                    else
                    {
                        baseValue += upgradeStat.value;
                    }
                }
                    
            }
        }

        return baseValue;
    }

    public bool Contain(CharacterStat stat)
    {
        foreach (var s in this.instanceStats)
        {
            if (s.type == stat)
            {
                return true;
            }
        }
        foreach (var s in this.stats)
        {
            if (s.type == stat)
            {
                return true;
            }
        }

        return false;
    }
  
}
