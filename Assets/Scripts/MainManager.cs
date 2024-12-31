using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance {get; private set;}
    public string nameCross = "cross";
    public string nameCircle = "circle";

    void Start()
    {

    }
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }
    public void SetNameCross(string s)
    {
        nameCross = s;
        Debug.Log(nameCross);
    }
    public void SetNameCircle(string s)
    {
        nameCircle = s;
        Debug.Log(nameCircle);
    }

    public void StartGame()
    {
        if(nameCross == "cross")
        {
            Debug.Log("Please Enter Cross Name");
            return;
        }
    
        if(nameCircle == "circle")
        {
            Debug.Log("Please Enter Cicle Name");
            return;
        }
        SceneManager.LoadScene(1);
    }
}