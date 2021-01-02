using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
     [SerializeField]
     private Text m_LifeText = null;
     private int m_Life = 100;
     public static int s_Life;
     public static Text s_LifeText;

     private void Start()
     {
          Application.targetFrameRate = 60;
          s_Life = m_Life;
          s_LifeText = m_LifeText;
          s_LifeText.text = "Life: " + s_Life + "%";
     }

     private void Update()
     {

     }

     public static void LoseLife(int i_Amount)
     {
          s_Life -= i_Amount;
          s_LifeText.text = "Life: " + s_Life + "%";
          if(s_Life <= 0)
          {
               LoseGame();
          }
     }

     private static void LoseGame()
     {
          PanelManager.b_PlayerLost = true;
          ScoreScript.AddScore(InGamePanel.m_Score);
          SceneManager.LoadScene("MainMenu");
          InGamePanel.m_Money = 0;
          FlyManager.s_Level = 1;
     }
}