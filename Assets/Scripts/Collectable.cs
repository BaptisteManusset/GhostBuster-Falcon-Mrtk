using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            Collect();
        }
    }

    [ContextMenu("collect")]
    private void Collect()
    {
        Debug.Log("collectaaaaaaaaaaaaaaaaaaaanleeeeeeeeeeeeeeeeeeeeeeee");

        GameManager.instance.AddScore(100);
        if (Spawner.instance) Spawner.instance.SpawnPoints();
        Destroy(gameObject);
    }
}
