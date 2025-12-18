using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static Action<bool> GameOver;
    public static Action<int> AddScores;
    public static Action CheckIfShapeCanBePlaced;
    public static Action MoveShapeToStartPosition;
    public static Action RequestNewShapes;
    public static Action CheckIfPlayerLost;
    public static Action SetShapeInactive;
    public static Action<int, int> UpdateBestScoreBar;
    public static Action<Config.SquareColor> UpdateSquareColor;
    public static Action ShowCongratulations;
    public static Action<Config.SquareColor> ShowBonusScreen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
