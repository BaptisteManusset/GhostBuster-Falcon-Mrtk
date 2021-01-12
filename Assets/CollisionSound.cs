using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public SoundType soundType = SoundType.wood;
    bool wait;

    void OnCollisionEnter(Collision collision)
    {
        if (wait == false)
        {
            SoundManager.Instance.PlayShot(GameManager.instance.collisionSound);
            Invoke("Waiting",1);
        }
    }

    void Waiting()
    {
        wait = false;
    }
}


public enum SoundType
{
    wood,
    glass,
    brick
}
