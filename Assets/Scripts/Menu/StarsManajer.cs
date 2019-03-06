using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarsManajer : MonoBehaviour {
    [SerializeField]
    private AudioSource audioSrc;
    public AudioClip ButtonAudioSfx;
    [SerializeField]
    private string LevelToLoad;
    private string levelID = "Level_";
    [SerializeField]
    [Header("Animasi Transisi")]
    private Animator TransitionAnim;
    [Header("Stars Sprite")]
    public Sprite Star_0;
    public Sprite Star_1;
    public Sprite Star_2;
    public Sprite Star_3;
    [Header("Buttons Game Object")]
    public Button[] LevelButton ;
    [Header("Lock Image Game Object")]
    public GameObject[] LockImage;
    [Header("Stars Image Game Object")]
    public List<Image> StarsImage = new List<Image>();


    private void Awake()
    {
        if (audioSrc == null)
            audioSrc = GetComponent<AudioSource>();

        if (AdsManajer.Instance != null)
        {
            AdsManajer.Instance.ShowBanner();
            AdsManajer.Instance.LoadIntertisial();
        }
    }

    private void Start()
    {
        LevelButton[0].interactable = true;
        LockImage[0].SetActive(false);
        // loop untuk unlock system
        for (int i = 0 ; i < LevelButton.Length; i++)
        {
            int level = i;
            LevelButton[i].onClick.AddListener(() => LoadMainGame(level));
            LevelButton[i].onClick.AddListener(() => PlaySfx(ButtonAudioSfx));
            if (PlayerPrefs.GetInt(levelID + i) == 3)
            {
                
                if (i < LevelButton.Length - 1)
                {
                    LevelButton[i + 1].interactable = true;
                    LockImage[i + 1].SetActive(false);
                }
            }
            else
            {
                if (i < LevelButton.Length - 1)
                {
                    LevelButton[i + 1].interactable = false;
                    LockImage[i + 1].SetActive(true);
                } 
            }
        }
        // loop untuk mengatur bintang
        for (int i = 0; i < StarsImage.Count; i++)
        {
            switch (PlayerPrefs.GetInt(levelID + i))
            {
                case 0:
                    StarsImage[i].sprite = Star_0;
                    break;
                case 1:
                    StarsImage[i].sprite = Star_1;
                    break;
                case 2:
                    StarsImage[i].sprite = Star_2;
                    break;
                case 3:
                    StarsImage[i].sprite = Star_3;
                    break;
                // The default Value
                default:
                    StarsImage[i].sprite = Star_0;
                    break;
            }
        }
    }

    public void LoadMainGame(int Lvl)
    {
        if (AdsManajer.Instance != null)
        {
            AdsManajer.Instance.ShowIntertisial();
            AdsManajer.Instance.LoadIntertisial();
        }

        LoadLevel.WhatTheLevel = Lvl;
        Debug.Log(Lvl);
        StartCoroutine(StartLoadScene(LevelToLoad));
        
    }

    public void LoadScene(string name)
    {
        if (AdsManajer.Instance != null)
            AdsManajer.Instance.ShowIntertisial();

        StartCoroutine(StartLoadScene(name));
    }


    IEnumerator StartLoadScene(string SceneName)
    {
        if (TransitionAnim != null)
        {
            TransitionAnim.SetTrigger("End");
        }
        PlaySfx(ButtonAudioSfx);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneName);
    }

    public void PlaySfx(AudioClip clip)
    {
        audioSrc.PlayOneShot(clip);
    }

}
