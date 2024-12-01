using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerAttack : MonoBehaviour
{
    public Light2D light;
    [SerializeField] float scaleMultipler = 1.008f;
    [SerializeField] Vector3 startingVector = new Vector3(0.2f, 0.2f, 1.0f);
    [SerializeField] float[] speed;
    private int numberOfMoves = 100;
    private GameObject spawner = null;
    public bool isSpelling = false;
    public float[] damageMultipliers = {0f, 310f, 210f, 210f};
    public float[] range = { 0f, 15f, 5f, 6f };
    public float damage = 0f;
    static private int level = 1;
    [SerializeField] Sprite[] sprites = new Sprite[4];
    

    private void Awake()
    {
        speed.Append(0.0f);
        speed.Append(0.1f);
        speed.Append(0.15f);
        speed.Append(0.2f);
    }
    

    void Update()
    {
        if (isSpelling)
        {
            gameObject.transform.position = spawner.transform.position;
        }
    }

    public void upgrade()
    {
        if (level<3)
            level++;
    }

    public void castSpell(GameObject spellSpawner)
   {
       GetComponent<SpriteRenderer>().sprite = sprites[level];
       
       spawner = spellSpawner;
       transform.localScale = startingVector;
       StartCoroutine(ChangeSpellSize());
   }

    public void stopCasting(Vector3 moveDirection)
    {
        isSpelling = false;
        damage = (transform.localScale.x - startingVector.x) * damageMultipliers[level];
        light.pointLightOuterRadius = transform.localScale.x;
        StopAllCoroutines();
        StartCoroutine(MoveSpell(moveDirection));
    }
    IEnumerator ChangeSpellSize()
    {
        while (transform.localScale.x < 0.65f)
        {
            transform.localScale *= scaleMultipler;
            light.pointLightOuterRadius = transform.localScale.x;
            yield return new WaitForSeconds(0.005f);
        }
    }

    IEnumerator MoveSpell(Vector3 moveDirection)
    {
        float t = 50f / moveDirection.magnitude;
        Vector3 moveVector = spawner.transform.position + moveDirection * t;
        while (Vector3.Distance(transform.position, moveVector) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveVector, 0.02f);
            transform.position += (moveDirection * 0.2f);
            light.transform.position = transform.position;
            yield return new WaitForSeconds(0.005f);
        }
        Destroy(gameObject);
                                                                  
    }
}
