using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public UIMainMenu m_MainMenu;
    public UISetting m_Seetings;
    public UICharacter m_Character;

    void Awake()
    {
        Instance = this;
    }

    public void ShowSetting(bool active)
    {
        m_Seetings.gameObject.SetActive(active);
    }
    public void ShowCharacter(bool active)
    {
        m_Character.gameObject.SetActive(active);
    }
}
