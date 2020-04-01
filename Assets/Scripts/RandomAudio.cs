using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudio : MonoBehaviour {

	AudioSource randomExplosionSound;
	public AudioClip[] sounds;

    // Start is called before the first frame update
    void Start() {

    	randomExplosionSound = GetComponent<AudioSource>();
        int randomSoundIndex = Random.Range(0, sounds.Length);
        randomExplosionSound.clip = sounds[randomSoundIndex];
        randomExplosionSound.Play();
    }

    // Update is called once per frame
    void Update() {
        
    }
}
