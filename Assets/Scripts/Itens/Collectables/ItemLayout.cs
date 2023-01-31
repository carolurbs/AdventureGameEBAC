using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Itens;
using UnityEngine.UI;
using TMPro;
public class ItemLayout : MonoBehaviour
{
    private ItemSetup _currSetup;
    public Image uiIcon;
    public TextMeshProUGUI uiValue;
    public void LoadItem(ItemSetup setup)
    {
        _currSetup = setup;
        UpdateUI();
    }

    private void UpdateUI()
    {
        uiIcon.sprite = _currSetup.icon;
    }
    public void Update()
    {
        uiValue.text = _currSetup.soInt.value.ToString();
    }
}
