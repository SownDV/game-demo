using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public GameObject[] Character;
    public int Number;

    public void ChangeCharacter(int Num)
    {
        for (int i = 0; i < Character.Length; i++)
        {
            Character[i].SetActive(false);
        }

        Number += Num;

        if (Number >= Character.Length)
        {
            Number = 0;
        }
        else if (Number < 0)
        {
            Number = Character.Length - 1;
        }

        Character[Number].SetActive(true);
    }
}
