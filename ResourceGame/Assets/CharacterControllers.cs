using System.Collections;
using UnityEngine;

public class CharacterControllers : MonoBehaviour {

	private float speed = 5f;
	private float rotationSensitivity = 3;
	Quaternion targetRotation;
	Rigidbody rb;
	private float forwardInput, turnInput;

	public Quaternion TargetRotation {
		get {
			return targetRotation;
		}
	}

	void Start() {
		targetRotation = transform.rotation;
		rb = GetComponent<Rigidbody> ();

		forwardInput = turnInput = 0;
	}
	void Update() {
		GetInput ();
		Turn ();

	}
	void Run() {
		rb.velocity = transform.forward * forwardInput * speed;
	}
	void Turn() {
		targetRotation *= Quaternion.AngleAxis (rotationSensitivity * turnInput * Time.deltaTime, Vector3.up);
		transform.rotation = targetRotation;
	}
	void FixedUpdate() {
		Run ();
	}
	void GetInput() {
		forwardInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
	}
}
