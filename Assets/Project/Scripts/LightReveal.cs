using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReveal : MonoBehaviour 
{
	// ----- PUBLIC
	[Header ("Ghost")]
	public GameObject ghost;
	public Light lightGhost;

	[Space(10)]

	[Header("Player")]
	public GameObject lightPlayer;

	// ----- PRIVATE
	private float distanceBetweenTwoObject;

	void Update () 
	{
		float distanceBetweenTwoObject = Vector3.Distance(ghost.transform.position, lightPlayer.transform.position);

		if (distanceBetweenTwoObject < 1)
        {
			Debug.Log("COUCOU");

			lightGhost.intensity = 10f;
			// Slow ghost → 
        }
		else
        {
			lightGhost.intensity = 2f;
		}
	}
}
