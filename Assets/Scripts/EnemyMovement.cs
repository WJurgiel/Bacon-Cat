using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    public GameObject player;
    private float health = 100f;
    private Sprite normalSprite;
    private Sprite HurtSprite;
    private void Awake()
    {
        normalSprite = Resources.Load<Sprite>("Sprites/Enemy");
        HurtSprite = Resources.Load<Sprite>("Sprites/hurtEnemy");
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        move();
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        Debug.Log(transform.rotation.eulerAngles);
        if (transform.rotation.eulerAngles.z >= 90.0f && transform.rotation.eulerAngles.z <= 270.0f)
        {
            GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipY = false;
        }
    }

    public void move()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Orb"))
        {
            // StartCoroutine(Hurt());
            health -= collision.gameObject.GetComponent<PlayerAttack>().damage;
            Debug.Log(health);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Hurt()
    {
        Sprite enemySprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        Debug.Log("Hurt");
        enemySprite = normalSprite;
        yield return new WaitForSeconds(0.1f);
        enemySprite = HurtSprite;
        Debug.Log("End");

    }
}
