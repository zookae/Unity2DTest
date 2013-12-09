using UnityEngine;
using System.Collections;

/// <summary>
/// Moves the current game object
/// </summary>
public class MoveScript : MonoBehaviour {

    /// <summary>
    /// speed of the ship
    /// </summary>
    public Vector2 speed = new Vector2(10, 10);

    public Vector2 direction = new Vector2(-1, 0);

    void Update() {

        Vector2 movement = new Vector2(speed.x * direction.x, speed.y * direction.y);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }
}
