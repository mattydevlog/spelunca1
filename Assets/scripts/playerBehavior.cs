using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private int mSpeed = 10;
	[SerializeField] private CharacterController controller;
	public float mouseSensitivity = 2f;
	public Transform cameraTransform;
	private float xRotation = 0f;

	void Start()
    {
		controller = GetComponent<CharacterController>();
		Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        UpdateMovement();
        UpdateCameraLook();
    }

    void UpdateMovement()
    {
		float moveX = Input.GetAxis("Horizontal");
		float moveZ = Input.GetAxis("Vertical");

		Vector3 move = transform.right * moveX + transform.forward * moveZ;
		controller.Move(move * mSpeed * Time.deltaTime);
	}

    void UpdateCameraLook()
    {
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		transform.Rotate(Vector3.up * mouseX);
	}
}
