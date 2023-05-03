using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Upgrade upgrade;
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI description;

    void Start()
    {
        SetButton();
    }

    public void SetButton()
    {
        icon.sprite = upgrade.icon;
        description.text = upgrade.description;
    }
}
