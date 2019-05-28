using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;

    private bool m_IsPlayerAtExit;
    private bool m_IsPlayerCaught;
    private float m_Timer;

    // Update is called once per frame
    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            print("EndLevel");
            EndLevel(exitBackgroundImageCanvasGroup, false);
        }
        else if(m_IsPlayerCaught)
        {
            print("Caught Player");
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    private void EndLevel(CanvasGroup backgroundImageCanvasGroup, bool doRestart)
    {
        m_Timer += Time.deltaTime;

        backgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
                SceneManager.LoadScene(0);
            else
                Application.Quit();
        }

    }

    public void PlayerCaught()
    {
        m_IsPlayerCaught = true;
    }

}
