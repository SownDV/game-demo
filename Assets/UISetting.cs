using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISetting : MonoBehaviour
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
