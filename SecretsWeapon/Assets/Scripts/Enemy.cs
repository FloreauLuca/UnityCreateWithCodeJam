using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameManager gameManager;

    private SpriteRenderer spriteRenderer;

    private Player player;

    [Header("Mouvement")]
    private Rigidbody2D rigidbody;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private int angleOffset;

    [Header("Attack")]
    [SerializeField] private int life = 100;
    [SerializeField] private int damage = 5;
    [SerializeField] private float cooldown = 1.0f;
    private bool canAttack = false;
    private float attackTimer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + angleOffset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rigidbody.velocity = transform.up * speed;
        if (canAttack)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= cooldown)
            {
                Attack();
                attackTimer = 0.0f;
            }
        } else {
            attackTimer = cooldown;
        }
    }

    void Attack()
    {
        StartCoroutine(AttackAnim());
        player.Hit(damage);
    }

    public void Hit(int damage)
    {
        life -= damage;
        if (life > 0)
        {
            StartCoroutine(HitAnim());
        } else {
            Destroy(gameObject);
        }
    }

    IEnumerator HitAnim()
    {
        spriteRenderer.color = Color.red; ;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.grey;
    }

    IEnumerator AttackAnim()
    {
        spriteRenderer.color = Color.blue; ;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.grey;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            canAttack = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canAttack = false;
        }
    }
}
