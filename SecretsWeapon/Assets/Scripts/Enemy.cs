using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameManager gameManager;

    private int life = 100;

    private SpriteRenderer spriteRenderer;

    private Player player;

    [Header("Mouvement")]
    private Rigidbody2D rigidbody;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private int angleOffset;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        player = FindObjectOfType<Player>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + angleOffset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rigidbody.velocity = transform.up * speed;
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
