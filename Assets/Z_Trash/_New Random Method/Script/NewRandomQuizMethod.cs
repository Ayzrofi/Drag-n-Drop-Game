using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewRandomQuizMethod : MonoBehaviour {
    [Header("size Harus lebih dari jumlah pilihan jawaban atau akan error")]
    public List<string> Pertanyaan = new List<string>();
    [Header("size Harus lebih dari jumlah pilihan jawaban atau akan error")]
    public List<string> Jawaban = new List<string>();

    public Text PertanyaanTxt;
    [Header("Pilihan Jawaban ")]
    public Text Jawaban1Txt;
    public Text Jawaban2Txt;
    public Text Jawaban3Txt;

    public int rand, rand_1, rand_2, rand_3;

    private void Start()
    {
        CreateLevel();
    }

    public void CreateLevel()
    {
        rand = Random.Range(0, Pertanyaan.Count);
        //Debug.Log(rand);

        PertanyaanTxt.text = Pertanyaan[rand];

        int RandJawabanPos = Random.Range(1, 4);
        //Debug.Log("Jawaban Benar Di Nomer" + RandJawabanPos);
        //// button 1
        if (RandJawabanPos == 1)
        {
            Jawaban1Txt.text = Jawaban[rand];
            Jawaban1Txt.gameObject.GetComponentInParent<Button>().onClick.RemoveAllListeners();
            Jawaban1Txt.gameObject.GetComponentInParent<Button>().onClick.AddListener(() => WinGame());
        }
        else
        {
            Jawaban1Txt.gameObject.GetComponentInParent<Button>().onClick.RemoveAllListeners();
            rand_1 = Random.Range(0, Jawaban.Count);

            //if (rand_1 == rand || rand_1 == rand_2 || rand_1 == rand_3)
            //{
            //    Debug.Log("asuuu");
            //    rand_1 = Random.Range(0, Jawaban.Count);
            //    Jawaban1Txt.text = Jawaban[rand_1];
            //}
            //else
            //{
            //    Jawaban1Txt.text = Jawaban[rand_1];
            //}
            while (rand_1 == rand || rand_1 == rand_2 || rand_1 == rand_3)
            {
                rand_1 = Random.Range(0, Jawaban.Count);
            }
            Jawaban1Txt.text = Jawaban[rand_1];
            Jawaban1Txt.gameObject.GetComponentInParent<Button>().onClick.AddListener(() => LoseGame());
            //Debug.Log(rand_1);
        }
        //// button 2
        if (RandJawabanPos == 2)
        {
            Jawaban2Txt.text = Jawaban[rand];
            Jawaban2Txt.gameObject.GetComponentInParent<Button>().onClick.RemoveAllListeners();
            Jawaban2Txt.gameObject.GetComponentInParent<Button>().onClick.AddListener(() => WinGame());
        }
        else
        {
            Jawaban2Txt.gameObject.GetComponentInParent<Button>().onClick.RemoveAllListeners();
            rand_2 = Random.Range(0, Jawaban.Count);
            //if (rand_2 == rand || rand_2 == rand_1 || rand_2 == rand_3)
            //{
            //    Debug.Log("asuuu");
            //    rand_2 = Random.Range(0, Jawaban.Count);
            //    Jawaban2Txt.text = Jawaban[rand_2];
            //}
            //else
            //{
            //    Jawaban2Txt.text = Jawaban[rand_2];
            //}
            while(rand_2 == rand || rand_2 == rand_1 || rand_2 == rand_3)
            {
                rand_2 = Random.Range(0, Jawaban.Count);
            }
            Jawaban2Txt.text = Jawaban[rand_2];
            Jawaban2Txt.gameObject.GetComponentInParent<Button>().onClick.AddListener(() => LoseGame());
            //Debug.Log(rand_2);
        }
        //// Button 3
        if (RandJawabanPos == 3)
        {
            Jawaban3Txt.text = Jawaban[rand];
            Jawaban3Txt.gameObject.GetComponentInParent<Button>().onClick.RemoveAllListeners();
            Jawaban3Txt.gameObject.GetComponentInParent<Button>().onClick.AddListener(() => WinGame());
        }
        else
        {
            Jawaban3Txt.gameObject.GetComponentInParent<Button>().onClick.RemoveAllListeners();
            rand_3 = Random.Range(0, Jawaban.Count);
            //if (rand_3 == rand || rand_3 == rand_2 || rand_3 == rand_1)
            //{
            //    Debug.Log("asuuu");
            //    rand_3 = Random.Range(0, Jawaban.Count);
            //    Jawaban3Txt.text = Jawaban[rand_3];
            //}
            //else
            //{
            //    Jawaban3Txt.text = Jawaban[rand_3];
            //}
            while(rand_3 == rand || rand_3 == rand_2 || rand_3 == rand_1)
            {
                rand_3 = Random.Range(0, Jawaban.Count);
            }
            Jawaban3Txt.text = Jawaban[rand_3];
            Jawaban3Txt.gameObject.GetComponentInParent<Button>().onClick.AddListener(() => LoseGame());
            //Debug.Log(rand_3);
        }


    }

    public void WinGame()
    {
        Debug.Log("Ikeeeh");
        CreateLevel();
    }

    public void LoseGame()
    {
        Debug.Log("Yameroooooo");
    }
}










