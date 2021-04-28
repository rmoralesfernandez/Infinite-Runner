using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    [SerializeField]
    private Text health, points;

    [SerializeField]
    private Canvas gameOver = null;


    private void Awake()
    {
        if(gm == null)
        {
            gm = this.GetComponent<GameManager>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOver.enabled = false;
    }

    public void UpdateHealthText(float pHealth)
    {
        health.text = pHealth.ToString();
    }

    public void UpdatePointsText(float pPoints)
    {
        points.text = pPoints.ToString();
    }

    public void GameOver()
    {
        gameOver.enabled = true;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
