using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainLoop : MonoBehaviour
{
    void FixedUpdate()
    {
        if (CurrentGameState.getCurrentGameState() == CurrentGameState.States.playing)
        {
            gamePlaying();
        }

        if (CurrentGameState.getCurrentGameState() == CurrentGameState.States.gameOverWin
            || CurrentGameState.getCurrentGameState() == CurrentGameState.States.gameOverLose)
        {
            gameOver();
        }

    }

    private void gamePlaying()
    {
        if (CurrentGameState.getPacmanAlive())
        {
            checkScore();
        }
        else
        {
            playerHasLost();
        }
    }

    private void gameOver()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("enter key pressed, restarting game");
            CurrentGameState.resetGame();
            SceneManager.LoadScene("mainGame");
        }
    }


    public void checkScore()
    {
        if (CurrentGameState.getCurrentScore() >= CurrentGameState.getWinningScore())
        {
            //win the game
            playerHasWon();
        }
    }

    public void playerHasWon()
    {
        //Debug.Log("stateGameOverWin()");
        //win the game
        CurrentGameState.setCurrentGameState(CurrentGameState.States.gameOverWin);
        SceneManager.LoadScene("gameOverWin");
    }


    public void playerHasLost()
    {
        //Debug.Log("stateGameOverLose()");
        //lose the game
        CurrentGameState.setCurrentGameState(CurrentGameState.States.gameOverLose);
        SceneManager.LoadScene("gameOverLose");
    }

}
