using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceActive : MonoBehaviour
{

    [SerializeField] GameObject objet;

    void Start()
    {
        objet.SetActive(true);
    }
}
