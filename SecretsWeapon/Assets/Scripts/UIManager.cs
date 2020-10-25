using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private StartMenu startMenu;
    [SerializeField] private EndMenu endMenu;

    [SerializeField] private GameObject gameOverMenu;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayGameOver()
    {
        gameOverMenu.SetActive(true);
    }

    public void DisplayEnd(int killedCount)
    {
        endMenu.gameObject.SetActive(true);
        endMenu.Display(killedCount);
    }

    public void DisplayStart()
    {
        startMenu.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        gameManager.StartGame();
        startMenu.gameObject.SetActive(false);
    }
}
