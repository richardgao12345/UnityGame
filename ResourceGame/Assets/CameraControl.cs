using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class CameraControl : MonoBehaviour {
	public Transform target;
	public float lookSmooth = 0.09f;
	public Vector3 offsetFromTarget = new Vector3(0,6,-8);
	public float xTilt = 10;
	Vector3 destination = Vector3.zero;
	PlayerMotor playerMotor;
	float rotateVel = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetCameraTarget(Transform t) {
		target = t;
		if (target != null) {
			if (target.GetComponent<PlayerMotor>()) {
				playerMotor = target.GetComponent<PlayerMotor> ();
			}
		} else
			Debug.LogError ("Your camera needs a target");
	}
	void LateUpdate() {
		MoveToTarget ();
		LookAtTarget ();
	}
		
	void MoveToTarget(){
		destination = playerMotor.getRotation() * offsetFromTarget;
		destination += target.position;
		transform.position = destination;
	}
	void LookAtTarget() {
		float eulerYAngle = Mathf.SmoothDampAngle (transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
		transform.rotation = Quaternion.Euler (xTilt, eulerYAngle, 0);
	}
}
