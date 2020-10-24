using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private GameManager gameManager;

    private bool playerDetected;
    private bool forcedLocked;
    public bool ForcedLocked {
        get => forcedLocked;
        set => forcedLocked = value;
    }
    private bool forcedOpen;
    public bool ForcedOpen {
        get => forcedOpen;
        set => forcedOpen = value;
    }
    private bool open;

    [Header("Anim")]
    [SerializeField] private float duration;
    [SerializeField] private Transform rightDoorTransform;
    [SerializeField] private Transform leftDoorTransform;
    private Vector2 rightDoorStartPos;
    private Vector2 leftDoorStartPos;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rightDoorStartPos = rightDoorTransform.position;
        leftDoorStartPos = leftDoorTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OpenDoor()
    {
        if (!open && !forcedLocked)
        {
            open = true;
            StopAllCoroutines();
            StartCoroutine(OpenDoorAnim());
        }
    }

    public void CloseDoor()
    {
        if (open && !forcedOpen)
        {
            open = false;
            StopAllCoroutines();
            StartCoroutine(CloseDoorAnim());
        }
    }

    IEnumerator OpenDoorAnim()
    {
        rightDoorTransform.position = rightDoorStartPos;
        leftDoorTransform.position = leftDoorStartPos;
        for (int i = 0; i < 10; i++) {
            rightDoorTransform.position = Vector2.Lerp(rightDoorStartPos, rightDoorStartPos + (Vector2)transform.right, i / 10.0f);
            leftDoorTransform.position = Vector2.Lerp(leftDoorStartPos, leftDoorStartPos - (Vector2)transform.right, i / 10.0f);
            yield return new WaitForSeconds(duration/10.0f);
        }
        rightDoorTransform.position = rightDoorStartPos + (Vector2)transform.right;
        leftDoorTransform.position = leftDoorStartPos - (Vector2)transform.right;
    }

    IEnumerator CloseDoorAnim()
    {
        rightDoorTransform.position = rightDoorStartPos + (Vector2)transform.right;
        leftDoorTransform.position = leftDoorStartPos - (Vector2)transform.right;
        for (int i = 0; i < 10; i++)
        {
            rightDoorTransform.position = Vector2.Lerp(rightDoorStartPos + (Vector2)transform.right, rightDoorStartPos, i / 10.0f);
            leftDoorTransform.position = Vector2.Lerp(leftDoorStartPos - (Vector2)transform.right, leftDoorStartPos, i / 10.0f);
            yield return new WaitForSeconds(duration / 10.0f);
        }
        rightDoorTransform.position = rightDoorStartPos;
        leftDoorTransform.position = leftDoorStartPos;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            playerDetected = true;
            OpenDoor();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = false;
            CloseDoor();
        }
    }

    void OnDrawGizmos()
    {
        Color color;
        if (forcedOpen)
        {
            color = Color.green;
        } else if (forcedLocked)
        {
            color = Color.red;
        } else if (playerDetected)
        {
            color = Color.blue;
        } else
        {
            color = Color.white;
        }
        color.a = 0.5f;
        Gizmos.color = color;
        if (open)
        {
            Gizmos.DrawWireSphere(transform.position + transform.up, 0.5f);
        } else
        {
            Gizmos.DrawSphere(transform.position + transform.up, 0.5f);
        }
    }
}
