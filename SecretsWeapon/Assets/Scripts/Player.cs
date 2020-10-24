using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;

    [Header("Mouvement")]
    private Rigidbody2D rigidbody;
    [SerializeField] private float speed = 5.0f;

    [Header("Weapon")]
    private SecretsWeapons.Weapon currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigidbody.velocity = direction * speed;
        if (Input.GetButton("Attack"))
        {
            Attack();
        }
    }

    void Attack()
    {
        Debug.Log("Attack");
    }

    public void CollectWeapon(SecretsWeapons.Weapon weapon)
    {
        currentWeapon = weapon;
    }
}
