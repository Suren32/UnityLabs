using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverTxt;

    public GameObject portal;
    private int _score = 0;


    public GameObject ball;

    private void Start()
    {
        this.scoreText.text = "Score: 0";
        DontDestroyOnLoad(this.gameObject);
    }
    public void Add(int points)
    {
        if (_score >= 50 && SceneManager.GetActiveScene().name == "FirstScene")
        {
            return;
        }

        _score += points;
        scoreText.text = $"Score: {_score}";
        this.scoreText.text = "Score: " + _score;


        if (_score >= 50 && SceneManager.GetActiveScene().name == "FirstScene")
            this.portal.SetActive(true);


        if (_score >= 100)
        {
            Time.timeScale = 0;
            gameOverTxt.gameObject.SetActive(true);
        }
    }

    

    float t = 0;
    private void Update()
    {
        t += Time.deltaTime;

        if (t > 3) {
            t = 0;

            if (GameObject.FindGameObjectsWithTag("Balls").Length >= 8)
                return;

            Instantiate(ball, new Vector3(Random.Range(-4.5f, 4.5f), 0.5f, Random.Range(-4.5f, 4.5f)), ball.transform.rotation);
            Instantiate(ball, new Vector3(Random.Range(-4.5f, 4.5f), 0.5f, Random.Range(-4.5f, 4.5f)), ball.transform.rotation);

        }
    }
}
