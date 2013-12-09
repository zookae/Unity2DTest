using UnityEngine;
using System.Collections;

/// <summary>
/// Projectile behavior
/// </summary>
public class ShotScript : MonoBehaviour {

    /// <summary>
    /// Damage inflicted
    /// </summary>
    public int damage = 1;

    /// <summary>
    /// Projectile damage player or enemies?
    /// </summary>
    public bool isEnemyShot = false;

	void Start() {
        Destroy(gameObject, 20);
	}
}
