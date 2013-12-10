using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// parallax scrolling script
/// </summary>
public class ScrollingScript : MonoBehaviour {

    /// <summary>
    /// scroll speed
    /// </summary>
    public Vector2 speed = new Vector2(2, 2);


    /// <summary>
    /// movement direction
    /// </summary>
    public Vector2 direction = new Vector2(-1, 0);

    /// <summary>
    /// should movement be applied to camera?
    /// </summary>
    public bool isLinkedToCamera = false;
    
    /// <summary>
    /// is it looping?
    /// </summary>
    public bool isLooping = false;

    /// <summary>
    /// list of children w/a renderer
    /// </summary>
    private List<Transform> backgroundPart;

    void Start() {
        if (isLooping) {
            backgroundPart = new List<Transform>();

            for (int i = 0; i < transform.childCount; i++) {
                Transform child = transform.GetChild(i);

                // add only visible children
                if (child.renderer != null) {
                    backgroundPart.Add(child);
                }
            }

            // sort by position
            // note: getting from left -> right (x); needs adjustment for other scrolling directions
            backgroundPart = backgroundPart.OrderBy(t => t.position.x).ToList();
        }
    }

    void Update() {
        // movement
        Vector2 movement = new Vector2(speed.x * direction.x, speed.y * direction.y);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        // move camera
        if (isLinkedToCamera) {
            Camera.main.transform.Translate(movement);
        }

        // loop
        if (isLooping) {
            // get first object
            Transform firstChild = backgroundPart.FirstOrDefault();

            
            if (firstChild != null) {

                // check if child is already (partly) before camera
                if (firstChild.position.x < Camera.main.transform.position.x) {

                    // if child is left of camera, test if completely outside and needs to cycle
                    if (firstChild.renderer.isVisibleFrom(Camera.main) == false) {

                        // get last child position
                        Transform lastChild = backgroundPart.LastOrDefault();
                        Vector3 lastPosition = lastChild.transform.position;
                        Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);

                        // set position of the recycled child to be after last child
                        firstChild.position = new Vector3(lastPosition.x + lastSize.x, 
                            firstChild.position.y, firstChild.position.z);

                        // set recycled child to the last position of list
                        backgroundPart.Remove(firstChild);
                        backgroundPart.Add(firstChild);
                    }
                }
            }
        }
    }
}
