using UnityEngine;
using System.Collections;

/// <summary>
/// Handle hitpoints and damage
/// </summary>
public class HealthScript : MonoBehaviour {

    /// <summary>
    /// Total health points
    /// </summary>
    public int hp = 2;

    /// <summary>
    /// Enemy or player?
    /// </summary>
    public bool isEnemy = true;

    void OnTriggerEnter2D(Collider2D collider) {
        
        // is this a shot?
        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
        if (shot != null) {
            // avoid friendly fire
            if (shot.isEnemyShot != isEnemy) {
                hp -= shot.damage;

                // destroy the shot
                // remember to always target the game object
                // o.w. just remove the script
                Destroy(shot.gameObject);

                if (hp <= 0) {
                    SpecialEffectsHelper.Instance.Explosion(transform.position);

                    Destroy(gameObject);
                }
            }
        }
    }
}
