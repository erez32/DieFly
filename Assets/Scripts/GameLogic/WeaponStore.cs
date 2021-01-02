using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStore : MonoBehaviour
{
     [SerializeField]
     private AudioSource m_BuySound = null;
     private static AudioSource s_BuySound;

     private void Start()
     {
          s_BuySound = m_BuySound;
     }

     public static void PurchaseWeapon(GameObject i_Container, GameObject i_TheWeapon, int i_Price, int i_Dmg)
     {
          if(i_Container.activeInHierarchy)
          {
               if(InGamePanel.m_Money >= i_Price)
               {
                    InGamePanel.m_Money -= i_Price;
                    InGamePanel.displayNewMoneyValue();
                    i_Container.SetActive(false);
                    WeaponScript.EquipWeapon(i_TheWeapon);
                    WeaponScript.m_CurrentWeaponDmg = i_Dmg;
                    s_BuySound.Play();
               }
          }
          else
          {
               WeaponScript.EquipWeapon(i_TheWeapon);
               WeaponScript.m_CurrentWeaponDmg = i_Dmg;
          }
     }
}