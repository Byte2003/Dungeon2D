using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private WeaponInfo weaponInfo;

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }

    public void UpdateWeaponDamage(int amount)
    {
        weaponInfo.weaponDamage += amount;
    }
}
