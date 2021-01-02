using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGamePanel : MonoBehaviour
{
     [SerializeField]
     private Text m_ScoreText = null;
     private static Text s_ScoreText;
     public static int m_Score;
     private static float s_Timer;
     [SerializeField]
     private Text m_MoneyText = null;
     private static Text s_MoneyText;
     public static int m_Money;

     public static void ReturnToMainMenu()
     {
          SceneManager.LoadScene("MainMenu");
     }

     private void Start()
     {
          s_ScoreText = m_ScoreText;
          s_ScoreText.text = "Score: " + m_Score;
          s_MoneyText = m_MoneyText;
     }

     private void Update()
     {
          s_Timer += Time.deltaTime;
     }

     public static void updateScore(int scoreToAdd)
     {
          m_Score += scoreToAdd;
          s_ScoreText.text = "Score: " + m_Score;
     }

     public static void addMoney(int i_FlyLifeAmount)
     {
          if(i_FlyLifeAmount == 1)
          {
               m_Money += 1;
          }

          else if(i_FlyLifeAmount == 3)
          {
               m_Money += 2;
          }

          else if(i_FlyLifeAmount == 10)
          {
               m_Money += 5;
          }

          displayNewMoneyValue();
     }

     public static void displayNewMoneyValue()
     {
          s_MoneyText.text = "Money: " + m_Money + "$";
     }
}