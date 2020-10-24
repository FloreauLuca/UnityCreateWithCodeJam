using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;

    [Header("Mouvement")]
    private Rigidbody2D rigidbody;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private int angleOffset;

    [Header("Weapon")]
    [SerializeField] private SOWeapon currentWeapon;
    [SerializeField] private LayerMask enemyLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigidbody.velocity = direction * speed;

        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + angleOffset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetButtonDown("Attack"))
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position + currentWeapon.boxOffset.y * transform.up + currentWeapon.boxOffset.x * transform.right, currentWeapon.boxSize, transform.rotation.eulerAngles.z, enemyLayerMask);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].gameObject.GetComponent<Enemy>().Hit(currentWeapon.damage);
            i++;
        }
    }

    public void CollectWeapon(SOWeapon weapon)
    {
        currentWeapon = weapon;
    }

    void OnDrawGizmos()
    {
        Color color;
        color = Color.red;
        color.a = 0.5f;
        Gizmos.color = color;
        Gizmos.DrawCube(transform.position + currentWeapon.boxOffset.y * transform.up + currentWeapon.boxOffset.x * transform.right, currentWeapon.boxSize);
    }
}
