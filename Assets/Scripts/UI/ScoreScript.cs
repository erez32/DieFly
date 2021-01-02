using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

     [SerializeField]
     private Text m_Scores = null;
     [SerializeField]
     private Text m_Dates = null;
     private static Text s_Score;
     private static Text s_Date;
     private static int m_MaxScores = 10;
     private static int s_ScoresAmount;
     private static PlayerScore[] m_CurrentScores = new PlayerScore[m_MaxScores];

     private void Start()
     {
          s_Score = m_Scores;
          s_Date = m_Dates;
          s_ScoresAmount = PlayerPrefs.GetInt("Max");
          updateScoresPrefs();
     }

     private void updateScoresPrefs()
     {
          for(int i = 0; i < s_ScoresAmount; i++)
          {
               int score = PlayerPrefs.GetInt("Score" + i);
               string date = PlayerPrefs.GetString("Date" + i);
               PlayerScore newScore = new PlayerScore(score, date);
               m_CurrentScores[i] = newScore;
          }
     }

     public static void AddScore(int i_Score)
     {
          PlayerScore newScore = new PlayerScore(i_Score);

          for(int i = 0; i < m_MaxScores; i++)
          {
               if(i >= s_ScoresAmount)
               {
                    m_CurrentScores[i] = newScore;
                    s_ScoresAmount++;
                    break;
               }

               if(i_Score > m_CurrentScores[i].m_Score)
               {
                    PlayerScore temp = m_CurrentScores[i];
                    m_CurrentScores[i] = newScore;
                    newScore = temp;
               }
          }

          PlayerPrefs.SetInt("Max", s_ScoresAmount);
          for(int i = 0; i < s_ScoresAmount; i++)
          {
               PlayerPrefs.SetInt("Score" + i, m_CurrentScores[i].m_Score);
               PlayerPrefs.SetString("Date" + i, m_CurrentScores[i].ScoreDate);
          }
     }

     public static void UpdateLeaderboard()
     {
          string leaderboardScore = "";
          string leaderboardDate = "";

          for(int i = 0; i < s_ScoresAmount; i++)
          {
               leaderboardScore += (i + 1) + ". " + m_CurrentScores[i].m_Score + "\n";
               leaderboardDate += m_CurrentScores[i].ScoreDate + "\n";
          }

          s_Score.text = leaderboardScore;
          s_Date.text = leaderboardDate;
     }
}

public class PlayerScore
{
     public int m_Score;
     private string m_ScoreDate;

     public PlayerScore(int Score)
     {
          m_Score = Score;
          m_ScoreDate = DateTime.Now.ToString();
     }

     public PlayerScore(int Score, string Date)
     {
          m_Score = Score;
          m_ScoreDate = Date;
     }

     public string ScoreDate
     {
          get => m_ScoreDate;
          set => m_ScoreDate = value;
     }
}