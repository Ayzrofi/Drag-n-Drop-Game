using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadLevel : MonoBehaviour {
    private static LoadLevel level;
    public static LoadLevel TheInstanceOfLoadLevel
    {
        get
        {
            if (level == null)
                level = FindObjectOfType<LoadLevel>();
            return level;
        }
    }

    public static int WhatTheLevel ;

    public Image BgLevel;
    public GameObject[] Pertanyaan;
    public GameObject[] jawaban;

    public Level[] TheLevel;

    private void Start()
    {
        CreateLevel();
    }
    [ContextMenu("Create Level")]
    public void CreateLevel()
    {
        for (int i = 0; i < Pertanyaan.Length; i++)
        {
            Pertanyaan[i].GetComponent<Image>().sprite = TheLevel[WhatTheLevel].Pertanyaan[i];
            jawaban[i].GetComponent<Image>().sprite = TheLevel[WhatTheLevel].Jawaban[i].SpriteJawaban;
            jawaban[i].GetComponent<ImageControllerV2>().SFX = TheLevel[WhatTheLevel].Jawaban[i].SfxJawaban;
        }

        BgLevel.sprite = TheLevel[WhatTheLevel].LevelBackgroundImage;
    }
}
