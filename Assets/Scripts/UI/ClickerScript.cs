using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerScript : MonoBehaviour
{
     [SerializeField]
     private GameObject m_Pointer = null;
     [SerializeField]
     private Material m_startingMaterial = null;
     [SerializeField]
     private Material m_HitMaterial = null;
     private static GameObject s_Pointer;
     private static Material s_HitMaterial;
     private static float s_TimeToBlink = 0;
     private static bool b_IsBlinking;

     // Start is called before the first frame update
     private void Start()
     {
          s_Pointer = m_Pointer;
          s_HitMaterial = m_HitMaterial;
     }

     // Update is called once per frame
     private void Update()
     {
          if(Input.anyKey)
          {
               RaycastHit hit;
               int layerMask = 7;
               Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.green);
               if(Physics.Raycast(transform.position, transform.forward, out hit, 10000, layerMask))
               {

                    if(hit.collider != null)
                    {
                         if(hit.collider.GetComponent<MainMenuButtonScript>() != null)
                         {
                              hit.collider.GetComponent<MainMenuButtonScript>().TriggerClick();
                         }
                         else if(hit.collider.GetComponent<WeaponContainer>() != null)
                         {
                              hit.collider.GetComponent<WeaponContainer>().triggerClick();
                         }
                         else if(hit.collider.GetComponent<ButtonScript>() != null)
                         {
                              hit.collider.GetComponent<ButtonScript>().triggerClick();
                         }
                    }
               }
          }

          if(b_IsBlinking)
          {
               s_TimeToBlink += Time.deltaTime;
               if(s_TimeToBlink >= 0.3f)
               {
                    b_IsBlinking = false;
                    s_Pointer.GetComponent<MeshRenderer>().material = m_startingMaterial;
                    s_TimeToBlink = 0;
               }
          }
     }

     public static void MakePointerBlink()
     {
          s_Pointer.GetComponent<MeshRenderer>().material = s_HitMaterial;
          b_IsBlinking = true;
     }
}
