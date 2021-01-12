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


    public float loadMax = 100;
    public float load = 0;
    public float loadIncrease = 10;
    public float loadDecrease = -10;

    public bool canShot = true;

    public GameObject raycast;




    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
    }

    private void FixedUpdate()
    {
        //if (ControlGachette())
        //{
        //    if (canShot)
        //    {



        //        load += loadDecrease;

        //        load = Mathf.Max(load, 0);

        //        if(load <= 0)
        //            canShot = false;
        //    }
        //} else
        //{
        //    if (load < loadMax)
        //    {
        //        load += loadIncrease;
        //    }

        //}


        //if (load >= loadMax)
        //{
        //    load = Mathf.Min(load, loadMax);
        //    canShot = true;
        //}


        canShot = ControlGachette();



        raycast.SetActive(canShot);
        //image.fillAmount = load / loadMax;



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
