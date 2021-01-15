using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CalibrationPlacement : MonoBehaviour
{
    public static CalibrationPlacement instance;


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


    [Space(30)]
    [Header("Calibration fin")]
    [TextArea] public string finCalibrage = "<b>La calibration est reussit</b>, Maintenant récuperer l'objet qui vient d'apparaitre pour gagner des points";
    public GameObject collectable;

    [Space(30)]
    [Header("Collectable attrapé")]
    public bool collectableAttrape;
    [TextArea] public string finCollectable = "<b>Vous avez attrapé des points</b>";
    [TextArea] public string attenteJoueurVr = "<b>En attente du joueur en Vr</b>";

    [Space(30)]
    [Header("Fin")]
    //public bool enabletestNextStep = false;
    [SerializeField] bool falconReady = false;
    [SerializeField] bool vrReady = false;
    public UnityEvent fin;

    public PlayerReadyUi falconUi;
    public PlayerReadyUi vrUi;




    void Awake()
    {
        instance = this;
        next.interactable = false;
        walls.SetActive(false);
        collectable.SetActive(false);
    }

    public void FalconValidate()
    {
        Debug.Log("Falcon Validate");

        falconReady = true;
        falconUi.Ready();
    }

    public void VrValidate()
    {

        Debug.Log("Vr Validate");

        vrReady = true;
        vrUi.Ready();
    }


    void Update()
    {
        if (CalibrationIsOk == false)
        {
            float distance = Vector3.Distance(calibrationSphere.transform.position, center.position);
            if (distance < radius)
            {
                CalibrationReussie();
            } else
            {
                rend.material = bad;
                CalibrationIsOk = false;
                //enabletestNextStep = true;
            }
        }

        if (collectableAttrape == false && CalibrationIsOk && GameManager.instance.score > 10)
        {
            consigne.text = finCollectable;
            collectableAttrape = true;
        }

        if (falconReady && !vrReady) consigne.text = attenteJoueurVr;

        if (falconReady && vrReady) StartCoroutine("NtmLegroupe");

    }



    IEnumerator NtmLegroupe() {

        yield return new WaitForSeconds(3);
        Debug.Log("prout");
        fin.Invoke();
    }

    private void CalibrationReussie()
    {
        Debug.Log("Calibration reussis");
        rend.material = good;
        CalibrationIsOk = true;
        walls.SetActive(true);
        consigne.text = finCalibrage;
        collectable.SetActive(true);
    }
    public void OnEndCalibration()
    {
        calibrationSphere.SetActive(false);
    }
}
