using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        string targetScene = "SongSelect";
        SceneManager.LoadScene(targetScene);
        Debug.Log("按鈕被按下，正在載入場景：" + targetScene);
    }
}
