﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform lookAt;
	public Transform camTransform;

	private Camera cam;
	private float distance = 10.0f;
	private float currentX = 0.0f;
	private float currentY = 0.0f;
	private float sensitivityX = 4.0f;
	private float sensitivityY = 1.0f;

	private void Start() {
		camTransform = transform;
		cam = Camera.main;
	}

	private void Update() {
		currentX += Input.GetAxis ("Mouse X");
		currentX += Input.GetAxis ("Mouse Y");
	}

	private void LateUpdate() {
		Vector3 dir = new Vector3 (0, 0, -distance);
		Quaternion rotation = Quaternion.Euler (currentY, currentX, 0);
		camTransform.position = lookAt.position + rotation * dir;
		camTransform.LookAt (lookAt.position);
	}

}