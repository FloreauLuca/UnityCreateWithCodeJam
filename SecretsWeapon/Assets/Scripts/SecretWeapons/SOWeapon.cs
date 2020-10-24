using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SecretWeapon", menuName = "ScriptableObjects/SOWeapon", order = 1)]
public class SOWeapon : ScriptableObject
{
    public enum Name
    {
        BILLY,
        FLUFFY,
        POONY,
        BOOLLY,
        CUTTY
    }

    public string name;
    public Vector2 boxSize;
    public Vector2 boxOffset;
    public int damage;
    public float cooldown;
    public Sprite weaponSprite;
    public Sprite weaponAttackSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
