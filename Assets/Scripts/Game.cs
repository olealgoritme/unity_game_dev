using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	
	public Transform player;
	public Transform spawnPoint;
	
	private float fpsDisplayRate = 4.0f; 

	private int frameCount = 0;
	private float dt = 0.0f;
	private float fps = 0.0f;
	
    private bool reachedGoal = false;
    private float elapsedTime = 0.0f;
	
	void Start () {
		
	}

	void Update() {

		// Escape Key
		if (Input.GetKeyDown(KeyCode.Escape)) {
			// Show menu?
		}
		
		// Timer
		if (!reachedGoal) {
			elapsedTime = elapsedTime + Time.deltaTime;
		}

		// FPS
		frameCount++;
		dt += Time.deltaTime;
		if (dt > 1.0 / fpsDisplayRate) {
			fps = Mathf.Round(frameCount / dt);
			frameCount = 0;
			dt -= 1.0f / fpsDisplayRate;
		}

		// Lock cursor
		if (Cursor.lockState != CursorLockMode.Locked) {
			Cursor.lockState = CursorLockMode.Locked;
		}


	}

	public void Respawn() {
		player.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		player.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
	
		// Move player back to respawn position
		player.transform.position = spawnPoint.transform.position;
		player.transform.rotation = spawnPoint.transform.rotation;

	}

	public void ReachedGoal() {
		reachedGoal = true;
		
		// disable controllers
		player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
		player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;

		// reset movement
		player.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		player.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			
		// unlock mouse cursor
		if (Cursor.lockState != CursorLockMode.Locked) {
			Cursor.lockState = CursorLockMode.None;
		}
	}
	
	void OnGUI() {
		
		// Game info GUI box
		GUI.Box(new Rect(30, 90, 200, 80), "GAME INFO");
		GUI.Label(new Rect(40, 110, 200, 150), "Time: " + ( (int) elapsedTime).ToString());
		GUI.Label(new Rect(40, 130, 200, 150), "FPS: " + fps);
	
	
		// WoW, You are awesome. 
		if(reachedGoal) {
			GUI.Box(new Rect(Screen.width / 2 - 65, 185, 350, 40), "Wow! Your time was: " + ( (int) elapsedTime).ToString() + " seconds! Next up is level 2!");
			// move to new level? 
		}
	}
}
