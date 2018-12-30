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
    [Header("Timer Componet")]
    public Slider TimerSlider;
    public Text TimeText;
    private float MaxTime = 60f;
    [Header("Menu win Game Componet")]
    public MenuWinGame menuWin;

    public GameObject CorrectParticle;

    private void Awake()
    {
        MaxTime = 91f;
        TimeText.text = MaxTime.ToString();
        if (audioSrc == null)
            audioSrc = GetComponent<AudioSource>();

        if (menuWin == null)
            menuWin = GetComponentInChildren<MenuWinGame>();
        
        TimerSlider.maxValue = MaxTime;
        TimerSlider.value = TimerSlider.maxValue;
    }

    private void Update()
    {
        if (!GameOver)
        {
            TimerSlider.value -= Time.deltaTime;
            TimeText.text = TimerSlider.value.ToString("f0");
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
    }
    // untuk memunculkan particle effect
    public void CreateParticleEffect(GameObject pos)
    {
        Instantiate(CorrectParticle, pos.transform ,false);
    }
    // untuk menghitung sisa pertanyaan
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
    // kondisi ketika game selesai
    private void GameEnd()
    {
        GameOver = true;

        if (TimerSlider.value > ((MaxTime / 100) * 66) && TimerSlider.value < ((MaxTime / 100) * 100))
        {
            menuWin.FinishGameMenu(3, true);
        } else
        if (TimerSlider.value > ((MaxTime / 100) * 33) && TimerSlider.value < ((MaxTime / 100) * 66))
        {
            menuWin.FinishGameMenu(2, true);
        } else
        if (TimerSlider.value > ((MaxTime / 100) * 0) && TimerSlider.value < ((MaxTime / 100) * 33))
        {
            menuWin.FinishGameMenu(1, true);
        } else
        {
            menuWin.FinishGameMenu(0, false);
        }
    }
}
