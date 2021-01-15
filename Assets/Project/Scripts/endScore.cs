using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endScore : MonoBehaviour
{

    public Text scoreUi;
    public int bonus = 200;

    void Start()
    {
        GameManager.instance.score += bonus;
        scoreUi.text = "Score" + Mathf.Round(GameManager.instance.score);
    }


}
