using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class intro : MonoBehaviour
{

    public UnityEvent action;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) action.Invoke();
    }
}
