using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UIMainMenu : MonoBehaviour
{
    public Button m_PlayButton;
    public Button m_ChangeCharacterButton;
    public Button m_ExitButton;
    public Button m_SettingButton;

    public int LevelLoad = 0;

    void Start()
    {
        m_PlayButton.onClick.AddListener(OnPlayButtonClicked);
        m_ChangeCharacterButton.onClick.AddListener(OnChangeCharacterButtonClicked);
        m_ExitButton.onClick.AddListener(OnExitButtonClicked);
        m_SettingButton.onClick.AddListener(SettingButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Level " + LevelLoad.ToString());
    }

    private void OnChangeCharacterButtonClicked()
    {
        SceneManager.LoadScene("Change Character");
    }

    private void SettingButtonClicked()
    {
        SceneManager.LoadScene("Setting");
    }

    private void OnExitButtonClicked()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
