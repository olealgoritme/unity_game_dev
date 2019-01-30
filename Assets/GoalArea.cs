using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalArea : MonoBehaviour
{

	public Game game;
	private AudioSource reachGoalSound;
	
	void Start() {
		reachGoalSound = GetComponent<AudioSource>();
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {

			reachGoalSound.Play();
			game.ReachedGoal();

		}
	}
	
}
