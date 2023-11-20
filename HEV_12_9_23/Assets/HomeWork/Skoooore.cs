using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skoooore : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text scoreText;
    [SerializeField] GameObject deathscreen;
    private int currentScore = 0;
    public static Skoooore score;

    private void Start()
    {
        Time.timeScale = 1.0f;
        if (score == null)
            score = this;
    }

    public void Die()
    {
        deathscreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Collect()
    {
        scoreText.text = "Score: ";
        currentScore++;
        scoreText.text += currentScore.ToString();
        return;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
