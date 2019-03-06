using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomPosisiPertanyaan : MonoBehaviour {

    public float MinX, MaxX, MinY, MaxY;

    //RectTransform RecTransform;

    //private void Awake()
    //{
    //    RecTransform = GetComponent<RectTransform>();
    //}
    private void Start()
    {
        RandomPos();
    }

    [ContextMenu("Random Pos")]
    public void RandomPos()
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY));
    }
}
