using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class GhostGrabber : MonoBehaviour
{
    public float timeToGrabGhost = 3.0f;
    [SerializeField] float timeBeforeGrab = 50;
    [SerializeField] float timeBeforeGrabMax = 100;
    public CanvasGroup canvas;

    private void Awake()
    {
        timeBeforeGrab = timeBeforeGrabMax;
        canvas.alpha = 0;
    }


    //private void Update()
    //{
    //    ReadAxes();
    //}


    //public static void ReadAxes()
    //{
    //    var inputManager = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0];

    //    SerializedObject obj = new SerializedObject(inputManager);

    //    SerializedProperty axisArray = obj.FindProperty("m_Axes");

    //    if (axisArray.arraySize == 0)
    //        Debug.Log("No Axes");

    //    for (int i = 0; i < axisArray.arraySize; ++i)
    //    {
    //        var axis = axisArray.GetArrayElementAtIndex(i);

    //        var name = axis.FindPropertyRelative("m_Name").stringValue;
    //        var axisVal = axis.FindPropertyRelative("axis").intValue;
    //        var inputType = (InputType)axis.FindPropertyRelative("type").intValue;

    //        Debug.Log(name + "> " + axisVal + "> " + inputType);
    //    }
    //}

    //public enum InputType
    //{
    //    KeyOrMouseButton,
    //    MouseMovement,
    //    JoystickAxis,
    //};


    private void OnTriggerStay(Collider collider)
    {

        if (timeBeforeGrab >= 0)
        {
            if (collider.CompareTag("Ghost"))
            {
                timeBeforeGrab -= Time.deltaTime * 10;
                canvas.alpha = 1 - timeBeforeGrab / timeBeforeGrabMax;
                if (timeBeforeGrab <= 0) timerEnded();
            }
        }
    }


    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Ghost"))
        {
            timeBeforeGrab = timeBeforeGrabMax;
            canvas.alpha = 0;
        }
    }

    void timerEnded()
    {
        canvas.alpha = 0;

        timeToGrabGhost = 0.0f; // Set time to 0
        GameManager.GhostGameOver();
    }


}
