using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private Text timer;

    private Vector2 playerPos;
    private int maxPos = 0;

    [SerializeField]
    private float healthUpdate = 0, ihealth = 100, ipoints = 0;

    [SerializeField]
    private Vector2[] positionsAvailable;

    [SerializeField]
    private int actualPos = 1;

    [SerializeField]
    private GameObject particleMove = null;
    
    private bool isAlive;

    private float crono;
    private string time;

    // Start is called before the first frame update

    private void Awake()
    {
        maxPos = positionsAvailable.Length - 1;
    }
    void Start()
    {
        if(healthUpdate != 0)
        {
            InvokeRepeating("UpdateHealthReap", 1, 1);
        }

        isAlive = true;
        GameManager.gm.UpdateHealthText(ihealth);
    }

    // Update is called once per frame
    void Update()
    {
        crono = Time.time;
        timer.text = crono.ToString("f1");

        if (ihealth <= 0)
        {
            GameManager.gm.GameOver();
            isAlive = false;
            Destroy(gameObject);
        } else
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
            if(Input.GetKeyDown(KeyCode.UpArrow) && (actualPos < maxPos))
            {
                if(particleMove != null)
                {
                    Instantiate(particleMove, transform.position, Quaternion.identity);
                }
                actualPos += 1;
                playerPos = positionsAvailable[actualPos];
            } else if (Input.GetKeyDown(KeyCode.DownArrow) && (actualPos > 0))
            {
                if (particleMove != null)
                {
                    Instantiate(particleMove, transform.position, Quaternion.identity);
                }
                actualPos -= 1;
                playerPos = positionsAvailable[actualPos];
            }
        }
    }

    public void UpdateHealth (float pHealth2Update)
    {
        if (isAlive)
        {
            ihealth = ihealth + pHealth2Update;
            if(ihealth >= 100)
            {
                ihealth = 100;
            }
            GameManager.gm.UpdateHealthText(ihealth);
        }
    }

    /*
    private void UpdateHealthRep ()
    {
        if (isAlive)
        {
            UpdateHealth(healthUpdate);
        }
    }*/

    public void UpdatePoints(float points2Update)
    {
        if(isAlive)
        {
            ipoints = ipoints + points2Update;
            GameManager.gm.UpdatePointsText(ipoints);
        }
    }
}
