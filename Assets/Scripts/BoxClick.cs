using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClick : MonoBehaviour
{
    private GameManager gameManager; // Reference to the GameManager script
    public GameObject cross;         // Cross prefab
    public GameObject circle;        // Circle prefab

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
        if (gameManager == null) return;

        if (gameManager.steps % 2 == 0)
        {
            Instantiate(cross, this.transform.position, transform.rotation);
        }
        else
        {
            Instantiate(circle, this.transform.position, transform.rotation);
        }

        Destroy(gameObject); // Destroy the box after placing cross or circle
        gameManager.steps++;
        if(gameManager.steps >= 9)
        {
            gameManager.ResetGame();
        }
    }
}
