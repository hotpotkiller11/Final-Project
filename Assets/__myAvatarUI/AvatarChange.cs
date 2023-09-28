using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarChange : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    private GameObject[] characterGameObjects;
    private int selectedIndex = 0;
    private int length;//所有可供选择角色的个数；
    // Start is called before the first frame update
    void Start()
    {
        length = characterPrefabs.Length;
        characterGameObjects = new GameObject[length];
        for (int i = 0; i < length; i++)
        {
            characterGameObjects[i] = GameObject.Instantiate(characterPrefabs[i], transform.position, transform.rotation) as GameObject;
        }
        UpdateCharacterShow();
    }
    void UpdateCharacterShow()
    {//show selelcted；
        characterGameObjects[selectedIndex].SetActive(true);
        for (int i = 0; i < length; i++)
        {
            if (i != selectedIndex)
            {
                characterGameObjects[i].SetActive(false);//hide other；
            }
        }
    }
    public void OnNextButtonClick()
    {//buttonclicked；
        selectedIndex++;
        selectedIndex %= length;
        UpdateCharacterShow();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
