using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
/// <summary>
/// Victoria Liu
/// midterm test
/// moves the oceans of level 2
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

    void Move() //moves the ocean
    {
        Vector2 newPosition = new Vector2(horizontalSpeed, 0.0f);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }
    void Reset()
    {
        //resets the ocean
        transform.position = new Vector2(resetPosition, 0.0f);
    }

    void CheckBounds()
    {
        //checks if the ocean is at the reset point
        if (transform.position.x <= resetPoint)
        {
            Reset();
        }
    }
}
