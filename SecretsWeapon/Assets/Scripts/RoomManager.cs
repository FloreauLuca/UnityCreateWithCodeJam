using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private Room[] rooms;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i].SetIndex(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {

        }
    }

    public void SelectRoom(int index, Vector2 cameraPosition)
    {
        for (int i = 0; i < rooms.Length; i++) {
            if (i != index)
            {
                rooms[i].Active = false;
            } else
            {
                rooms[i].Active = true;
            }
        }
        camera.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, 0) + Vector3.back * 10;
    }
}
