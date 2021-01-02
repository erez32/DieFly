using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonScript : MonoBehaviour
{
     public void TriggerClick()
     {
          InGamePanel.m_Score = 0;
          InGamePanel.m_Money = 0;
          FlyManager.s_Level = 1;
          InGamePanel.ReturnToMainMenu();
     }
}
