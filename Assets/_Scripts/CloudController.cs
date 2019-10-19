using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using UnityEngine.SceneManagement;
/// <summary>
/// Victoria Liu 
/// midterm
/// controls movement of clouds
/// now check which scene the game is in so it determine which way the clouds should come from
/// </summary>

public class CloudController : MonoBehaviour
{
    [Header("Speed Values")]
    [SerializeField]
    public Speed horizontalSpeedRange;

    [SerializeField]
    public Speed verticalSpeedRange;

    public float verticalSpeed;
    public float horizontalSpeed;

    [SerializeField]
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
        
            Vector2 newPosition = new Vector2(horizontalSpeed, verticalSpeed);
            Vector2 currentPosition = transform.position;

            currentPosition -= newPosition;
            transform.position = currentPosition;
        
    }

    /// <summary>
    /// This method resets the ocean to the resetPosition
    /// the reset position will be different depending on which scene
    /// will check which scene the game is currently on and will then decide what to do
    /// </summary>
    void Reset()
    {
        //level1/main the same as before
        if (SceneManager.GetActiveScene().name == "Main")
        {
            horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);
            verticalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);

            float randomXPosition = Random.Range(boundary.Left, boundary.Right);
            transform.position = new Vector2(randomXPosition, Random.Range(boundary.Top, boundary.Top + 2.0f));
        }
        //level2 
        else if (SceneManager.GetActiveScene().name == "Level2") 
        {
            //will swap the horizontal and vertical speeds so they have each other's values or else the vertical will be too fast
            //horizontalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);
            //verticalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);

            horizontalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);
            verticalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);

            float randomYPosition = Random.Range(boundary.Top, boundary.Bottom);
            transform.position = new Vector2(Random.Range(boundary.Right, boundary.Right + 2.0f), randomYPosition);
        }

            
    }

    /// <summary>
    /// This method checks if the ocean reaches the lower boundary
    /// and then it Resets it
    /// depending on the level it will reset to the top or right
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
