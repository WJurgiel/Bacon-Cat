using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SanitySystem : MonoBehaviour
{
   [SerializeField] private float maxSanity;
   [SerializeField] private float currentSanity;

   [SerializeField] private float baconRegainAmount;

   [SerializeField] private GameObject eyesInTheShadow;
   [SerializeField] private List<SpriteRenderer> eyesRenderer;
   
   // Sanity to zdrowie, odzyskiwanie przy ognisku
   // sanity wskazywane jest przez to jak wielkie oczy som
   
   void Start()
   {
      currentSanity = maxSanity;
      UpdateEyes();
   }

   void Update()
   {
      if (Input.GetKeyDown(KeyCode.J))
      {
         RegainSanity();
      }
      if (Input.GetKeyDown(KeyCode.K))
      {
         LoseSanity(Random.Range(0f, 30f));
      }
   }
   public void RegainSanity()
   {
      currentSanity += baconRegainAmount;
      if(currentSanity >= maxSanity) currentSanity = maxSanity;
      UpdateEyes();
   }

   public void FireplaceMeditate()
   {
      currentSanity = maxSanity;
      UpdateEyes();
   }

   public void LoseSanity(float amount)
   {
      currentSanity -= amount;
      UpdateEyes();
   }
   private void UpdateEyes()
   {
      if (eyesInTheShadow == null)
      {
         Debug.Log("No eyes");
         return;
      }
      if(eyesInTheShadow.activeSelf == false) eyesInTheShadow.SetActive(true);
      foreach (var eyeElement in eyesRenderer) 
      {
         eyeElement.color = new Color(eyeElement.color.r, eyeElement.color.g, eyeElement.color.b,
            (maxSanity - currentSanity) / maxSanity);
      }
     
   }
}
