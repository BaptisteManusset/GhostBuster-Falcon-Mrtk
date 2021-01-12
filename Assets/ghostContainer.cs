using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostContainer : MonoBehaviour
{

    public GameObject walls;

    private void OnTriggerEnter(Collider other)
    {

        //if (other.CompareTag("Ghost"))
        //{
        //    Invoke("AddWalls", 2);

        //}
    }

    public void AddWalls()
    {
        Debug.Log("enter");
        walls.SetActive(true);
    }
}
