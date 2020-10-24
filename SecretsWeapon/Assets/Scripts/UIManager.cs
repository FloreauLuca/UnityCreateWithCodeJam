using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private StartMenu startMenu;
    private EndMenu endMenu;


    // Start is called before the first frame update
    void Start()
    {
        startMenu = FindObjectOfType<StartMenu>();
        endMenu = FindObjectOfType<EndMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayEnd()
    {
        endMenu.gameObject.SetActive(true);
    }

    public void DisplayStart()
    {
        startMenu.gameObject.SetActive(true);
    }
}
