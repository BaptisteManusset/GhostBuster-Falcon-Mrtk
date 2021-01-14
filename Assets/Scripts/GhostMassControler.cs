using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMassControler : MonoBehaviour
{

    public Transform lamp;
    public Light lightGhost;
    public float distance;
    public float distanceMax = 3;

    public float nearMass = .03f;
    public float farMass = .019f;
    public float mass = 0;
    SphereManipulator sphere;

    public static int Multiplier = 1;

    void Awake()
    {
        Multiplier = 1;
        sphere = GetComponent<SphereManipulator>();
    }

    void Update()
    {
        distance = Vector3.Distance(lamp.position, transform.position);
        mass = Mathf.Lerp(nearMass, farMass, distance / distanceMax) * Multiplier;
        sphere.godObjectMass = mass;

        if (distance < 1)
        {
            lightGhost.intensity = 10f;
        } else
        {
            lightGhost.intensity = 2f;
        }
    }
}
