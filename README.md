# RhythmLane

這是一個使用 Unity 開發的音樂節奏遊戲專案。玩家需要跟隨音樂節奏，在適當的時機按下對應的按鍵來獲得分數。

## 專案簡介

RhythmLane 是一個經典的下落式（或軌道式）節奏遊戲。專案包含了完整的遊戲流程，從歌曲選擇、遊玩介面到結算畫面。此外，還包含了一個簡易的譜面錄製工具，方便開發者製作新的關卡。

## 主要功能 (Features)

*   **核心玩法**: 支援多軌道的節奏打擊判定 (Perfect/Good/Miss)。
*   **歌曲選擇系統**: 瀏覽並選擇不同的樂曲進行遊玩。
*   **譜面系統**: 使用 ScriptableObject 管理樂曲資訊 (MusicData) 與譜面資料 (NoteChart)。
*   **即時錄製工具**: 內建 `ChartRecorder`，可以透過聆聽音樂並按下按鍵來即時生成譜面資料。
*   **分數結算**: 遊戲結束後顯示得分與評價。

## 專案結構 (Scripts)

主要程式碼位於 `Assets/Scripts/` 目錄下：

### 核心邏輯
*   `GameData.cs`: 儲存跨場景的全域資料（如當前選擇的歌曲、分數）。
*   `ArrowSpawner.cs`: 負責讀取譜面並生成箭頭 (Note)。
*   `Arrow.cs`: 控制單個箭頭的移動與銷毀。
*   `HitZone.cs`: 判定玩家輸入與打擊準確度。

### 資料結構
*   `MusicData.cs`: 定義樂曲的基本資訊（曲名、BPM、音檔等）。
*   `NoteChart.cs`: 儲存譜面的具體節奏點 (NoteData)。

### UI 與 流程控制
*   `SongSelectManager.cs`: 歌曲選擇選單的邏輯。
*   `MenuScene.cs`: 主選單控制。
*   `ScoreDisplay.cs`: 遊玩時的分數顯示。
*   `ResultUI.cs`: 結算畫面顯示。

### 工具
*   `ChartRecorder.cs`: 用於在編輯器或遊戲中錄製譜面的輔助工具。

## 開發環境

*   Unity 2022.3+ (建議)
*   C#

## 聲明

本專案部分程式碼與架構使用 **Gemini** 協助撰寫與重構。
