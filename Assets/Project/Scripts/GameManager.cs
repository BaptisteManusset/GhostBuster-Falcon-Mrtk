using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public bool isStart = false;
    public bool isGameover = false;
    public bool isTuto = false;


    [Space(30)]
    public float score = 0;


    [Space(30)]
    public float time;
    public float duration;

    [Header("Clock")]
    public GameObject clock;
    public Text clockText;




    [Space(30)]
    public UnityEvent ghostGameOver;
    public UnityEvent hunterGameOver;
    public UnityEvent tutoEvent;
    public UnityEvent playEvent;
    public GameObject[] ObjectsToReset;

    public GameObject intro;

    [Space(30)]
    public AudioClip horloge;
    public AudioClip music;
    public AudioClip collisionSound;

    public Text scoreText;

    public void Awake()
    {
        instance = this;

        foreach (GameObject item in ObjectsToReset)
        {
            item.SetActive(false);
        }
        SoundManager.Instance.PlayMusic(music);


        intro.SetActive(true);
    }
    public void Tutorial()
    {
        Debug.Log("Tutorial");
        isTuto = true;
        tutoEvent.Invoke();
    }
    public void Play()
    {
        score = 0;
        isTuto = false;
        isStart = true;
        isGameover = false;
        time = 0;
        playEvent.Invoke();
    }
    public void Update()
    {
        if (isStart && !isGameover)
        {
            time += Time.deltaTime;

            clockText.text = 60 - Mathf.Ceil(time % 60) + "";
            clock.transform.Rotate(0, 0, Time.deltaTime / duration * 360);
            if (time >= duration)
            {
                isStart = false;
                HunterGameOver();

                SoundManager.Instance.Play(horloge);
            }
        }
    }
    [ContextMenu("👻 GameOver")]
    public void GameoverG()
    {
        if (isGameover) return;

        GameManager.GhostGameOver();
    }
    public static void GhostGameOver()
    {
        if (GameManager.instance.isGameover) return;

        GameManager.instance.isGameover = true;
        GameManager.instance.ghostGameOver.Invoke();
    }
    [ContextMenu("🧨🎮 GameOver")]
    void HunterGameOver()
    {
        if (isGameover) return;

        isGameover = true;
        GameManager.instance.hunterGameOver.Invoke();
    }

    public void AddScore(float value)
    {
        score += value;
        scoreText.text = "Score " + Mathf.Round(score);
    }

    public void Restart()
    {
        Invoke("ReloadScene", 1);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    [ContextMenu("SKIP TUTO")]
    public void skipAll()
    {

        calibrationPlacement.gameObject.SetActive(true);
        calibrationPlacement.fin.Invoke();
    }

    public CalibrationPlacement calibrationPlacement;
}
