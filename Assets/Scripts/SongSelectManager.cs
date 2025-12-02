using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongSelectManager : MonoBehaviour
{
    public List<MusicData> musics;
    public Transform content;
    public GameObject listItemPrefab;
    public SongDetailUI songDetailUI;
    void Start()
    {
        GenerateSongList();
    }

    void GenerateSongList()
    {
        foreach (var music in musics)
        {
            // 音樂列表項目
            GameObject item = Instantiate(listItemPrefab, content);
            Debug.Log("Created: " + item.name);
            item.transform.Find("MusicName").GetComponent<TMPro.TextMeshProUGUI>().text = music.musicName;
            // 按鈕事件
            Button btn = item.GetComponent<Button>();
            btn.onClick.AddListener(() => songDetailUI.ShowMusic(music));

        }
    }
}
