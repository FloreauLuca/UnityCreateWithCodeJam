using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private RoomManager roomManager;
    private Vector2 cameraPosition;
    private bool active;
    public bool Active {
        get => active;
        set => active = value;
    }
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !active)
        {
            roomManager.SelectRoom(index, cameraPosition);
        }
    }

    public void SetIndex(int newIndex)
    {
        index = newIndex;
    }

}
