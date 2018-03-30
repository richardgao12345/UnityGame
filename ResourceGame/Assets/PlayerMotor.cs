using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private Vector3 cameraRotation = Vector3.zero;
	public float lookSmooth = 0.09f;
	public Vector3 offsetFromTarget = new Vector3(0,6,-8);
	public float xTilt = 10;
	Vector3 destination = Vector3.zero;

	private Rigidbody rb;
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

	void FixedUpdate() {
		PerformMovement ();
		PerformRotation ();
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

}
