using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

	private PlayerController player;
	public string pointName;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();

		if (player.startPoint == pointName) {
			player.transform.position = transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
