using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretWeaponsManager : MonoBehaviour
{
    [SerializeField] private List<SecretWeapon> secretWeapons;
    [SerializeField] private List<Doors> doors;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < secretWeapons.Count; i++) {
            secretWeapons[i].SetIndex(i);
            doors[i].ForcedLocked = true;
        }
        doors[0].ForcedLocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Killed(int index)
    {
        doors[index].ForcedOpen = true;

        if (index + 1 < doors.Count)
        {
            doors[index + 1].ForcedLocked = false;
        }
    }
}
