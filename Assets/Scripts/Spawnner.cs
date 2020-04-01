using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour {

	// stores the transform info of all spawn points
	public Transform[] spawnPoints;

	// for the different prefabs - gameObjects
	public GameObject[] hazards;

	// time b/w spawns
	private float timeBtwSpawns;

	// time b/w start spawning
	public float startTimeBtwSpawns;

    // spawning needs to be done multiple times
    // thus inside the update function
    void Update() {

    	if (timeBtwSpawns <= 0) {
    		// enemy will be spawned

    		Transform randomSpawnPoint = spawnPoints[Random.Range(
    			0, spawnPoints.Length)];

    		GameObject randomHazard = hazards[Random.Range(0, hazards.Length)];

    		// creating the new object 

    		/*
				* for creating new game objects in unity

				* @param randomHazard - the game object to spawn
				* @param randomSpawnPoint.position - the postition where to spawn
				* @param Quaternion.identity - (means no particular rotation),mention the rotation
    		*/
    		Instantiate(randomHazard, randomSpawnPoint.position,Quaternion.identity);

    		// for time delay btw spawns
    		timeBtwSpawns = startTimeBtwSpawns;

    	} else {

    		timeBtwSpawns -= Time.deltaTime;

    	}
        
    }

}
