using UnityEngine;

/// <summary>
/// create instance of particles
/// </summary>
public class SpecialEffectsHelper : MonoBehaviour {

    /// <summary>
    /// singleton
    /// </summary>
    public static SpecialEffectsHelper Instance;

    public ParticleSystem smokeEffect;
    public ParticleSystem fireEffect;

    void Awake() {
        // register the singleton
        if (Instance != null) {
            Debug.LogError("multiple instances of SpecialEffectsHelper");
        }
        Instance = this;
    }

    /// <summary>
    /// create an explosion at the given location
    /// </summary>
    /// <param name="position"></param>
    public void Explosion(Vector3 position) {
        instantiate(smokeEffect, position);

        instantiate(fireEffect, position);
    }

    /// <summary>
    /// instantiate a ParticleSystem from a prefab
    /// and ensure it is destroyed
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position) {
        ParticleSystem newParticleSystem = Instantiate(
            prefab,
            position,
            Quaternion.identity) as ParticleSystem;

        // ensure object is destroyed
        Destroy(
            newParticleSystem.gameObject,
            newParticleSystem.startLifetime);

        return newParticleSystem;
    }

}
