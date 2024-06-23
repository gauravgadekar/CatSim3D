using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class GameManager : MonoBehaviour
{
   public int level = 1;
   public bool gameStarted = false;
   public bool gameEnded = false;
   
   public GameObject[] rooms;
   public GameObject[] tutos;
   public GameObject screenEnd;
   public TextMeshProUGUI textTimer;
   public TextMeshProUGUI textScore;
   public TextMeshProUGUI textScoreFinal;
   public TextMeshProUGUI bestScore;
   public AiPlayer[] aiPlayers;
   public TextMeshProUGUI[] finalScoresText;
   public string[] finalScores;
   public TextMeshProUGUI playerLevelText;
   public GameObject[] stoppers;
   

   public int timerVal = 30;

   private void Awake()
   {

      level = PlayerPrefs.GetInt("level", 1);
      playerLevelText.text ="Level: " + level;
      
      for (int i = 1; i <= rooms.Length; i++)
      {
         if (i<=level)
         {
            rooms[i-1].SetActive(true);
            if (level<=1)
            {
               stoppers[i-1].SetActive(false);
            }
            
         }
      }

      bestScore.text = "Best: "+ PlayerPrefs.GetInt("scoreMax", 0);
   }



   public void StartGame()
   {
         gameStarted = true;
         tutos[0].SetActive(false);
         InvokeRepeating("SetTimer",1,1);

         foreach (AiPlayer ai in aiPlayers)
         {
            ai.StartGame();
         }
   }
   public void SetTimer()
   {
      timerVal--;
      textTimer.text = timerVal.ToString();

      if (timerVal==0)
      {
         gameEnded = true;
         CancelInvoke();
         screenEnd.SetActive(true);
         textScoreFinal.text = "Score: " + textScore.text;

         finalScores[0] = "Player 1: " + int.Parse(textScore.text);
         finalScores[1] =  aiPlayers[0].name+ ": " + aiPlayers[0].score;
         
         //display ranking
         for (int i = 0; i <= 1; i++)
         {
            finalScoresText[i].text = finalScores[i];
         }
      }
   }

   public void RestartGame()
   {
      int scoreActual = int.Parse(textScore.text);
      
      int scoreTotal = PlayerPrefs.GetInt("scoreTotal", 0);
      scoreTotal += scoreActual;
      PlayerPrefs.SetInt("scoreTotal", scoreActual);
      //1000 pts per level
      int actualLevel =Mathf.FloorToInt(scoreTotal / 1000) + 1;
      PlayerPrefs.SetInt("level",actualLevel);


      int scoremax = PlayerPrefs.GetInt("scoreMax",0);

      if (scoreActual > scoremax)
      {
         PlayerPrefs.SetInt("scoreMax", int.Parse(textScore.text));
      }
      

      timerVal = 30;
      Application.LoadLevel(Application.loadedLevelName);
   }

   public void WatchExtraTimeVideo()
   {
      //TODO: show video ad
      //TODO: Dete
      GetExtraTime();
   } 
   
   public void GetExtraTime()
   {
      //TODO: show video ad
      //TODO: Dete
      timerVal = 5;
      textTimer.text = timerVal.ToString();
      InvokeRepeating("SetTimer",1,1);
      gameEnded = false;
      screenEnd.SetActive(false);
   }
   
}
