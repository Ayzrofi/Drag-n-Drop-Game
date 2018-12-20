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

    private void Awake()
    {
        if (audioSrc == null)
            audioSrc = GetComponent<AudioSource>();
       
    }
    // Next Scene/level
    public void LoadScene(string name)
    {
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
}
