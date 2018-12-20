using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerSpawner : MonoBehaviour {
    private static AnswerSpawner instance;
    public static AnswerSpawner TheInstanceOfAnswerSpawner
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AnswerSpawner>();
            }
            return instance;
        }
    }
    [Header("All Answer Image GameObject")]
    public List<GameObject> AnswerObj = new List<GameObject>();

    public void Start()
    {
        for (int i = 0; i < AnswerObj.Count; i++)
        {
            AnswerObj[i].SetActive(false);
        }

        SpawnNewAnswer();
    }

    public void SpawnNewAnswer()
    {
        if(AnswerObj.Count > 0)
        {
            int rand = Random.Range(0, AnswerObj.Count);

            AnswerObj[rand].SetActive(true);
            AnswerObj.RemoveAt(rand);
        }
    }
}
