using UnityEngine;
using System.Collections;

/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour {

    /// <summary>
    /// speed of the ship
    /// </summary>
    public Vector2 speed = new Vector2(50, 50);

	void Update() {

        #region movement
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(speed.x * inputX, speed.y * inputY);
        movement *= Time.deltaTime;
        transform.Translate(movement);
        #endregion

        #region shooting
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

        if (shoot) {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null) {
                // false b/c player is not an enemy
                weapon.Attack(false);
            }
        }
        #endregion
    }
}
