using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinousBCK : MonoBehaviour
{
    [SerializeField]
    private float speed = 0, end = 0, begin = 0, inverse = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector2.left * speed * Time.deltaTime) * inverse);
        if(transform.position.x <= end)
        {
            Vector2 startPosition = new Vector2(begin, transform.position.y);
            transform.position = startPosition;
        }
    }
}
