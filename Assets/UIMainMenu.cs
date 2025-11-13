using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    public Button m_PlayButton;
    public Button m_ChangeCharacterButton;
    public Button m_ExitButton;
    public Button m_SettingButton;

    public int LevelLoad = 0;

    // Các panel UI trong cùng 1 Canvas
    public GameObject mainMenuPanel;
    public GameObject changeCharacterPanel;
    public GameObject settingPanel;

    void Start()
    {
        m_PlayButton.onClick.AddListener(OnPlayButtonClicked);
        m_ChangeCharacterButton.onClick.AddListener(OnChangeCharacterButtonClicked);
        m_ExitButton.onClick.AddListener(OnExitButtonClicked);
        m_SettingButton.onClick.AddListener(SettingButtonClicked);

        // Khởi tạo: chỉ hiển thị main menu
        ShowPanel(mainMenuPanel);
    }

    private void OnPlayButtonClicked()
    {
        // Load level như trước
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level " + LevelLoad.ToString());
    }

    private void OnChangeCharacterButtonClicked()
    {
        ShowPanel(changeCharacterPanel);
    }

    private void SettingButtonClicked()
    {
        ShowPanel(settingPanel);
    }

    private void OnExitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // Hàm hiển thị panel và ẩn các panel khác
    private void ShowPanel(GameObject panelToShow)
    {
        mainMenuPanel.SetActive(panelToShow == mainMenuPanel);
        changeCharacterPanel.SetActive(panelToShow == changeCharacterPanel);
        settingPanel.SetActive(panelToShow == settingPanel);
    }
}
