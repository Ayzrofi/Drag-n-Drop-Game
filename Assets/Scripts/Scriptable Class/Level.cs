using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu()]
public class Level : ScriptableObject {
    [Tooltip("Level Id Untuk menyimpan data PlayerPrefs Harus Dimulai dari 0 & Dengan Konteks 'Level_'+ no Seperti 'Level_0' ")]
    public new string LevelId;
    [Header("BackGround Level")]
    public Sprite LevelBackgroundImage;
    [Header("Pertanyaan (Shiloute)")]
    public Sprite[] Pertanyaan;
    [Header("Jawaban (Color)")]
    public Answer[] Jawaban;
    
}

[System.Serializable]
public class Answer
{
    public Sprite SpriteJawaban;
    public AudioClip SfxJawaban;
}
