using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetWeaponInfo : MonoBehaviour
{
    [SerializeField]
    private WeaponInfo swordInfo;
    [SerializeField]
    private WeaponInfo staffInfo;
    [SerializeField]
    private WeaponInfo bowInfo;

    private void Start()
    {
        swordInfo.weaponDamage = 4;
        staffInfo.weaponDamage = 2;
        bowInfo.weaponDamage = 1;
    }
}
