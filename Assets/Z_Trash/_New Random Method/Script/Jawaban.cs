using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jawaban : MonoBehaviour {
    // cuma inkapsulasi biasa 
    private static Jawaban instance;
    public static Jawaban Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Jawaban>();
            }
            return instance;
        }
    }
    // list dari pertanyaan sama saja seperti array 
    public List<GameObject> Questions = new List<GameObject>();
    // transform  parent dari instance question
    public Transform QuestionHolder;

    void Start () {
        createQuestion();
    }
	// creating random question game object
	public void createQuestion()
    {
        if(Questions.Count > 0)
        {
            int rand = Random.Range(0, Questions.Count);
            GameObject go = Instantiate(Questions[rand], QuestionHolder.transform, false);
            go.name = "Player";
            Questions.RemoveAt(rand);
        }
        else
        {
            Debug.Log("You WIn");
        }  
    }
}
