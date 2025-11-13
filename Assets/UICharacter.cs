using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UICharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public Button m_PauseButton;
    public Button m_PlayButton;
    public int LevelLoad = 0;


    void Start()
    {
        m_PauseButton.onClick.AddListener(OnPauseButtonClicked);
        m_PlayButton.onClick.AddListener(OnPlayButtonClicked);
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
