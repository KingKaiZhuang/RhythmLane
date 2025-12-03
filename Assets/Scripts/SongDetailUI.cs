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

    public void ShowMusic(MusicData music)
    {
        current = music;

        coverImage.sprite = music.coverImage;
        titleText.text = music.musicName;
        artistText.text = music.author;
        infoText.text = $"BPM: {music.bpm}  Length: {music.length}";
    }

    public void Btn_Play() {
        if (current == null) {
            Debug.LogError("沒有選擇歌曲，無法開始遊戲");
            return;
        }

        GameData.selectedMusic = current;
        SceneManager.LoadScene("GameScene");
    }
}
