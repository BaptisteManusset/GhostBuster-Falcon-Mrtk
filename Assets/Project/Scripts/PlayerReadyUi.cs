using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReadyUi : MonoBehaviour
{

    public Color color;

    private Image image;
    private Text text;
    void Start()
    {
        image = GetComponentInChildren<Image>();
        text = GetComponentInChildren<Text>();
    }

    [ContextMenu("Ready")]
    public void Ready()
    {
        image.color = color;
        text.color = color;
        text.text = "Prés";
    }
}
