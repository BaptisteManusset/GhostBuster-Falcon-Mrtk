using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

	public Transform destination;

	public Transform obj;
	
	// Update is called once per frame
	void Update () {
		obj.LookAt(destination);
	}
}
