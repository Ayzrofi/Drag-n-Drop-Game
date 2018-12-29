using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]
public class SceneController : MonoBehaviour {
    [SerializeField]
    private Animator TransitionAnim;
    [SerializeField]
    private AudioSource audioSrc;
    // for ads
    public static int AdsCount = 2;

    private void Awake()
    {
        if (audioSrc == null)
            audioSrc = GetComponent<AudioSource>();

        if(AdsManajer.Instance != null)
        {
            AdsManajer.Instance.ShowBanner();
            AdsManajer.Instance.LoadIntertisial();
        }
    }
    // Next Scene/level
    public void LoadScene(string name)
    {
        AdsCount--;
        if (AdsCount <= 0)
        {
            if (AdsManajer.Instance != null)
                AdsManajer.Instance.ShowIntertisial();

            AdsCount = 2;
        }
        Debug.Log(AdsCount);
        StartCoroutine(StartLoadScene(name));
    }

    IEnumerator StartLoadScene(string SceneName)
    {
        if(TransitionAnim != null)
        {
            TransitionAnim.SetTrigger("End");
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneName);
    }
    // Restart/Play Again
    public void Restart()
    {
        AdsCount--;
        if (AdsCount <= 0)
        {
            if (AdsManajer.Instance != null)
                AdsManajer.Instance.ShowIntertisial();

            AdsCount = 2;
        }
        Debug.Log(AdsCount);
        StartCoroutine(StartRestart());
    }
    IEnumerator StartRestart()
    {
        if (TransitionAnim != null)
        {
            TransitionAnim.SetTrigger("End");
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(Application.loadedLevel);
    }
    // Exit Game
    public void ExitGame()
    {
        StartCoroutine(StartExitGame());
        Debug.Log("ExitGame");
    }
    IEnumerator StartExitGame()
    {
        if (TransitionAnim != null)
        {
            TransitionAnim.SetTrigger("End");
        }
        yield return new WaitForSeconds(1);
        Application.Quit();
    }

    public void PlaySfx(AudioClip clip)
    {
        audioSrc.PlayOneShot(clip);
    }

    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }
}
