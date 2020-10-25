using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;
    private Player player;
    private SecretWeaponsManager secretWeaponsManager;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        player = FindObjectOfType<Player>();
        secretWeaponsManager = FindObjectOfType<SecretWeaponsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        uiManager.DisplayGameOver();
    }

    public void Win()
    {
        uiManager.DisplayEnd(secretWeaponsManager.KilledCount);
        player.Moveable = false;
    }

    public void StartGame()
    {
        player.Moveable = true;
    }
}
