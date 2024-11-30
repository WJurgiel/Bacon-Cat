using System;
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject AttackBall;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isCasting = false;
    [SerializeField] float scaleMultipler = 1.008f;
    [SerializeField] Vector3 startingVector = new Vector3(0.2f, 0.2f, 1.0f);
    public void castSpell()
   {
       // Debug.Log(AttackBall.name);
       /*if (AttackBall.transform.localScale.x < 0.75f)
       {
            AttackBall.transform.localScale *= 1.01f;
           
       }*/
       AttackBall.transform.localScale = startingVector;
       StartCoroutine(ChangeSpellSize());
   }

    public void stopCasting()
    {
        StopAllCoroutines();
    }
    IEnumerator ChangeSpellSize()
    {
        while (AttackBall.transform.localScale.x < 0.75f)
        {
            AttackBall.transform.localScale *= scaleMultipler;
            yield return new WaitForSeconds(0.005f);
        }
    }
}
