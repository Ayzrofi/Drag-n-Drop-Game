using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomPosisiJawaban : MonoBehaviour {

    public RectTransform[] TargetPosisi;
    public List<RectTransform> Jawaban;

    private void Awake()
    {
        Posisirandom();
        Debug.Log(LoadLevel.WhatTheLevel);
    }
    [ContextMenu("Random Spawn")]
    public void Posisirandom()
    {
        for (int i = 0; i < TargetPosisi.Length; i++)
        {
            int RandPos = Random.Range(0, Jawaban.Count);
            Jawaban[RandPos].anchoredPosition = TargetPosisi[i].anchoredPosition;
            Jawaban.RemoveAt(RandPos);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Application.LoadLevel(Application.loadedLevel);

            if (LoadLevel.WhatTheLevel  < LoadLevel.TheInstanceOfLoadLevel.TheLevel.Length - 1)
            {
                LoadLevel.WhatTheLevel++;
                Debug.Log(LoadLevel.TheInstanceOfLoadLevel.TheLevel[LoadLevel.WhatTheLevel].LevelId);
            }

        }
           
    }
}
