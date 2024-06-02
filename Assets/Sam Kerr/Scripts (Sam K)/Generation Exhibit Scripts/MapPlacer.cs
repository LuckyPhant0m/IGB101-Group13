using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlacer : MonoBehaviour
{
    [SerializeField] private GameObject[] rooms;
    [SerializeField] private SpriteRenderer[] roomIcons;
    [SerializeField] private Sprite[] icons;
    [SerializeField] private MapGeneration mapGen;

    void Start()
    {
        foreach (GameObject room in rooms)
        {
            room.SetActive(false);
        }
    }

    public void ShowRooms()
    {
        foreach (GameObject room in rooms)
        {
            room.SetActive(false);
        }

        for (int i = 0; i < rooms.Length; i++)
        {
            if (mapGen.newDungeon[0][i] != 0)
            {
                rooms[i].SetActive(true);
                roomIcons[i].sprite = icons[mapGen.newDungeon[0][i] - 1];
            }
        }
    }
}
