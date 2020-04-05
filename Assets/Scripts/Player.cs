using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float speed;

	private float input;

	public int health;

	public Text healthDisplay;

	double gameScore;

	public Text playerScore;

	public GameObject gameOverPanel;

	AudioSource playerHurtSound;

	Rigidbody2D rb;

	Animator anim;

	//player dash setup
	public float startDashTime;
	private  float dashTime;
	public float boostSpeed;
	private bool isDashing;

	// AudioSource dashSound;

    // Start is called before the first frame update
    void Start() {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthDisplay.text = health.ToString();
        playerHurtSound = GetComponent<AudioSource>();
        // dashSound = GetComponent<AudioSource>();

    }

    void Update() {

    	gameScore += 0.5 * Time.deltaTime;
    	int intScore = (int)((float)gameScore);
    	playerScore.text = intScore.ToString();
    	// used to set animator parameter to true/false based on input value
    	if (input != 0) {
    		anim.SetBool("isRunning", true);
    	} else {
    		anim.SetBool("isRunning", false);
    	}

    	// for making player face directions
    	// input > 0 --> player moving right
    	if (input > 0) {
    		transform.eulerAngles = new Vector3(0, 0, 0);
    	} else if (input < 0) {
    		// making player rotate 180 degree about Y axis
    		transform.eulerAngles = new Vector3(0, 0, 0);
    	}

    	// pressing space makes player dash
    	if (Input.GetKeyDown(KeyCode.Space) && isDashing == false) {
    		speed += boostSpeed;
    		isDashing = true;
    		dashTime = startDashTime;
    		// dashSound.Play();
    	}

    	// for reverting dashing when time is up
    	if (dashTime <= 0 && isDashing == true) {
    		speed -= boostSpeed;
    		isDashing = false;
    	} else {
    		dashTime -= Time.deltaTime;
    	}
    }

    // Called once per frame - used when using Unity's Physics Lib
    void FixedUpdate() {
    	
    	// for getting exact values use GetAxisRaw
    	// for getting smooth movements use GetAxis
        input = Input.GetAxisRaw("Horizontal");
        
        // for moving the player
        rb.velocity = new Vector2(input * speed, rb.velocity.y);

    }

    public void TakeDamage(int damageAmount) {

    	health -= damageAmount;

    	// for activating the sound
    	playerHurtSound.Play();

    	// for updating the health as soon as damage given
    	healthDisplay.text = health.ToString();

    	if (health <= 0) {

    		// player is dead - destroy the player object
    		// gameObject refers to the object with this script
    		Destroy(gameObject);

    		// destroying the spawnner
    		Spawnner spawnnerScript = GameObject.FindGameObjectWithTag("Spawnner")
        	.GetComponent<Spawnner>();
        	spawnnerScript.destroySpawnner();

        	// for setting health value to zero
        	healthDisplay.text = "0";

    		// for game over screen
    		gameOverPanel.SetActive(true);


    	} 

    }
}
