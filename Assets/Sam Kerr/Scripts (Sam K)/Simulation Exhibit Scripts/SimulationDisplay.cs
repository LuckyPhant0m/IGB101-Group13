using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationDisplay : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] numbers;
    [SerializeField] private Sprite[] numberSprites;
    [SerializeField] private AudioSource audio;
    [SerializeField] private GameObject pickup;

    //Array of each resource for each civilisation
    public int[,] resources = new int[4, 5];
    //Number of different resources
    private int texts = 1;

    public void UpdateResource(int civilisation, int resource, int change)
    {
        resources[civilisation, resource] += change;
        numbers[civilisation * texts].sprite = numberSprites[resources[civilisation, resource] % 10];

        if (resources[0, 0] + resources[1, 0] > 5)
        {
            audio.Play();
            try
            {
                pickup.SetActive(true);
            }
            catch
            {
                Debug.Log("Pickup gone");
            }
        }
    }
}
