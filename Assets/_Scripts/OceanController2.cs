using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
/// <summary>
/// Victoria Liu
/// midterm test
/// 
/// </summary>
public class OceanController2 : MonoBehaviour
{
    public float horizontalSpeed = 0.1f;
    public float resetPosition = 4.8f;
    public float resetPoint = -4.8f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         Move();
        CheckBounds();
    }

    void Move()
    {
        Vector2 newPosition = new Vector2(horizontalSpeed, 0.0f);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }
    void Reset()
    {
        transform.position = new Vector2(resetPosition, 0.0f);
    }

    void CheckBounds()
    {
        if (transform.position.x <= resetPoint)
        {
            Reset();
        }
    }
}
