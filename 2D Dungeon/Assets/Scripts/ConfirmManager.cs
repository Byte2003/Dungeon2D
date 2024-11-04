using Assets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConfirmManager : Singleton<ConfirmManager>
{
    private GameObject confirmMenu;
    private TMP_InputField titleText;

    void Start()
    {
        var uiCanvas = GameObject.Find("UI Canvas");
        confirmMenu = uiCanvas.transform.Find("ConfirmMenu").gameObject;
    }

    public void Buff(BuffType buffType, int amount, int cost)
    {
        EconomyManager.Instance.UpdateCurrentGold(-cost);

        switch (buffType)
        {
            case BuffType.Healths:
                PlayerHealth.Instance.IncreaseMaxHealth(amount);
                break;
            case BuffType.Sword_Damages:
                UpdateWeaponDamage(0, amount);
                break;
            case BuffType.Staff_Damages:
                UpdateWeaponDamage(1, amount);
                break;
            case BuffType.Bow_Damages:
                UpdateWeaponDamage(2, amount);
                break;
        }

        CloseConfirmMenu();
    }

    public void CloseConfirmMenu()
    {
        confirmMenu.SetActive(false);
    }

    public void UpdateWeaponDamage(int indexNum, int damageAmount)
    {
        Transform childTransform = ActiveInventory.Instance.transform.GetChild(indexNum);
        InventorySlot inventorySlot = childTransform.GetComponentInChildren<InventorySlot>();
        inventorySlot.UpdateWeaponDamage(damageAmount);
    }
}
