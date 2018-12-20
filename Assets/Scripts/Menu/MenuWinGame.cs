using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuWinGame : MonoBehaviour {
    public GameObject AllAnswer;

    public Text resultText;
    [Header("Star Result Var")]
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
    [Header("Id This Level (Very Important !!!)")]
    public string LevelId;

    private void Awake()
    {
        //MenuGame.transform.localScale = new Vector3(0, 0, 0);
        //Debug.Log(MenuGame.transform.localScale);
        //MenuGame.SetActive(false);

        if (TransitionAnim == null)
            TransitionAnim = GameObject.Find("Scene Transitions").GetComponent<Animator>();
    }

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
                    break;
                case 2:
                    StarImage.sprite = Star2;
                    break;
                case 3:
                    StarImage.sprite = Star3;
                    break;
                default:
                    StarImage.sprite = Star0;
                    break;
            }
            if(AmmountOfTheStar > PlayerPrefs.GetInt(LevelId))
            {
                PlayerPrefs.SetInt(LevelId, AmmountOfTheStar);
            }
           
        }
        else
        {
            resultText.text = "You Lose !!!";
            GameManajer.TheInstanceOfGameManajer.PlaySfx(LoseGameSfx);
            StarImage.sprite = Star0;
        }
    }

    //public void LoadScene(string WhatNameSceneToLoad)
    //{
    //    StartCoroutine(StartLoadScene(WhatNameSceneToLoad));
    //}

    //IEnumerator StartLoadScene(string theSceen)
    //{
    //    TransitionAnim.SetTrigger("End");
    //    yield return new WaitForSeconds(1f);
    //    SceneManager.LoadScene(theSceen);
    //}
}
