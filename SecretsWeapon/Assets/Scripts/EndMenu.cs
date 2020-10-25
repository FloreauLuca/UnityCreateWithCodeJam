using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Display(int killedCount)
    {
        for (int i = 0; i < killedCount; i++) {
            objects[i].SetActive(true);
        }
    }
}
