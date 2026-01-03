using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    // public int score = 0; // 改用 GameData.score
    // 顯示分數的 TextMeshPro 組件
    public TextMeshProUGUI ScoreText;

    void Start()
    {
        // 每次進入 GameScene 時歸零
        GameData.score = 0;
        // 更新分數顯示
        UpdateScoreText();
    }

    // 增加分數
    public void AddScore(int amount)
    {
        GameData.score += amount;
        UpdateScoreText();
    }

    // 更新介面上的分數文字
    void UpdateScoreText()
    {
        ScoreText.text = GameData.score.ToString();
    }
}
