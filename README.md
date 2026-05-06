# 多媒體播放器 (Custom Media Player)

這是一個基於 C# Windows Forms 開發的自訂多媒體播放器。本專案透過引入 `Windows Media Player` COM 元件，將預設的控制介面隱藏 (`uiMode = none`)，並完全由程式碼自刻 UI，提供更靈活的操作體驗與客製化視覺效果。

##  功能特色 (Features)

* **基礎播放控制**：支援載入多種影音格式 (MP4, WMV, AVI, WAV)，並具備自訂的「播放」、「暫停」、「停止」與「瀏覽」按鈕。
* **動態進度條與時間顯示**：
    * 實作 `TrackBar` 與 `Timer` 的雙向連動。
    * 游標會隨影片播放進度自動前進。
    * 支援拖曳滑桿來進行影片的快轉與倒轉。
    * 即時顯示影片目前播放時間與總時長 (例如 `01:23 / 04:56`)。
* **自適應視窗縮放 (Auto-Scaling UI)**：支援視窗大小動態調整，播放器畫面與底部控制列 (進度條、按鈕) 會根據視窗比例自動延伸與貼齊邊緣，維持良好的使用者體驗。

##  開發環境與技術 (Tech Stack)

* **語言**：C#
* **框架**：.NET Framework (Windows Forms)
* **核心元件**：Windows Media Player COM (`wmp.dll`)
* **開發工具**：Visual Studio

##  如何執行 (How to Run)

1. 將本專案 Clone 到本機：
   ```bash
   git clone [https://github.com/你的帳號/你的儲存庫名稱.git](https://github.com/你的帳號/你的儲存庫名稱.git)
   ```
2. 使用 Visual Studio 開啟 .sln 方案檔。

3. 若開啟表單時發生錯誤，請確認工具箱中已正確引入 Windows Media Player COM 元件。

4. 按下 F5 即可編譯並執行應用程式。

## 執行截圖 (Screenshots)
<img width="649" height="516" alt="image" src="https://github.com/user-attachments/assets/3f08f37c-56aa-4c1e-857b-0cfa91d5e4bc" />
<img width="1908" height="1137" alt="image" src="https://github.com/user-attachments/assets/ffef8944-148d-4cee-815d-b65649facbf9" />

