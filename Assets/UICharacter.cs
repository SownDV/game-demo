using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class UICharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterDatabase m_Database;
    public Button m_PauseButton;
    public Button m_PlayButton;

    public Button m_NextCharacterBtn, m_PreviousCharacterBtn;
    public int LevelLoad = 0;
    public Image m_MainCharacterImg;
    private int m_CurrentCharacter;

    void Start()
    {
        m_PauseButton.onClick.AddListener(OnPauseButtonClicked);
        m_PlayButton.onClick.AddListener(OnPlayButtonClicked);
        m_NextCharacterBtn.onClick.AddListener(OnNextCharacterClicked);
        m_PreviousCharacterBtn.onClick.AddListener(OnPreviousCharacterClicked);
        m_CurrentCharacter = PlayerPrefs.GetInt(CharacterManager.SelectionKey, 0);

        UpdateCharacterUI();

    }

    private void OnNextCharacterClicked()
    {
        m_CurrentCharacter++;
        m_CurrentCharacter = Mathf.Clamp(m_CurrentCharacter, 0, m_Database.characterCount - 1);

        UpdateCharacterUI();

        Save();
    }


    private void OnPreviousCharacterClicked()
    {
        m_CurrentCharacter--;
        m_CurrentCharacter = Mathf.Clamp(m_CurrentCharacter, 0, m_Database.characterCount - 1);
        UpdateCharacterUI();
        Save();
    }

    private void UpdateCharacterUI()
    {

        m_NextCharacterBtn.gameObject.SetActive(m_CurrentCharacter < m_Database.characterCount - 1);
        m_PreviousCharacterBtn.gameObject.SetActive(m_CurrentCharacter > 0);

        m_MainCharacterImg.sprite = m_Database.GetCharacter(m_CurrentCharacter).CharacterSprite;
    }

    private void Save()
    {
        PlayerPrefs.SetInt(CharacterManager.SelectionKey, m_CurrentCharacter);
    }

    private void OnPauseButtonClicked()
    {
        SceneManager.LoadScene("Menu");
    }

    private void OnPlayButtonClicked()
    {
        // Load level như trước
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level " + LevelLoad.ToString());
    }
}
