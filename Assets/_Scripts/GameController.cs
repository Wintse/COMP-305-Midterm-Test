using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Victoria Liu
/// midterm test
/// manages UI and scenes
/// scoreboard was added and the ability to switch to level2
/// </summary>
public class GameController : MonoBehaviour
{
    [Header("Scene Game Objects")]
    public GameObject cloud;
    public GameObject island;
    public int numberOfClouds;
    public List<GameObject> clouds;

    [Header("Audio Sources")]
    public SoundClip activeSoundClip;
    public AudioSource[] audioSources;

    [Header("Scoreboard")]
    [SerializeField]
    private int _lives;

    [SerializeField]
    private int _score;

    public Text livesLabel;
    public Text scoreLabel;
    public Text highScoreLabel;

    //game objects
    //now is scoreboard
    public GameObject scoreBoard;

    [Header("UI Control")]
    public GameObject startLabel;
    public GameObject startButton;
    public GameObject endLabel;
    public GameObject restartButton;

    // public properties
    public int Lives
    {
        get
        {
            return _lives;
        }

        set
        {
            _lives = value;

            //updates the lives in ScoreBoard equal to _lives
            scoreBoard.GetComponent<ScoreBoard>().lives = _lives;

            if (_lives < 1)
            {
                
                SceneManager.LoadScene("End");
                //resets the lives and score
                scoreBoard.GetComponent<ScoreBoard>().lives = 5;
                scoreBoard.GetComponent<ScoreBoard>().score = 0;
            }
            else
            {
                livesLabel.text = "Lives: " + _lives.ToString();
            }
           
        }
    }

    public int Score
    {
        get
        {
            return _score;
        }

        set
        {
            _score = value;

            //updates the score in ScoreBoard equal to _score
            scoreBoard.GetComponent<ScoreBoard>().score = _score;

            if (scoreBoard.GetComponent<ScoreBoard>().highscore < _score)
            {
                scoreBoard.GetComponent<ScoreBoard>().highscore = _score;
            }
            //checks if the score is 500 and if on the main scene to see when to change scenes
            if(SceneManager.GetActiveScene().name == "Main")
            {
                if (_score == 500)//if score is 500 it will change scenes
                {
                    SceneManager.LoadScene("Level2");
                    Debug.Log("Help");
                }
            }
           
            scoreLabel.text = "Score: " + _score.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        GameObjectInitialization();
        SceneConfiguration();
        
    }

    private void GameObjectInitialization()
    {
        //scoreboard is being found
        scoreBoard = GameObject.Find("ScoreBoard");
        startLabel = GameObject.Find("StartLabel");
        endLabel = GameObject.Find("EndLabel");
        startButton = GameObject.Find("StartButton");
        restartButton = GameObject.Find("RestartButton");
    }


    private void SceneConfiguration()
    {

        switch (SceneManager.GetActiveScene().name)
        {
            case "Start":
                scoreLabel.enabled = false;
                livesLabel.enabled = false;
                highScoreLabel.enabled = false;
                endLabel.SetActive(false);
                restartButton.SetActive(false);
                activeSoundClip = SoundClip.NONE;
                break;
            case "Main":
                highScoreLabel.enabled = false;
                startLabel.SetActive(false);
                startButton.SetActive(false);
                endLabel.SetActive(false);
                restartButton.SetActive(false);
                activeSoundClip = SoundClip.ENGINE;
                break;
            //level2, is the same as main 
            case "Level2":
                highScoreLabel.enabled = false;
                startLabel.SetActive(false);
                startButton.SetActive(false);
                endLabel.SetActive(false);
                restartButton.SetActive(false);
                activeSoundClip = SoundClip.ENGINE;
                break;
            case "End":
                scoreLabel.enabled = false;
                livesLabel.enabled = false;
                startLabel.SetActive(false);
                startButton.SetActive(false);
                activeSoundClip = SoundClip.NONE;
                highScoreLabel.text = "High Score: " + scoreBoard.GetComponent<ScoreBoard>().highscore;
                break;
        }

        //Lives = 5;
        // Score = 0;
        ///instead the Lives and Score are equal to the ScoreBoard so it keeps the score
        Lives = scoreBoard.GetComponent<ScoreBoard>().lives;
        Score = scoreBoard.GetComponent<ScoreBoard>().score;

        if ((activeSoundClip != SoundClip.NONE) && (activeSoundClip != SoundClip.NUM_OF_CLIPS))
        {
            AudioSource activeAudioSource = audioSources[(int)activeSoundClip];
            activeAudioSource.playOnAwake = true;
            activeAudioSource.loop = true;
            activeAudioSource.volume = 0.5f;
            activeAudioSource.Play();
        }



        // creates an empty container (list) of type GameObject
        clouds = new List<GameObject>();

        for (int cloudNum = 0; cloudNum < numberOfClouds; cloudNum++)
        {
            clouds.Add(Instantiate(cloud));
        }

        Instantiate(island);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Event Handlers
    public void OnStartButtonClick()
    {
        DontDestroyOnLoad(scoreBoard);
        SceneManager.LoadScene("Main");
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("Main");
    }
}
