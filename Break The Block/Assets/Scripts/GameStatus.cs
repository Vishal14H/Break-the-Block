using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f , 10f)] [SerializeField] float gameSpeed=1f;
    [SerializeField] int pointPerBlock = 80;

    [SerializeField] int currentScore =0;
   

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointPerBlock;
    }
}
