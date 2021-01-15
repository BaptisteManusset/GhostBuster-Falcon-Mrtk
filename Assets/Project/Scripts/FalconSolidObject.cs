using UnityEngine;
using System.Collections;

public class FalconSolidObject : MonoBehaviour
{

    float k = 0.01f;
    float mass = 0;
    Vector3 device_scale = Vector3.one;
    int bodyId = 0;
    Vector3 linearFactors = Vector3.one;
    Vector3 angularFactors = Vector3.one;
    float friction = 1;

    // Use this for initialization
    void Start()
    {
        bodyId = getNextBodyId();
        refreshShape();

    }

    public void refreshShape()
    {
        Mesh m = GetComponent<MeshFilter>().mesh;
        Vector3[] v = m.vertices;
        Debug.LogWarning("vector3 vertices " + v.Length);
        int[] f = m.triangles;
        float[] shape = new float[f.Length * 3];

        for (int i = 0; i < f.Length; i++)
        {
            Vector3 vert = v[f[i]];
            vert.Scale(transform.localScale);
            vert.Scale(device_scale);
            //				vert = transform.localRotation*vert;

            shape[i * 3] = vert.x;
            shape[i * 3 + 1] = vert.y;
            shape[i * 3 + 2] = vert.z;
        }
        Vector3 localPosition = transform.localPosition;
        localPosition.Scale(device_scale);


        FalconUnity.sendDynamicShape(bodyId, shape, f.Length / 3, mass, k, localPosition, transform.localRotation, linearFactors, angularFactors, friction);
    }


    // Update is called once per frame
    public void FixedUpdate()
    {
        Vector3 pos;
        Quaternion orient;


        bool res = FalconUnity.getDynamicShapePose(bodyId, out pos, out orient);
        if (!res)
        {
            //			Debug.Log("Error getting object pose");
            return;
        }
        transform.localPosition = pos;
        transform.localRotation = orient;
        FalconUnity.updateDynamicShape(bodyId, mass, k, linearFactors, angularFactors, friction);
    }

    static object Lock = new object();
    private static int curId = -1;
    public static int getNextBodyId()
    {
        lock (Lock)
        {
            curId++;
            return curId;
        }
    }
}
