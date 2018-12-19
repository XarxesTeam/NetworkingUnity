using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransferMain : MonoBehaviour
{
    public int _prefab_index = -1;

    public void StartGame()
    {
        StaticClass.prefab_index = _prefab_index;
        SceneManager.LoadScene("Game");
    }

    public void ReturnToMenu()
    {
        StaticClass.prefab_index = _prefab_index;
        SceneManager.LoadScene("MainMenu");
    }
}

public static class StaticClass
{
    public static int prefab_index { get; set; }
}
