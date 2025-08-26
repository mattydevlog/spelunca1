using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable_pickup : MonoBehaviour
{
	private bool isInteractable = false;

	void Start()
	{

	}

	void Update()
	{
		if (isInteractable == true && Input.GetKeyDown(KeyCode.E))
			{
			Debug.Log("Interacted");
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("trigger");
		isInteractable = true;
	}

	private void OnTriggerExit(Collider other)
	{
		Debug.Log("left the trigger");
		isInteractable = false;
	}
}

