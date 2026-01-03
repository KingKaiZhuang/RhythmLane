using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultUI : MonoBehaviour
{
    // 用於顯示分數的 UI 文字
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // 確保 scoreText 有被賦值
        if (scoreText != null)
        {
            // 將 GameData 中的分數轉換為字串並顯示
            scoreText.text = GameData.score.ToString();
        }
    }
}
