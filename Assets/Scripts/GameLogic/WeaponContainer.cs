using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponContainer : MonoBehaviour
{
     [SerializeField]
     private GameObject m_TheGlass = null;
     [SerializeField]
     private GameObject m_TheWeapon = null;
     [SerializeField]
     private int m_Price = 0;
     [SerializeField]
     private int m_Dmg = 0;

     public void triggerClick()
     {
          WeaponStore.PurchaseWeapon(m_TheGlass, m_TheWeapon, m_Price, m_Dmg);
     }
}