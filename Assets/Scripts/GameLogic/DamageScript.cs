using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
     float m_timer = 0;

     private void Update()
     {
          if(m_timer > 0)
          {
               m_timer -= Time.deltaTime;
               if(m_timer < 0)
               {
                    gameObject.active = false;
               }

          }
     }

     private void OnEnable()
     {
          m_timer = 0.2f;
     }
}
