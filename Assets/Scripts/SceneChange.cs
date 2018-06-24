using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	public string levelName;
	private PlayerStartPoint startPoint;
	public string exitPoint;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name == "Player") {
			SceneManager.LoadScene (levelName);
			player.startPoint = exitPoint;
		}
	}
}
