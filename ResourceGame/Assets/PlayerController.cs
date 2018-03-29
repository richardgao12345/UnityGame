using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	private float speed = 5f;
	private float lookSensitivity = 3;
	private PlayerMotor motor;
	// Use this for initialization
	void Start () {
		motor = GetComponent<PlayerMotor> ();
	}
	
	// Update is called once per frame
	void Update () {
		float xMovement = Input.GetAxisRaw ("Horizontal");
		float zMovement = Input.GetAxisRaw ("Vertical");

		//create vectors for movement, transform.right is vector (1,0,0) and transform.forward is vector(0,0,1)
		Vector3 horizontalMovement = transform.right * xMovement;
		Vector3 verticalMovement = transform.forward * zMovement;

		//total velocity
		Vector3 totalMovement = (horizontalMovement + verticalMovement).normalized * speed;

		motor.Move (totalMovement);

		//calculate the x rotation
		float yRotation = Input.GetAxisRaw ("Mouse X");
		Vector3 rotation = new Vector3 (0f, yRotation, 0f) * lookSensitivity;
		motor.Rotate (rotation);
	}
}
