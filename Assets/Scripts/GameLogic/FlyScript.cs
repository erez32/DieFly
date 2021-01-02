using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyScript : MonoBehaviour
{
     [SerializeField]
     private AudioClip m_DeathSound = null;
     [SerializeField]
     private GameObject m_DmgObject = null;
     private Vector3 m_CurrentflyingPoint = new Vector3(0, 0, 0);
     private int m_CurrentLife, m_MaxLife;
     private int m_FlyingMethod;
     private float m_Speed;
     private float m_RotationSpeed = 300f;
     private bool m_IsFlyingToPoint;
     private bool m_IsFlyingToFood;
     private float m_TimeFlyingToPoint;
     private float m_MaxTimeFlyingToPoint;
     private float m_EatFoodTimer;
     private bool m_IsEatingFood;
     private float m_AttackTimer;

     public void CreateFly(int i_MaxLife, float i_Speed, int i_FlyingMethod)
     {
          m_CurrentLife = i_MaxLife;
          m_MaxLife = i_MaxLife;
          m_Speed = i_Speed;
          m_FlyingMethod = i_FlyingMethod;
     }

     private void Update()
     {
          if(m_IsEatingFood)
          {
               m_EatFoodTimer += Time.deltaTime;
               if(m_EatFoodTimer >= 4)
               {
                    m_IsEatingFood = false;
                    m_IsFlyingToFood = false;
               }

               m_AttackTimer += Time.deltaTime;
               if(m_AttackTimer >= 0.5f)
               {
                    m_AttackTimer = 0;
                    MainManager.LoseLife(1);
               }
          }
          else
          {
               flyingAlgorithm();
               if(m_IsFlyingToPoint)
               {
                    Quaternion rotTarget = Quaternion.LookRotation(m_CurrentflyingPoint - this.transform.position);
                    this.transform.rotation = Quaternion.RotateTowards(
                         this.transform.rotation,
                         rotTarget,
                         m_RotationSpeed * Time.deltaTime);
               }

               m_TimeFlyingToPoint += Time.deltaTime;
          }
     }

     private void flyingAlgorithm()
     {
          float step = m_Speed * Time.deltaTime;
          if((FlyManager.s_PlayerInteractionPoints[1].position.y - 0.3 > transform.position.y) && !m_IsFlyingToPoint)
          {
               GetComponent<Rigidbody>().velocity = new Vector3(0, m_Speed, 0);
          }
          else if(!m_IsFlyingToPoint)
          {
               flyToNewPoint();
          }
          else if(m_IsFlyingToFood)
          {
               if(Vector3.Distance(transform.position, m_CurrentflyingPoint) < 0.1f)
               {
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    m_EatFoodTimer = 0;
                    m_IsEatingFood = true;
               }
          }
          else if(m_IsFlyingToPoint)
          {
               if(Vector3.Distance(transform.position, m_CurrentflyingPoint) < 0.1f
                  || (m_TimeFlyingToPoint > m_MaxTimeFlyingToPoint))
               {

                    flyToNewPoint();
                    m_MaxTimeFlyingToPoint = Random.Range(0, 1f);
                    m_TimeFlyingToPoint = 0;

               }
          }
     }

     private void flyToNewPoint()
     {
          if(Random.Range(0, 30) < 1) //flying to food
          {
               m_CurrentflyingPoint = FlyManager.s_FoodPoints[Random.Range(0, 2)].position;
               m_IsFlyingToFood = true;
          }
          else //flying around
          {
               float tempX = Random.Range(
                    FlyManager.s_PlayerInteractionPoints[0].position.x,
                    FlyManager.s_PlayerInteractionPoints[1].position.x);
               float tempY = Random.Range(
                    FlyManager.s_PlayerInteractionPoints[0].position.y,
                    FlyManager.s_PlayerInteractionPoints[1].position.y);
               float tempZ = Random.Range(
                    FlyManager.s_PlayerInteractionPoints[0].position.z,
                    FlyManager.s_PlayerInteractionPoints[1].position.z);
               m_CurrentflyingPoint = new Vector3(tempX, tempY, tempZ);
          }

          GetComponent<Rigidbody>().velocity = Vector3.Normalize(m_CurrentflyingPoint - transform.position) * m_Speed;
          m_IsFlyingToPoint = true;
     }

     private void OnTriggerEnter(Collider other)
     {
          if(other.transform.tag == "Weapon")
          {
               m_CurrentLife -= WeaponScript.m_CurrentWeaponDmg;
               ClickerScript.MakePointerBlink();
               m_DmgObject.SetActive(true);
               if(m_CurrentLife <= 0)
               {
                    InGamePanel.updateScore(m_MaxLife);
                    InGamePanel.addMoney(m_MaxLife);
                    AudioSource.PlayClipAtPoint(m_DeathSound, transform.position, 0.25f);
                    Destroy(gameObject);
               }
          }
     }
}
