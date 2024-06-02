using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentObject : MonoBehaviour
{
    //Intiallise variables
    [SerializeField] private SimulationDisplay simulationDisplay;
    [SerializeField] private GameObject tree;
    [SerializeField] private float durability;
    [SerializeField] private int environmentObjectType;
    [SerializeField] private int quantity;
    [SerializeField] private AudioSource audio;

    private float countdown;
    private bool isBeingChopped;
    private List<GameObject> chopees = new List<GameObject>();

    void Start()
    {
        //Set up variables
        countdown = 0;
        isBeingChopped = false;
    }

    void Update()
    {
        if (isBeingChopped)
        {
            countdown += Time.deltaTime;
        }

        if (countdown > durability)
        {
            simulationDisplay.UpdateResource(chopees[0].GetComponent<CivillianController>().civilisation, environmentObjectType, quantity);
            foreach (GameObject chopee in chopees)
            {
                chopee.GetComponent<CivillianController>().Resume();
            }
            Destroy(tree);

            audio.Play();
        }
    }

    public void Harvest(GameObject citizen)
    {
        chopees.Add(citizen);
        isBeingChopped = true;
    }
}
