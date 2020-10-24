using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameManager gameManager;

    private int life = 100;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        spriteRenderer.color = Color.white;
    }
}
