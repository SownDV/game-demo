using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Handle Character spawn when start level
/// </summary>
public class CharacterManager : MonoBehaviour
{
    public const string SelectionKey = "selectionOption";
    // Start is called before the first frame update
    public Transform m_SpawnPoint;
    public CharacterDatabase charracterDB;
    private int selectedOption = 0;
    private CharacterMovement currentPlayer;

    void Start()
    {
        selectedOption = PlayerPrefs.GetInt(SelectionKey, 0);
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        var find = charracterDB.GetCharacter(selectedOption);
        if (find != null)
        {
            currentPlayer = Instantiate(find.CharacterPrefab, m_SpawnPoint.position, Quaternion.identity).GetComponent<CharacterMovement>();
        }
    }

    public void GameOver()
    {
        if (currentPlayer != null)
        {
            currentPlayer.GameOver();
        }
    }
}
