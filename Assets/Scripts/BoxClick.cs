using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClick : MonoBehaviour
{
    private GameManager gameManager; // Reference to the GameManager script
    public GameObject cross;         // Cross prefab
    public GameObject circle;        // Circle prefab
    public int i, j;                 // Grid indices for this box

    void Start()
    {
        gameManager = GameObject.Find("GameManager")?.GetComponent<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }
    }

    void OnMouseDown() // Triggered when the object is clicked
    {
        if (gameManager.gameOn)
        {
            if (gameManager == null) return;

            if (gameManager.steps % 2 == 0)
            {
                Instantiate(cross, this.transform.position, transform.rotation);
                gameManager.playingChance.SetText("O Should Play");
                gameManager.completed[i, j] = 1; // Set value to 1 for cross
            }
            else
            {
                Instantiate(circle, this.transform.position, transform.rotation);
                gameManager.playingChance.SetText("X Should Play");
                gameManager.completed[i, j] = 2; // Set value to 2 for circle
            }

            Destroy(gameObject); // Destroy the box after placing cross or circle
            gameManager.steps++;
            gameManager.CheckIfGameCompleted();
            // Optional: Reset game if all steps are completed
            if (gameManager.steps >= 9)
            {
                gameManager.ResetGameScene();
            }
        }
    }
}
