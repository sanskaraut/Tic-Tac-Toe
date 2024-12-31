using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int steps = 0; // Tracks the number of steps taken
    public TextMeshProUGUI crossName; // UI for cross player name
    public TextMeshProUGUI circleName; // UI for circle player name
    public TextMeshProUGUI playingChance; // UI for displaying which player's turn
    public TextMeshProUGUI resultText;
    public GameObject resetScreen; // UI screen for resetting the game
    public GameObject camera;
    private MainManager mainManager; // Reference to MainManager
    public bool gameOn; // Flag to check if the game is ongoing
    public int winner;

    // Represents the game grid (3x3) to track completed moves
    public int[,] completed = new int[3, 3];

    void Awake()
    {
        gameOn = true;
        resetScreen.gameObject.SetActive(false);
        // Find MainManager and initialize player names
        mainManager = GameObject.Find("MainManager")?.GetComponent<MainManager>();
        if (mainManager != null)
        {
            crossName.SetText("X :- " + mainManager.nameCross);
            circleName.SetText("O :- " + mainManager.nameCircle);
        }
        else
        {
            Debug.LogError("MainManager not found!");
        }

        // Initialize the completed array with 0
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                completed[i, j] = 0;
            }
        }
    }


    // Reloads the current scene
    public void ResetGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Activates the reset screen and stops the game
    public void ResetGame()
    {
        gameOn = false;
        if (resetScreen != null)
        {
            resetScreen.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Reset screen not assigned!");
        }
    }
    public void CheckIfGameCompleted()
    {
        // Check rows and columns
        for (int i = 0; i < 3; i++)
        {
            // Check row i
            if (completed[i, 0] != 0 && completed[i, 0] == completed[i, 1] && completed[i, 1] == completed[i, 2])
            {
                winner = completed[i, 0];
                gameOn = false;
                DisplayWinner();
                return;
            }

            // Check column i
            if (completed[0, i] != 0 && completed[0, i] == completed[1, i] && completed[1, i] == completed[2, i])
            {
                winner = completed[0, i];
                gameOn = false;
                DisplayWinner();
                return;
            }
        }

        // Check diagonals
        if (completed[0, 0] != 0 && completed[0, 0] == completed[1, 1] && completed[1, 1] == completed[2, 2])
        {
            winner = completed[0, 0];
            gameOn = false;
            DisplayWinner();
            return;
        }

        if (completed[0, 2] != 0 && completed[0, 2] == completed[1, 1] && completed[1, 1] == completed[2, 0])
        {
            winner = completed[0, 2];
            gameOn = false;
            DisplayWinner();
            return;
        }

        // Check if the board is full (tie)
        if (steps >= 9)
        {
            winner = 0; // No winner, game is a tie
            gameOn = false;
            DisplayWinner();
        }
    }

    // Displays the winner on the reset screen or any relevant UI
    private void DisplayWinner()
    {
        if (resetScreen != null)
        {
            resetScreen.SetActive(true);
            if (resultText != null)
            {
                camera.transform.position = new Vector3(camera.transform.position.x + 100,camera.transform.position.y,camera.transform.position.z);
                playingChance.gameObject.SetActive(false);
                if (winner == 1)
                    resultText.SetText("Cross (X) Wins!");
                else if (winner == 2)
                    resultText.SetText("Circle (O) Wins!");
                else
                    resultText.SetText("It's a Tie!");
            }
        }
        else
        {
            Debug.LogError("Reset screen not assigned!");
        }
    }

}
