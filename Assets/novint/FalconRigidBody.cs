using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class FalconRigidBody : MonoBehaviour
{
    public bool defaultPhysic = false;
    public bool enablePhysic = false;



    public float k = 0.5f;
    public float mass = 1;
    public Vector3 device_scale = new Vector3(1.0f, 1.0f, 1.0f);//send 1/4 size in the z dimension
    public int bodyId = 0;
    public Vector3 linearFactors = new Vector3(1.0f, 1.0f, 1.0f);
    public Vector3 angularFactors = new Vector3(1.0f, 1.0f, 1.0f);
    public float friction = 0.8f;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.Sleep();
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;


        Collider collider = GetComponent<Collider>();

        if (collider == null)
        {
            Debug.LogError("missing collider " + gameObject.name, gameObject);
        }
    }

    void Start()
    {
        bodyId = getNextBodyId();
        TogglePhysic(true);
    }

    public void refreshShape()
    {
        Mesh m = GetComponent<MeshFilter>().mesh;
        Vector3[] v = m.vertices;
        int[] f = m.triangles;
        float[] shape = new float[f.Length * 3];

        for (int i = 0; i < f.Length; i++)
        {
            Vector3 vert = v[f[i]];
            vert.Scale(transform.localScale);
            vert.Scale(device_scale);

            shape[i * 3] = vert.x;
            shape[i * 3 + 1] = vert.y;
            shape[i * 3 + 2] = vert.z;
        }
        Vector3 localPosition = transform.localPosition;
        localPosition.Scale(device_scale);


        FalconUnity.sendDynamicShape(bodyId, shape, f.Length / 3, mass, k, localPosition, transform.localRotation, linearFactors, angularFactors, friction);
    }


    public void FixedUpdate()
    {
        Vector3 pos;
        Quaternion orient;


        bool res = FalconUnity.getDynamicShapePose(bodyId, out pos, out orient);
        if (!res)
        {
            return;
        }

        if (enablePhysic == false || defaultPhysic)
        {
            transform.localPosition = pos;
            transform.localRotation = orient;
        }

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




    #region ADD

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Movable") == false) return;

        //Debug.Log("Collided with " + other.gameObject.name);
        TogglePhysic(false);
    }

    void OnTriggerExist(Collider other)
    {
        if (other.CompareTag("Movable") == false) return;
        TogglePhysic(true);
    }

    void TogglePhysic(bool value)
    {
        
        enablePhysic = value;
        if (value == false)
        {
            refreshShape();
            if (rb) rb.isKinematic = !value;
        } else
        {
            if (rb) rb.isKinematic = !value;
        }
    }

    #endregion
}
