using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
	[Header("Prefab")]
	public GameObject pointPrefab;

	[Space(10)]

	[Header("Room Customizable")]
	public Vector3 center;
	public Vector3 size;

	// Launch at the beginning
	void Start () 
	{
		SpawnPoints();
	}

	// Launch th respawn of the prefab
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
			SpawnPoints();
    }

	// Spawn prefab
	public void SpawnPoints()
    {
		Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

		Instantiate(pointPrefab, pos, Quaternion.identity);
    }

	// Room size 
	void OnDrawGizmosSelected()
    {
		Gizmos.color = new Color(1, 0, 0, 0.5f);
		Gizmos.DrawWireCube(center, size);
    }
}
