using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour

{
    private int currentLevel;
    

    
    public void PlayGame()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //public void retry()
    //{
        
    //    FindObjectOfType<GameManager>().retry();
    //}
    //private void getlevel(int x)
    //{
    //    currentLevel = x;
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}
