using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{

    public GameObject[] CharacterList;
    public GameObject CurrentCharacter;

    public int currID;
    public int previousID;

    public void CharacterSelect(int id)
    {
        MonsterSelector(false);

        CharacterList[currID].SetActive(false);
        currID = id;
        CharacterList[currID].SetActive(true);

        MonsterSelector(true);


    }

    public void MonsterSelector(bool show)
    {
        if (currID == 2)
        {
            for (int i = 2; i < CharacterList.Length; i++)
            {
                CharacterList[i].SetActive(show);
            }
        }
    }
}