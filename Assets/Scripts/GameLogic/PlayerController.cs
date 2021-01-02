using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     [SerializeField]
     private GameObject m_WeaponManager = null;

     private void Update()
     {
          if(Input.anyKeyDown)
          {
               m_WeaponManager.GetComponent<WeaponScript>().AttackWithWeapon();

          }
     }
}