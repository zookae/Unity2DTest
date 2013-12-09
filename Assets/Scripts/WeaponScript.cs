using UnityEngine;
using System.Collections;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour {

    /// <summary>
    /// projectile prefab for shooting
    /// </summary>
    public Transform shotPrefab;

    /// <summary>
    /// cooldown in seconds between two shots
    /// </summary>
    public float shootingRate = 0.25f;

    /// <summary>
    /// shot cooldown remaining
    /// </summary>
    private float shootCooldown;

    #region cooldown
    void Start() {
        shootCooldown = 0f;
    }

    void Update() {
        if (shootCooldown > 0) {
            shootCooldown -= Time.deltaTime;
        }
    }
    #endregion

    #region shooting from another script

    /// <summary>
    /// create a new projectile if possible
    /// </summary>
    /// <param name="isEnemy"></param>
    public void Attack(bool isEnemy) {
        if (CanAttack) {
            shootCooldown = shootingRate;

            // create a new shot
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // assign position
            shotTransform.position = transform.position;

            // the isEnemy property
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null) {
                shot.isEnemyShot = isEnemy;
            }

            // make the weapon shot same movement direction
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null) {
                move.direction = this.transform.right; // towards in 2D space is right of sprite
            }
        }
    }

    /// <summary>
    /// is the weapon ready to create a new projectile?
    /// </summary>
    public bool CanAttack {
        get {
            return shootCooldown <= 0f;
        }
    }

    #endregion
}
