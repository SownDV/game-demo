using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterDatabase charracterDB;
    public TextMeshProUGUI nameText;
    public SpriteRenderer artworkImage;

    private int selectedOption = 0;

    void Start()
    {
        if (!PlayerPrefs.HasKey("selectionOption"))
        {
            selectedOption = 0;
        }

        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;
        if (selectedOption >= charracterDB.characterCount)
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = charracterDB.characterCount - 1;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = charracterDB.GetCharacter(selectedOption);
        artworkImage.sprite = character.CharacterSprite;
        nameText.text = character.CharacterName;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    private void ChangeScence(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
