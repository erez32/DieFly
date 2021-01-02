using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyManager : MonoBehaviour
{
     [SerializeField]
     private Transform[] m_SpawnPoints = null;
     [SerializeField]
     private Transform[] m_PlayerInteractionPoints = null; // right - 0, left - 1
     [SerializeField]
     private Transform[] m_FoodPoints = null;
     [SerializeField]
     private GameObject[] m_FlyPrefabs = null;
     public static Transform[] s_PlayerInteractionPoints;
     public static Transform[] s_FoodPoints;
     private float m_Timer;
     private float m_TimeToCreateFly;
     public static int s_Level = 1;

     private void Start()
     {
          s_PlayerInteractionPoints = m_PlayerInteractionPoints;
          s_FoodPoints = m_FoodPoints;
          m_TimeToCreateFly = Random.Range(0, 1);
     }

     private void Update()
     {
          m_Timer += Time.deltaTime;
          if(s_Level == 1)
          {
               if(m_Timer >= m_TimeToCreateFly)
               {
                    addNewFlyToGame(0);
                    m_Timer = 0;
                    m_TimeToCreateFly = Random.Range(1.5f, 2f);
               }
          }

          if(s_Level == 2)
          {
               if(m_Timer >= m_TimeToCreateFly)
               {
                    int FlyType = Random.Range(0, 10);
                    if(FlyType == 9)
                    {
                         addNewFlyToGame(1);
                    }
                    else
                    {
                         addNewFlyToGame(0);
                    }

                    m_Timer = 0;
                    m_TimeToCreateFly = Random.Range(0.6f, 0.8f);
               }
          }

          if(s_Level == 3)
          {
               if(m_Timer >= m_TimeToCreateFly)
               {
                    int FlyType = Random.Range(0, 10);
                    if(FlyType >= 7)
                    {
                         addNewFlyToGame(1);
                    }
                    else
                    {
                         addNewFlyToGame(0);
                    }

                    m_Timer = 0;
                    m_TimeToCreateFly = Random.Range(0.6f, 0.8f);
               }
          }

          if(s_Level == 4)
          {
               if(m_Timer >= m_TimeToCreateFly)
               {
                    int FlyType = Random.Range(0, 10);
                    if(FlyType >= 3)
                    {
                         addNewFlyToGame(1);
                    }
                    else
                    {
                         addNewFlyToGame(0);
                    }

                    m_Timer = 0;
                    m_TimeToCreateFly = Random.Range(0.6f, 0.8f);
               }

          }

          if(s_Level == 5)
          {
               if(m_Timer >= m_TimeToCreateFly)
               {
                    int FlyType = Random.Range(0, 10);
                    if(FlyType >= 9)
                    {
                         addNewFlyToGame(2);
                    }
                    else if(FlyType >= 2)
                    {
                         addNewFlyToGame(1);
                    }
                    else
                    {
                         addNewFlyToGame(0);
                    }

                    m_Timer = 0;
                    m_TimeToCreateFly = Random.Range(0.6f, 0.8f);
               }

          }

          if(s_Level == 6)
          {
               if(m_Timer >= m_TimeToCreateFly)
               {
                    int flyType = Random.Range(0, 10);

                    if(flyType >= 7)
                    {
                         addNewFlyToGame(2);
                    }
                    else
                    {
                         addNewFlyToGame(1);
                    }

                    m_Timer = 0;
                    m_TimeToCreateFly = Random.Range(0.6f, 0.8f);
               }
          }

          if(s_Level == 7)
          {
               if(m_Timer >= m_TimeToCreateFly)
               {
                    int flyType = Random.Range(0, 10);

                    if(flyType >= 5)
                    {
                         addNewFlyToGame(2);
                    }
                    else
                    {
                         addNewFlyToGame(1);
                    }

                    m_Timer = 0;
                    m_TimeToCreateFly = Random.Range(0.6f, 0.8f);
               }
          }

          if(s_Level == 8)
          {
               if(m_Timer >= m_TimeToCreateFly)
               {
                    int flyType = Random.Range(0, 10);

                    if(flyType >= 3)
                    {
                         addNewFlyToGame(2);
                    }
                    else
                    {
                         addNewFlyToGame(1);
                    }

                    m_Timer = 0;
                    m_TimeToCreateFly = Random.Range(0.6f, 0.8f);
               }
          }

          if(s_Level >= 9)
          {
               if(m_Timer >= m_TimeToCreateFly)
               {
                    int flyType = Random.Range(0, 10);

                    if(flyType >= 1)
                    {
                         addNewFlyToGame(2);
                    }
                    else
                    {
                         addNewFlyToGame(1);
                    }

                    m_Timer = 0;
                    m_TimeToCreateFly = Random.Range(0.1f, 0.2f);
               }
          }
     }

     private void addNewFlyToGame(int i_FlyType)
     {
          int life = 0;
          float speed = 1.3f;
          if(i_FlyType == 0)
          {
               life = 1;
          }
          else if(i_FlyType == 1)
          {
               life = 3;
          }
          else if(i_FlyType == 2)
          {
               life = 10;
          }

          GameObject butterfly = Instantiate(
               m_FlyPrefabs[i_FlyType],
               m_SpawnPoints[0].position,
               Quaternion.identity,
               transform);
          butterfly.GetComponent<FlyScript>().CreateFly(life, speed, 1);
     }
}

