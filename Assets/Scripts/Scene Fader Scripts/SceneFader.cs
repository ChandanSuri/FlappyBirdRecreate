﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

    public static SceneFader instance;
    [SerializeField]
    private GameObject fadeCanvas;
    [SerializeField]
    private Animator fadeAnim;

	void Awake () {
        MakeSingleton();
    }
	
	void MakeSingleton () {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
	}

    public void FadeIn(string levelName)
    {
        StartCoroutine(FadeInAnimation(levelName));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutAnimation());
    }
    IEnumerator FadeInAnimation(string levelName)
    {
        fadeCanvas.SetActive(true);
        fadeAnim.Play("FadeIn");
        //yield return new WaitForSeconds(0.7f);
        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(0.7f));
        SceneManager.LoadScene(levelName);
        FadeOut();
    }

    IEnumerator FadeOutAnimation()
    {
        fadeAnim.Play("FadeOut");
        //yield return new WaitForSeconds(1f);
        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(1f));
        fadeCanvas.SetActive(false);
    }
}
