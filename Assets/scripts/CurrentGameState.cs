using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CurrentGameState : MonoBehaviour
{
    private static bool pacmanAlive = true;
    public enum States { playing, gameOverWin, gameOverLose };
    private static States currentGameState = States.playing;
    private static int currentScore = 0;
    private static int scoreNeededToWin = 328;

    public static void resetGame()
    {
        currentGameState = States.playing;
        pacmanAlive = true;
        currentScore = 0;
    }

    public static void increaseScore()
    {
        currentScore++;
    }

    public static int getCurrentScore()
    {
        return currentScore;
    }

    public static int getWinningScore()
    {
        return scoreNeededToWin;
    }

    public static bool getPacmanAlive()
    {
        return pacmanAlive;
    }

    public static void setPacmanAlive(bool input)
    {
        pacmanAlive = input;
    }

    public static States getCurrentGameState()
    {
        return currentGameState;
    }

    public static void setCurrentGameState(States input)
    {
        currentGameState = input;
    }

}

