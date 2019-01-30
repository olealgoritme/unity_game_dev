using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public Game game;
	public Transform player;
	public Transform spawnPoint;

	private AudioSource restartSound;

	void Start() {
		restartSound = GetComponent<AudioSource>();
	}
	
	void OnTriggerEnter(Collider other) {

		restartSound.Play();
		game.Respawn();
	}
}
