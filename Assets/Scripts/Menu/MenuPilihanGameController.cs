using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuPilihanGameController : MonoBehaviour {

    public GameObject LockEducation, LockObject;
    public Button ButtonEducation, ButtonObject;

    // setingan untuk unlock sistem pada pemilihan jenis game
    private void Start()
    {
        if (PlayerPrefs.GetInt("1Level_9") == 3)
        {
            ButtonEducation.interactable = true;
            LockEducation.SetActive(false);
        }
        else
        {
            ButtonEducation.interactable = false;
            LockEducation.SetActive(true);
        }

        if (PlayerPrefs.GetInt("2Level_9") == 3)
        {
            ButtonObject.interactable = true;
            LockObject.SetActive(false);
        }
        else
        {
            ButtonObject.interactable = false;
            LockObject.SetActive(true);
        }
    }
}
