using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MenuWinGame))]
public class GameManajer : MonoBehaviour {
    [Header("Check This if You Want To Use Spawn Answer Version Gameplay")]
    public bool UsingAnswerSpawnerScript;
    private static GameManajer Gm;
    public static GameManajer TheInstanceOfGameManajer
    {
        get
        {
            if (Gm == null)
                Gm = FindObjectOfType<GameManajer>();
            return Gm;
        }
    }

    [HideInInspector]
    public bool GameOver = false;
    [SerializeField]
    [Header("Ammount All Answer In This Level")]
    private int ammountOfTheAnswer;
    [SerializeField]
    private AudioSource audioSrc;

    public Slider TimerSlider;
    [SerializeField]
    private float MaxTime = 60f;

    public MenuWinGame menuWin;

    public GameObject CorrectParticle;

    private void Awake()
    {
        if (audioSrc == null)
            audioSrc = GetComponent<AudioSource>();

        if (menuWin == null)
            menuWin = GetComponentInChildren<MenuWinGame>();
        
        TimerSlider.maxValue = MaxTime;
        TimerSlider.value = TimerSlider.maxValue;

        //Debug.Log((MaxTime / 100) * 100);
        //Debug.Log((MaxTime / 100) * 66);
        //Debug.Log((MaxTime / 100) * 33);
    }

    private void Update()
    {
        if (!GameOver)
        {
            TimerSlider.value -= Time.deltaTime;
            if (TimerSlider.value <= 0)
            {
                GameEnd();
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
            GameEnd();
    }
    public void PlaySfx(AudioClip SfxClip)
    {
        if (audioSrc.isPlaying)
            audioSrc.Stop();
        //Playing Sfx
        audioSrc.PlayOneShot(SfxClip);
        //Debug.Log(SfxClip);
    }

    public void CreateParticleEffect(GameObject pos)
    {
        Instantiate(CorrectParticle, pos.transform ,false);
    }

    public void AnswerCounter()
    {
        if(ammountOfTheAnswer > 0)
        {
            ammountOfTheAnswer--;
        }

        if (ammountOfTheAnswer <= 0)
        {
            GameEnd();
        }
    }

    private void GameEnd()
    {
        //Debug.Log("Loe Kalah Suuu");
        GameOver = true;

        if (TimerSlider.value > ((MaxTime / 100) * 66) && TimerSlider.value < ((MaxTime / 100) * 100))
        {
            //Debug.Log("Yameteee senpaiiii");
            menuWin.FinishGameMenu(3, true);
        } else
        if (TimerSlider.value > ((MaxTime / 100) * 33) && TimerSlider.value < ((MaxTime / 100) * 66))
        {
            //Debug.Log("yameroo senpaiiii");
            menuWin.FinishGameMenu(2, true);
        } else
        if (TimerSlider.value > ((MaxTime / 100) * 0) && TimerSlider.value < ((MaxTime / 100) * 33))
        {
            //Debug.Log("Dameeee senpaiiii");
            menuWin.FinishGameMenu(1, true);
        } else
        {

            menuWin.FinishGameMenu(0, false);
        }
           

    }
}
