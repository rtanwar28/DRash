using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // makes the emitter play
        ParticleSystem particle = GetComponent<ParticleSystem>();
        particle.Play();
        Destroy(gameObject, particle.duration);
    }

}
