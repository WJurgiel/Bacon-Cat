using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerAttack : MonoBehaviour
{
    public Light2D light;
    [SerializeField] float scaleMultipler = 1.008f;
    [SerializeField] Vector3 startingVector = new Vector3(0.2f, 0.2f, 1.0f);
    [SerializeField] float speed = 0.1f;
    [SerializeField] float distance = 1f;
    private int numberOfMoves = 100;
    private GameObject spawner;
    private bool isSpelling = true;

    void Update()
    {
        if (isSpelling)
        {
            gameObject.transform.position = spawner.transform.position;
        }
    }
    public void castSpell(GameObject spellSpawner)
   {
       spawner = spellSpawner;
       transform.localScale = startingVector;
       StartCoroutine(ChangeSpellSize());
   }

    public void stopCasting(Vector3 moveDirection)
    {
        isSpelling = false;
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
        
        for (int i = 0; i < numberOfMoves; i++)
        {
            transform.position += moveDirection * speed;
            light.transform.position = transform.position;
            yield return new WaitForSeconds(0.005f);
        }
        Destroy(gameObject);
    }
}
