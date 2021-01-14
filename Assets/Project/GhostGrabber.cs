using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class GhostGrabber : MonoBehaviour
{
    public float timeToGrabGhost = 3.0f;
    [SerializeField] float timeBeforeGrab = 50;
    [SerializeField] float timeBeforeGrabMax = 100;
    public CanvasGroup canvas;
    public float scoreDecrease = -1;

    private void Awake()
    {
        timeBeforeGrab = timeBeforeGrabMax;
        canvas.alpha = 0;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Ghost"))
        {
            GhostMassControler.Multiplier = 5;
        }
    }


    private void OnTriggerStay(Collider collider)
    {
        if (GunController.canGrab)
        {
            if (timeBeforeGrab >= 0)
            {
                if (collider.CompareTag("Ghost"))
                {
                    timeBeforeGrab -= Time.deltaTime * 10;
                    canvas.alpha = 1 - timeBeforeGrab / timeBeforeGrabMax;
                    if (timeBeforeGrab <= 0) timerEnded();
                }
            }
        }
    }
    private void OnTriggerExit(Collider collider)
    {

        if (collider.CompareTag("Ghost"))
        {
            timeBeforeGrab = timeBeforeGrabMax;
            canvas.alpha = 0;

            GameManager.instance.AddScore(scoreDecrease);
            GhostMassControler.Multiplier = 1;
        }
    }

    void timerEnded()
    {
        canvas.alpha = 0;

        timeToGrabGhost = 0.0f; // Set time to 0

        if (GameManager.instance.isStart)
            GameManager.GhostGameOver();
    }

}
