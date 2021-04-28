using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingItems : MonoBehaviour
{
    [SerializeField]
    private int points = -1, health = -1;

    [SerializeField]
    private float speed = 2f, varSpeed = 0f;

    [SerializeField]
    private GameObject explosion = null;
    // Start is called before the first frame update
    void Start()
    {
        if(varSpeed > 0.0f)
        {
            float originalSpeed = speed;
            float minimal = originalSpeed - varSpeed;
            float max = originalSpeed + varSpeed;

            speed = Random.Range(minimal, max);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(health != 0)
            {
                collision.GetComponent<PlayerController>().UpdateHealth(health);
            }
            if(points != 0)
            {
                collision.GetComponent<PlayerController>().UpdatePoints(points);
            }
            if(explosion != null)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
