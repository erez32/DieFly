using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
     [SerializeField]
     int m_Button = 0;
     [SerializeField]
     GameObject m_PanelManager = null;
     [SerializeField]
     GameObject m_menuButtons = null;

     public void triggerClick()
     {
          if(m_Button == 1) //start game
          {
               SceneManager.LoadScene("Game");
          }

          if(m_Button == 2) //How to play
          {
               m_PanelManager.GetComponent<PanelManager>().HowToPlay();
               m_menuButtons.SetActive(false);
          }

          if(m_Button == 3) //Scores
          {
               m_PanelManager.GetComponent<PanelManager>().ShowScores();
               m_menuButtons.SetActive(false);
          }

          if(m_Button == 4) //Exit
          {
               Application.Quit();
          }

          if(m_Button == 5) //close Scores
          {
               m_PanelManager.GetComponent<PanelManager>().CloseScoreboard();
               m_menuButtons.SetActive(true);
          }

          if(m_Button == 6) //Close how to play
          {
               m_PanelManager.GetComponent<PanelManager>().CloseHowToPlay();
               m_menuButtons.SetActive(true);
          }

          if(m_Button == 7) //Close lose game
          {
               m_PanelManager.GetComponent<PanelManager>().CloseLoseGame();
               m_menuButtons.SetActive(true);
          }
     }
}