using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongDetailUI : MonoBehaviour
{
    public Image coverImage;
    public TMPro.TextMeshProUGUI titleText;
    public TMPro.TextMeshProUGUI artistText;
    public TMPro.TextMeshProUGUI infoText;
    private MusicData current;

    // 顯示詳細資訊
    public void ShowMusic(MusicData music)
    {
        current = music;
        // 將音樂資料帶入右邊的detail UI
        coverImage.sprite = music.coverImage;
        titleText.text = music.musicName;
        artistText.text = music.author;
        infoText.text = $"Length: {music.length}";
    }

    // 按下播放按鈕
    public void Btn_Play() {
        if (current == null) {
            Debug.LogError("沒有選擇歌曲，無法開始遊戲");
            return;
        }
        // 將音樂存到GameData，以便在遊戲場景中使用
        GameData.selectedMusic = current;
        // 載入遊戲場景
        SceneManager.LoadScene("GameScene");
    }
}
