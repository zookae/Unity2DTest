using UnityEngine;
using System.Collections;

/// <summary>
/// enemy generic behavior
/// </summary>
public class EnemyScript : MonoBehaviour {

    private bool hasSpawn;
    private MoveScript moveScript;
    private WeaponScript[] weapons;

    void Awake() {
        // retrieve weapon only once
        weapons = GetComponentsInChildren<WeaponScript>();

        // retrieve scripts to disable when not spawned
        moveScript = GetComponent<MoveScript>();
    }

    // disable everything to start
    void Start() {
        hasSpawn = false;

        collider2D.enabled = false;

        moveScript.enabled = false;
        foreach (WeaponScript weapon in weapons) {
            weapon.enabled = false;
        }
    }

    void Update() {
        if (hasSpawn == false) {
            if (renderer.isVisibleFrom(Camera.main)) {
                Spawn();
            }
        }
        else {
            foreach (WeaponScript weapon in weapons) {
                // auto-fire
                if (weapon != null && weapon.CanAttack) {
                    weapon.Attack(true);
                }
            }

            // if out of camera, then destroy object
            if (renderer.isVisibleFrom(Camera.main) == false) {
                Destroy(gameObject);
            }
        }
    }

    // activate self
    private void Spawn() {
        hasSpawn = true;

        collider2D.enabled = true;
        moveScript.enabled = true;
        foreach(WeaponScript weapon in weapons) {
            weapon.enabled = true;
        }
    }
}
