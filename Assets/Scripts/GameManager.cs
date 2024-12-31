using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int steps = 0;
    public TextMeshProUGUI crossName;
    public TextMeshProUGUI circleName;
    private MainManager mainManager;
    private int currentUser = 0;
    // Start is called before the first frame update
    void Awake()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        crossName.SetText("X :- "+ mainManager.nameCross);
        circleName.SetText("O :- "+ mainManager.nameCircle);
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
