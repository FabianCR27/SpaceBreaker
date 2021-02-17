using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;//declaration of my singleton 

    [SerializeField] private int lives = 3;
    [SerializeField] private Text TextLives = null;
    [SerializeField] private string preTextScore2 = "Lives: ";
    private MoveBall Ball; //reference to the ball script

    [SerializeField] private Text Scoretxt = null;
    [SerializeField] private string preTextScore="Score: ";
    private int score = 0;

    private int blocks = 0;
    [SerializeField] private GameObject[] levels = null;//array of levels
    private int currentLevel = 0;
   // private int currentLevelGameOver =0;
    private GameObject currentBoard;

    private int bestScore = 0;





    void LoadLevel()
    {
        if (currentBoard)
        {
            Destroy(currentBoard);
        }
        blocks = 0;
        currentBoard = Instantiate(levels[currentLevel]); 
    }
    //public void retry()
    //{  lives= 3;
    //    score = 0;
    //    currentBoard = Instantiate(levels[currentLevelGameOver]);
    //}

    private void Awake()
    {
        //make sure only one instance will exist 

        if (instance == null)//thos omtamce
        {
            instance = this;// if there is another one
        }
        else if (instance != this)
        {
            Destroy(gameObject); //if there is object to destry 
        }
    }
    // Start is called before the first frame update
    void Start()
    {   //find the object ball and get the component moveBall
        Ball = GameObject.Find("Ball").GetComponent<MoveBall>();
        TextLives.text = preTextScore2 + lives;
        Scoretxt.text = preTextScore + score.ToString("D8");
  

        LoadLevel();//initialize first level

        bestScore = PlayerPrefs.GetInt("Score", 0);//read the old high score 

    }

    void init() //inicialize the game
    {
        TextLives.text = preTextScore2 + lives;
        Ball.init(); //Inicialize the ball
           TextLives.text = preTextScore2 + lives;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Cancel"))
        {
            Application.Quit();
        }
    }

    public void UpdateLives(int changeInLives)
    {
        if (lives > 0)
        {
            lives += changeInLives ;
            TextLives.text = preTextScore2 + lives;
        }
    }
    public void Death()
    {
          
        lives--;
     

        if (lives > 0)//we still have lives
        {
        
            init();
        }
        else //game over
        {
            //currentLevelGameOver = currentLevel;
            Ball.gameObject.SetActive(false);//disable the ball
            Scoretxt.text = "GAME OVER \n" + preTextScore + score.ToString("08"); //game over + score 
            if (score>bestScore)
            {
                //beat this old high score
                PlayerPrefs.SetInt("Score", score);
                PlayerPrefs.Save();
            }
            // System.Threading.Thread.Sleep(2000);
            
            SceneManager.LoadScene("GameOverMenu");
          
        }
    }
    public void AddPoints()
    {

        
        score += 10;
        string prePreText = "";
        if (score > bestScore)
        {
            prePreText = "BEST  ";
        }
        Scoretxt.text = prePreText + preTextScore + score.ToString("D8");
        blocks--;//remove block
        if (blocks <= 0)
        {
            if (currentLevel < levels.Length - 1) //if we are not at the last level
            {
                currentLevel++;
            }
            else
            {
                Debug.Log("Replay last level");
            }
            init();//call ball back to the paddle
            LoadLevel();
        }
    }

 

        public void AddBlock()
        {
            blocks++;
        }
    //public void removeLives()
    //{
    //    TextLives.text = preTextScore2 + lives;
    //}

   
    }

