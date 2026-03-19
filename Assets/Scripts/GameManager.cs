using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Vraiables
    private int score; //Score

    //Player Ref
    public Player player;

    //UI Ref
    public Text scoreText;
    public GameObject palyButton;
    public GameObject gameOver;
    public Text youWinText;
    public GameObject getReady;

    //Methods
    public void Awake()
    {
        Application.targetFrameRate = 60; //game frameRate

        getReady.SetActive(true); //show get ready at start
        gameOver.SetActive(false);   // hide at start
        palyButton.SetActive(true);  // show play button
        youWinText.gameObject.SetActive(false); //hide at start

        //Pausing the game when it starts so the palyer can click the play button
        Pause();
    }

    public void Play()
    {
        score = 0; //reseting the score
        scoreText.text = score.ToString();

        //Hiding the UI 
        getReady.SetActive(false); //hide get ready
        gameOver.SetActive(false); //game over img
        palyButton.SetActive(false); //play button
        youWinText.gameObject.SetActive(false); //you win text

        Time.timeScale = 1f; //reset time scale
        player.enabled = true; //Re-enable the player

        //destoring all previous pipes in an array
        Pipes[] pipes = FindObjectsByType<Pipes>(FindObjectsSortMode.None);

        //loop through the array and destroy all of the pipes
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f; //to freeze the game --> time not updating --> the Update methods will not work
        player.enabled = false; //disable the player
    }

    public void GameOver()
    {
        Debug.Log("Game Over"); //for debug purposes   

        //disaplying the UI elements 
        gameOver.SetActive(true); //game over img
        palyButton.SetActive(true); //play button
        
        Pause(); //calling pause to stop the game
    }

    public void IncreaseScore() //to increase the score by one
    {
        score++;
        scoreText.text = score.ToString(); //converting int to string and displaying it in the score text
        Debug.Log("Score: " + score); //for debug purposes  

        //if score reach 10 --> player win
        if(score >= 10)
        {
            WinGame();
        }

    }
    
    private void WinGame()
    {
        Debug.Log("YOU WIN!");

        youWinText.text = "YOU WIN!";
        youWinText.gameObject.SetActive(true);

        palyButton.SetActive(true); //play button

        Pause();
    }
}
