using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float minSpeed;
	public float maxSpeed;

	float speed;

	public int damageGiven;

	// initialise object of the PlayerScript
	Player playerScript;

	// for explosion game object on hitting
	public GameObject explosion;

    // Start is called before the first frame update
    void Start() {
        
        // used to select random value in the range (maxSpeed not inc)
        speed = Random.Range(minSpeed, maxSpeed);

        playerScript = GameObject.FindGameObjectWithTag("Player")
        	.GetComponent<Player>(); // note - Player here is name of the script
    }

    // Update is called once per frame
    void Update() {

    	// for moving the body down along Y
    	// multiplied with Time.deltaTime - same speed in every time
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    /*
		* Called whenever any collision takes place
		* @param - the object with which it collided 
	*/
    void OnTriggerEnter2D(Collider2D hitObject) {

    	// checking object with the help of Tags
    	if (hitObject.tag == "Player") {

    		// for explosion on hitting
    		Instantiate(explosion, transform.position, Quaternion.identity);

    		// player is hit
    		playerScript.TakeDamage(damageGiven);

    		// for destroying enemy after hitting player
    		Destroy(gameObject);

    	}
    	if (hitObject.tag == "Ground") {

    		// for explosion on hitting
    		Instantiate(explosion, transform.position, Quaternion.identity);
    		Destroy(gameObject);
    	}

    }
}
