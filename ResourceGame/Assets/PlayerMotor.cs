using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private float jump = 0;
	private float totalTimeHeld = 0;
	private bool held = false;
	//this variable currently not used
	private Vector3 cameraRotation = Vector3.zero;
	public float downAccel = 0.75f;
	public float distToGround = 0.1f;
	public float jumpVelocity = 25;
	public LayerMask ground;

	private Rigidbody rb;

	bool Grounded() {
		return Physics.Raycast (transform.position, Vector3.down, distToGround + 1);		
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//this function takes in a new velocity and changes the player's movement
	public void Move(Vector3 newVelocity) {
		velocity = newVelocity;
	}
	public void Rotate(Vector3 newRotation) {
		rotation = newRotation;
	}
	public void RotateCamera(Vector3 camRotation) {
		cameraRotation = camRotation;
	}
	public Quaternion getRotation() {
		return rb.rotation;
	}
	public void Jumping(float newJump) {
		jump = newJump;
	}

	void FixedUpdate() {
		PerformMovement ();
		PerformRotation ();
		PerformJump ();
	}

	void PerformMovement() {
		if (velocity != Vector3.zero) {
			//move player to player position plus the velocity
			rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);
		}
	}
		
	void PerformRotation() {
		rb.MoveRotation (rb.rotation * Quaternion.Euler (rotation));
	}
	void PerformJump() {
		if (jump > 0 && Grounded ()) {
			held = false;
			totalTimeHeld = 0;
			rb.AddForce (Vector3.up * jumpVelocity);
		} else if (jump == 0 && !Grounded () || held) {
			rb.AddForce (Vector3.down * 40);
		} else {
			totalTimeHeld += Time.deltaTime;
			if (totalTimeHeld > 1) {
				held = true;
			}
		}
	}

}
