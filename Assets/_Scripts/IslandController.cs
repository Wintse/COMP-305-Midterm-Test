using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using UnityEngine.SceneManagement;
/// <summary>
/// Victoria Liu 
/// midterm
/// </summary>

public class IslandController : MonoBehaviour
{
    public float verticalSpeed = 0.05f;


    public Boundary boundary;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    /// <summary>
    /// This method moves the ocean down the screen by verticalSpeed
    /// </summary>
    void Move()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            Vector2 newPosition = new Vector2(0.0f, verticalSpeed);
            Vector2 currentPosition = transform.position;

            currentPosition -= newPosition;
            transform.position = currentPosition;
        }

        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            Vector2 newPosition = new Vector2(verticalSpeed, 0.0f);
            Vector2 currentPosition = transform.position;

            currentPosition -= newPosition;
            transform.position = currentPosition;
        }
            
    }

    /// <summary>
    /// This method resets the ocean to the resetPosition
    /// </summary>
    void Reset()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            float randomXPosition = Random.Range(boundary.Left, boundary.Right);
            transform.position = new Vector2(randomXPosition, boundary.Top);

        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            float randomYPosition = Random.Range(boundary.Top, boundary.Bottom);
            transform.position = new Vector2(boundary.Right, randomYPosition);

        }

    }
           

    /// <summary>
    /// This method checks if the ocean reaches the lower boundary
    /// and then it Resets it
    /// </summary>
    void CheckBounds()
    {

        if (SceneManager.GetActiveScene().name == "Main")
        {
            if (transform.position.y <= boundary.Bottom)
            {
                Reset();
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            if (transform.position.x <= boundary.Left)
            {
                Reset();
            }
        }
    }
}
