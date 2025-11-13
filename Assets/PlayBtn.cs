using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayBtn : MonoBehaviour
{
    // Start is called before the first frame update
    public Button m_PlayButton;
    public int LevelLoad = 0;

    void Start()
    {
        m_PlayButton.onClick.AddListener(OnPlayButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Level " + LevelLoad.ToString());
    }

}
