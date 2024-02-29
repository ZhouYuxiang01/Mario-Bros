using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
        Debug.Log("Start Game");
    }

    public void QuitGame()
    {
        // 打印到控制台，方便在编辑器中调试
        Debug.Log("Quit Game");

        // 退出游戏
        Application.Quit();
    }
}
