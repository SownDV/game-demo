using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UICharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public Button m_PauseButton;

    void Start()
    {
        m_PauseButton.onClick.AddListener(OnPauseButtonClicked);
    }
    private void OnPauseButtonClicked()
    {
        SceneManager.LoadScene("Menu");
    }
}
