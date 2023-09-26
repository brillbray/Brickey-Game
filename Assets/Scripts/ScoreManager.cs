using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;


public class ScoreManager : MonoBehaviour
{
    public int p1Score = 0;
    public int p2Score = 0;

    public Text p1ScoreText;
    public Text p2ScoreText;

    public int targetScore;

    public void p1Goal()
    {
        p1Score++;
        p1ScoreText.text = p1Score.ToString();
        checkScore();
    }

    public void p2Goal()
    {
        p2Score++;
        p2ScoreText.text = p2Score.ToString();
        checkScore();
    }

    public void checkScore()
    {
        if (p1Score == targetScore || p2Score == targetScore)
        {
            SceneManager.LoadScene(2);
        }
    }
}
