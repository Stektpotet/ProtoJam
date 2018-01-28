using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
   public Text scorePlayer1Text;
   public Text scorePlayer2Text;
   private int scorePlayer1;
   private int scorePlayer2;

   // Use this for initialization
   void Start()
   {
      scorePlayer1Text.text = "0";
      scorePlayer2Text.text = "0";
   }

   // Update is called once per frame
   void Update()
   {
      scorePlayer1 = 50;//TODO get player score
      scorePlayer2 = 50;//TODO get player score

      if (scorePlayer1 < 300)
      {
         scorePlayer1Text.text = "Player 1: " + scorePlayer1.ToString();
      }
      if (scorePlayer1 > 300)
      {
         scorePlayer1Text.text = "PLAYER 1 WIN (" + scorePlayer1.ToString() + ")";
         //TODO - end game
      }

      if (scorePlayer2 < 300)
      {
         scorePlayer2Text.text = "player 2: " + scorePlayer2.ToString();
      }
      if (scorePlayer2 > 300)
      {
         scorePlayer2Text.text = "PLAYER 2 WIN!!! (" + scorePlayer2.ToString() + ")";
         //TODO - end game
      }
   }
}
