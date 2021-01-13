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

    void Awake()
    {
        sphere = GetComponent<SphereManipulator>();
    }

    void Update()
    {
        distance = Vector3.Distance(lamp.position, transform.position);
        mass = Mathf.Lerp(nearMass, farMass, distance / distanceMax);
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
