using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public bool isStart = false;
    public bool isGameover = false;


    [Space(30)]
    public float time;
    public float duration;
    public GameObject clock;

    [Space(30)]
    public UnityEvent ghostGameOver;
    public UnityEvent hunterGameOver;
    public UnityEvent playEvent;
    public GameObject[] ObjectsToReset;



    //public GameObject cubecontainer;

    [Space(30)]
    public AudioClip horloge;
    public AudioClip music;
    public AudioClip collisionSound;



    public void Awake()
    {
        instance = this;
        Time.timeScale = 0;

        foreach (GameObject item in ObjectsToReset)
        {
            item.SetActive(false);
        }
        SoundManager.Instance.PlayMusic(music);

    }


    public void Play()
    {
        Time.timeScale = 1;
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

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
