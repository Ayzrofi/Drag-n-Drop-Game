﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using admob;
[RequireComponent(typeof(AudioSource))]
public class SceneController : MonoBehaviour {
    [SerializeField]
    private Animator TransitionAnim;
    [SerializeField]
    private AudioSource audioSrc;
    // for ads counter
    public static int AdsCount = 2;

    private void Awake()
    {
        if (audioSrc == null)
            audioSrc = GetComponent<AudioSource>();
        // ngecek refrensi dari ads manajer
        if(AdsManajer.Instance != null)
        {
            AdsManajer.Instance.ShowBanner();
            AdsManajer.Instance.LoadIntertisial();
        }
    }

    //private void Start()
    //{
    //    Admob.Instance().initSDK("ca-app-pub-3940256099942544~3347511713");
    //}
    // function untuk Next Scene/level 

    public void NextLevel()
    {
        AdsCount--;
        if (AdsCount <= 0)
        {
            if (AdsManajer.Instance != null)
                AdsManajer.Instance.ShowIntertisial();

            AdsCount = 2;
        }

        if (LoadLevel.WhatTheLevel < LoadLevel.TheInstanceOfLoadLevel.TheLevel.Length - 1)
        {
            StartCoroutine(LoadNextLvl());
            LoadLevel.WhatTheLevel++;
        }
        else
        {
            StartCoroutine(StartLoadScene("Menu_Select_Game"));
        }
       
    }

    IEnumerator LoadNextLvl()
    {
        if (TransitionAnim != null)
        {
            TransitionAnim.SetTrigger("End");
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(Application.loadedLevel);
    }
    public void LoadScene(string name)
    {
        AdsCount--;
        if (AdsCount <= 0)
        {
            if (AdsManajer.Instance != null)
                AdsManajer.Instance.ShowIntertisial();

            AdsCount = 2;
        }
        Debug.Log(AdsCount);
        StartCoroutine(StartLoadScene(name));
    }

    IEnumerator StartLoadScene(string SceneName)
    {
        if(TransitionAnim != null)
        {
            TransitionAnim.SetTrigger("End");
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneName);
    }
    // Restart/Play Again
    public void Restart()
    {
        AdsCount--;
        if (AdsCount <= 0)
        {
            if (AdsManajer.Instance != null)
                AdsManajer.Instance.ShowIntertisial();

            AdsCount = 2;
        }
        Debug.Log(AdsCount);
        StartCoroutine(StartRestart());
    }
    IEnumerator StartRestart()
    {
        if (TransitionAnim != null)
        {
            TransitionAnim.SetTrigger("End");
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(Application.loadedLevel);
    }
    // Exit Game
    public void ExitGame()
    {
        StartCoroutine(StartExitGame());
        Debug.Log("ExitGame");
    }
    IEnumerator StartExitGame()
    {
        if (TransitionAnim != null)
        {
            TransitionAnim.SetTrigger("End");
        }
        yield return new WaitForSeconds(1);
        Application.Quit();
    }
    // untuk memainkan audio sfx
    public void PlaySfx(AudioClip clip)
    {
        audioSrc.PlayOneShot(clip);
    }
    // untuk menghapus semua data player
    [ContextMenu("Delete All data Player")]
    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }
}
