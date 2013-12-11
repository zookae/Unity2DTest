using UnityEngine;
using System.Collections;

/// <summary>
/// create instances of sounds
/// </summary>
public class SoundEffectsHelper : MonoBehaviour {

    /// <summary>
    /// singleton
    /// </summary>
    public static SoundEffectsHelper Instance;

    public AudioClip explosionSound;
    public AudioClip playerShotSound;
    public AudioClip enemyShotSound;

    void Awake() {
        // register the singleton
        if (Instance != null) {
            Debug.LogError("multiple instances of SoundEffectsHelper!");
        }
        Instance = this;
    }

    /// <summary>
    /// play a given sound
    /// assumed 2D sound so position is irrelevant
    /// </summary>
    /// <param name="originalClip"></param>
    private void MakeSound(AudioClip originalClip) {
        // clip is not 3D audio clip, so position doesn't matter
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }

    public void MakeExplosionSound() {
        MakeSound(explosionSound);
    }

    public void MakePlayerShotSound() {
        MakeSound(playerShotSound);
    }

    public void MakeEnemyShotSound() {
        MakeSound(enemyShotSound);
    }


}
