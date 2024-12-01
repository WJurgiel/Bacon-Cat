using System.Collections;
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

   [SerializeField] private float timeToDisolve = 1f;
   private float dissolveTimer = 0f;
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
         LoseSanity(Random.Range(0f, 10f));
      }
   }
   public void RegainSanity()
   {
      currentSanity += baconRegainAmount;
      if(currentSanity >= maxSanity) currentSanity = maxSanity;
      UpdateEyes();
   }

   private bool isDead()
   {
      return currentSanity <= 0;
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

   private void CheckSanityIntegrity()
   {
      if (currentSanity <  0) currentSanity = 0; 
   }
   private void UpdateEyes()
   {
      if (eyesInTheShadow == null)
      {
         Debug.Log("No eyes");
         return;
      }
      if(eyesInTheShadow.activeSelf == false) eyesInTheShadow.SetActive(true);
      
      CheckSanityIntegrity();
      foreach (var eyeElement in eyesRenderer)
      {
         float targetAlpha = (maxSanity - currentSanity) / maxSanity;
         StartCoroutine(EyeInterpolation(targetAlpha));
      }
   }

   private IEnumerator EyeInterpolation(float targetAlpha)
   {
      float alphaStart = eyesRenderer[0].color.a;
      dissolveTimer = 0;

      while (dissolveTimer < timeToDisolve)
      {
         foreach (var eyeElement in eyesRenderer)
         {
            float newAlpha = Mathf.Lerp(alphaStart, targetAlpha, dissolveTimer / timeToDisolve);
            eyeElement.color = new Color(eyeElement.color.r, eyeElement.color.g, eyeElement.color.b,
               newAlpha);
         }
         dissolveTimer += Time.deltaTime;
         yield return null;
      }
   }
}
