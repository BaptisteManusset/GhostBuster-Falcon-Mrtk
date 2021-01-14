using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class GunController : MonoBehaviour
{
    public Image image;

    public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");

    SteamVR_Behaviour_Pose trackedObj;
    public bool gachettePressed;


    public bool canShot = true;

    public GameObject raycast;

    [Header("Start delay")]
    public bool locked = true;
    public float delay = 1;

    public static bool canGrab = false;




    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
        Invoke("Unlock", delay);
        canGrab = false;
    }

    void Unlock()
    {
        Debug.Log("CAN GRAB");
        locked = false;
        canGrab = true;
    }

    private void FixedUpdate()
    {
        if (locked == false)
        {
            canShot = ControlGachette();
            raycast.SetActive(canShot);
        }
    }

    private bool ControlGachette()
    {
        if (spawn.GetStateDown(trackedObj.inputSource))
        {
            gachettePressed = true;
        } else if (spawn.GetStateUp(trackedObj.inputSource))
        {
            gachettePressed = false;
        }
        return gachettePressed;
    }
}
