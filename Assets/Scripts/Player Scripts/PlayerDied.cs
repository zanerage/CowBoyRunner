﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDied : MonoBehaviour
{
    public delegate void EndGame();
    public static event EndGame endgame;

    void PlayerDiedEndGame()
    {
        if (endgame != null)
            endgame();

        Destroy(gameObject);
    }

     void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag=="Collector")
        {
            PlayerDiedEndGame();
        }
    }


    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Zombie")
        {
            PlayerDiedEndGame();
        }
    }
  

  
}
