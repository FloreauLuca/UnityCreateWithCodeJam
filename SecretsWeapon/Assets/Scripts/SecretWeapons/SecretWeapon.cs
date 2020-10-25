using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretWeapon : MonoBehaviour
{
    private Player player;
    private bool canBeKilled;
    private bool isDead;

    private bool isOpen;
    public bool IsOpen
    {
        get => isOpen;
        set => isOpen = value;
    }
    private int index;

    [SerializeField] private GameObject uiPanel;
    [SerializeField] private SOWeapon weapon;
    private SecretWeaponsManager secretWeaponsManager;
    [SerializeField] private GameObject killCam;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        secretWeaponsManager = FindObjectOfType<SecretWeaponsManager>();
        killCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canBeKilled && !isDead)
        {
            if (Input.GetButtonDown("Attack"))
            {
                player.CollectWeapon(weapon);
                canBeKilled = false;
                uiPanel.SetActive(false);
                isDead = true;
                GetComponentInChildren<SpriteRenderer>().color = Color.red;
                secretWeaponsManager.Killed(index);
                StartCoroutine(KillCamAnim());
            }
        }
    }

    IEnumerator KillCamAnim()
    {
        killCam.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        killCam.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isDead)
        {
            canBeKilled = true;
            uiPanel.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isDead)
        {
            canBeKilled = false;
            uiPanel.SetActive(false);
        }
    }


    public void SetIndex(int newIndex)
    {
        index = newIndex;
    }
}