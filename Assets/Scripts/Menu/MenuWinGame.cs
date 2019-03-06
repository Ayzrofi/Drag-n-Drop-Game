using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuWinGame : MonoBehaviour {
    [Tooltip("Semua Game Object Pertanyaan")]
    public GameObject AllAnswer;
    [Tooltip("Win / Lose text")]
    public Text resultText;
    [Header("Star Ranking Component")]
    public Image StarImage;
    public Sprite Star0, Star1, Star2, Star3;
    public GameObject ParticleEffect;
    [Header("The Animator")]
    public Animator TransitionAnim;
    public Animator MenuGameAnim;
    [Header("SFX")]
    public AudioClip WinGameSfx;
    public AudioClip LoseGameSfx;
    public AudioSource bgmMusic;
    [Header("Menu Win Game component")]
    public string LevelId;
    public GameObject NextButton;
    public GameObject Keterangan;

    private void Awake()
    {
        //MenuGame.transform.localScale = new Vector3(0, 0, 0);
        //Debug.Log(MenuGame.transform.localScale);
        //MenuGame.SetActive(false);
        Debug.Log(PlayerPrefs.GetInt(LoadLevel.TheInstanceOfLoadLevel.TheLevel[LoadLevel.WhatTheLevel].LevelId));
        if (TransitionAnim == null)
            TransitionAnim = GameObject.Find("Scene Transitions").GetComponent<Animator>();
    }
    // function yg di panggil ketika semua pertanyaan telah dijawab
    public void FinishGameMenu(int AmmountOfTheStar, bool win)
    {
        //MenuGame.SetActive(true);
        bgmMusic.Stop();
        MenuGameAnim.SetTrigger("Open");
        AllAnswer.SetActive(false);
        if (win)
        {
            resultText.text = "You Win !!!";
            GameManajer.TheInstanceOfGameManajer.PlaySfx(WinGameSfx);
            Instantiate(ParticleEffect, StarImage.transform, false);

            switch (AmmountOfTheStar)
            {
                case 1:
                    StarImage.sprite = Star1;
                    NextButton.SetActive(false);
                    Keterangan.SetActive(true);
                    break;
                case 2:
                    StarImage.sprite = Star2;
                    NextButton.SetActive(false);
                    Keterangan.SetActive(true);
                    break;
                case 3:
                    StarImage.sprite = Star3;
                    NextButton.SetActive(true);
                    Keterangan.SetActive(false);
                    break;
                default:
                    StarImage.sprite = Star0;
                    NextButton.SetActive(false);
                    Keterangan.SetActive(true);
                    break; 
            }
            if (AmmountOfTheStar > PlayerPrefs.GetInt(LoadLevel.TheInstanceOfLoadLevel.TheLevel[LoadLevel.WhatTheLevel].LevelId))
            {
                PlayerPrefs.SetInt(LoadLevel.TheInstanceOfLoadLevel.TheLevel[LoadLevel.WhatTheLevel].LevelId, AmmountOfTheStar);
                
            }
        }
        else
        {
            resultText.text = "You Lose !!!";
            GameManajer.TheInstanceOfGameManajer.PlaySfx(LoseGameSfx);
            StarImage.sprite = Star0;
            NextButton.SetActive(false);
            Keterangan.SetActive(true);
        }
    }
}
