using UnityEngine;
using System.Collections;

/// <summary>
/// enemy generic behavior
/// </summary>
public class EnemyScript : MonoBehaviour {

    private WeaponScript[] weapons;

    void Awake() {
        // retrieve weapon only once
        weapons = GetComponentsInChildren<WeaponScript>();
    }

    void Update() {
        foreach (WeaponScript weapon in weapons) {
            // auto-fire
            if (weapon != null && weapon.CanAttack) {
                weapon.Attack(true);
            }
        }
    }
}
