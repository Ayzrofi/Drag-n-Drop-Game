using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsManajer : MonoBehaviour {
    public string levelID;
    [Header("Stars Sprite")]
    public Sprite Star_0;
    public Sprite Star_1;
    public Sprite Star_2;
    public Sprite Star_3;
    public Button[] LevelButton ;
    public GameObject[] LockImage;
    [Header("Stars Image Game Object")]
    public List<Image> StarsImage = new List<Image>();
    
    private void Start()
    {
        LevelButton[0].interactable = true;
        LockImage[0].SetActive(false);
        // loop untuk unlock system
        for (int i = 0 ; i < LevelButton.Length; i++)
        {

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


}
