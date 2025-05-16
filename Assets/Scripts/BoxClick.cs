using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClick : MonoBehaviour
{
    private GameManager gameManager; // Reference to the GameManager script
    public GameObject crossPrefab;   // Cross prefab
    public GameObject circlePrefab;  // Circle prefab
    public int i, j;                 // Grid indices for this box


    private bool isClicked = false;  // Tracks if the box has already been clicked

    void Start()
    {
        gameManager = GameObject.Find("GameManager")?.GetComponent<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }
    }

    


    public void HandleInteraction()
    {
        if (isClicked || gameManager == null || !gameManager.gameOn) return;

        // Determine whether to place a cross or circle
        if (gameManager.steps % 2 == 0)
        {
            Instantiate(crossPrefab, new Vector3(transform.position.x,transform.position.y,transform.position.z-1), Quaternion.identity);
            gameManager.playingChance.SetText("O Should Play");
            gameManager.completed[i, j] = 1; // Mark grid as occupied by X
        }
        else
        {
            Instantiate(circlePrefab, new Vector3(transform.position.x,transform.position.y,transform.position.z-1), Quaternion.identity);
            gameManager.playingChance.SetText("X Should Play");
            gameManager.completed[i, j] = 2; // Mark grid as occupied by O
        }

        isClicked = true; // Mark the box as clicked to make it non-interactable
        gameManager.steps++;
        gameManager.CheckIfGameCompleted();

        if (gameManager.steps >= 9)
        {
            gameManager.ResetGameScene();
        }
    }


}
