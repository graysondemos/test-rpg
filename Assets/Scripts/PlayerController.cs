using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private Animator anim;
	private bool moving;
	private Vector2 lastMove;
	private Rigidbody2D rb;
	private static bool playerExists;
	public string startPoint;
    private float moveX;
    private float moveY;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();

		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		moving = false;

        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer)
        {
            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");
        }
        else
        {
            moveX = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            moveY = CrossPlatformInputManager.GetAxisRaw("Vertical");
        }
        
		Vector2 movement = new Vector2 (moveX, moveY);
		rb.velocity = movement * moveSpeed;

		if (moveX != 0 || moveY != 0) {
			moving = true;
			lastMove = new Vector2 (moveX, moveY);
		}

		anim.SetFloat ("MoveX", moveX);
		anim.SetFloat ("MoveY", moveY);
		anim.SetBool ("Moving", moving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}
