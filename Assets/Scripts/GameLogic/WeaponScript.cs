using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
     [SerializeField]
     private GameObject m_WeaponSlot = null;
     [SerializeField]
     private GameObject[] m_Weapons = null;
     [SerializeField]
     private Transform m_attackingPoint = null;
     [SerializeField]
     private AudioSource m_AttackAudio = null;
     [SerializeField]
     private CapsuleCollider collider = null;
     private bool m_IsAttacking;
     private Vector3 m_StartingWeaponSlotPos;
     private float m_WeaponRotationSpeed = 450;
     private float m_WeaponSpeedMoving = 1;
     private float m_MaxTimeOfAttack = 0.3f;
     private float m_CurrentTimeOfAttack = 0f;
     private static GameObject s_WeaponSlot;
     private static GameObject s_EquippedWeapon;
     public static int m_CurrentWeaponDmg = 1;



     private void Start()
     {
          m_StartingWeaponSlotPos = m_WeaponSlot.transform.localPosition;
          s_WeaponSlot = m_WeaponSlot;
          EquipWeapon(m_Weapons[2]);
     }

     // Update is called once per frame
     private void Update()
     {
          if(m_IsAttacking)
          {
               m_CurrentTimeOfAttack += Time.deltaTime;
               Quaternion rotTarget = Quaternion.LookRotation(new Vector3(0, -1, 0f));
               m_WeaponSlot.transform.localRotation = Quaternion.RotateTowards(
                    m_WeaponSlot.transform.localRotation,
                    rotTarget,
                    m_WeaponRotationSpeed * Time.deltaTime);
          }

          if(m_CurrentTimeOfAttack > m_MaxTimeOfAttack)
          {
               m_IsAttacking = false;
               collider.enabled = false;
               m_WeaponSlot.transform.localPosition = m_StartingWeaponSlotPos;
               m_WeaponSlot.transform.localRotation = Quaternion.identity;
               m_WeaponSlot.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
               m_CurrentTimeOfAttack = 0;
          }

          if(Vector3.Distance(m_attackingPoint.position, m_WeaponSlot.transform.position) < 0.1f)
          {
               m_WeaponSlot.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
          }
     }

     public static void EquipWeapon(GameObject i_ChoosedWeapon)
     {
          if(s_EquippedWeapon != null)
          {
               Destroy(s_EquippedWeapon);
          }

          s_EquippedWeapon = Instantiate(
               i_ChoosedWeapon,
               s_WeaponSlot.transform.position,
               Quaternion.identity,
               s_WeaponSlot.transform);
          s_EquippedWeapon.transform.localRotation = Quaternion.identity;
     }

     public void AttackWithWeapon()
     {
          if(!m_IsAttacking)
          {
               m_CurrentTimeOfAttack = 0;
               m_WeaponSlot.GetComponent<Rigidbody>().velocity =
                    Vector3.Normalize(m_attackingPoint.position - m_WeaponSlot.transform.position)
                    * m_WeaponSpeedMoving;
               m_IsAttacking = true;
               m_AttackAudio.time = 0.2f;
               m_AttackAudio.Play();
               collider.enabled = true;
          }
     }
}