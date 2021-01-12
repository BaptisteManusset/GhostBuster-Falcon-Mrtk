using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalibrationPlacement : MonoBehaviour
{
    public bool CalibrationIsOk = false;

    public GameObject walls;
    public Button next;

    [Space(30)]
    [Header("Calibration object")]
    public GameObject calibrationSphere;
    public MeshRenderer rend;
    public float radius = 1;

    public Transform center;
    public Text consigne;

    public Material bad;
    public Material good;

    void Awake()
    {
        next.interactable = false;
        walls.SetActive(false);
    }


    void Update()
    {
        if (CalibrationIsOk == false)
        {
            float distance = Vector3.Distance(calibrationSphere.transform.position, center.position);
            if (distance < radius)
            {
                Debug.Log("Calibration reussis");
                rend.material = good;
                CalibrationIsOk = true;
                next.interactable = true;


                walls.SetActive(true);
                consigne.text = "<b>La calibration est reussit</b>, attendez que le second joueur soit prêt";
            } else
            {
                rend.material = bad;
                CalibrationIsOk = false;
            }
        }
    }


    [ContextMenu("OnEndCalibration")]
    public void OnEndCalibration()
    {
        calibrationSphere.SetActive(false);
    }
}
