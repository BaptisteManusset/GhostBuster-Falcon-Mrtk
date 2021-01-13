using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VrButton : MonoBehaviour
{

    public UnityEvent trigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {

            trigger.Invoke();

        }
    }
}
