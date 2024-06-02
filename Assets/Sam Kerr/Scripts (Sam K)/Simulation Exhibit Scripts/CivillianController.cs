using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivillianController : MonoBehaviour
{
    //Intiallise variables
    [SerializeField] private GameObject citizen;
    [SerializeField] private float speed;
    [SerializeField] public int civilisation;
    [SerializeField] private GameObject[] boundries; 

    private int x;
    private int z;
    private float countdown;
    private float nextSwitch;
    private bool chopping;
    private Vector3[] dirs = new Vector3[8];
    private float height = -58;

    void Start()
    {
        //Set up variables
        x = Random.Range(-1, 2);
        z = Random.Range(-1, 2);
        countdown = 0;
        nextSwitch = Random.Range(1, 10) * 0.1f;
        chopping = false;

        //Set up movable directions
        dirs[0] = new Vector3(0, 1, 0);
        dirs[1] = new Vector3(1, 1, 0);
        dirs[2] = new Vector3(1, 0, 0);
        dirs[3] = new Vector3(1, -1, 0);
        dirs[4] = new Vector3(0, -1, 0);
        dirs[5] = new Vector3(-1, -1, 0);
        dirs[6] = new Vector3(-1, 0, 0);
        dirs[7] = new Vector3(-1, 1, 0);
    }

    void Update()
    {
        //Move every frame unless chopping
        if (!chopping)
        {
            Move(x, z);
        }

        //Update countdown
        countdown += Time.deltaTime;

        //If countdown has been reached, change direction and reset countdown
        if (countdown > nextSwitch)
        {
            x = Random.Range(-1, 2);
            z = Random.Range(-1, 2);
            countdown = 0;
            nextSwitch = Random.Range(1, 10) * 0.1f;
        }
    }

    private void Move(int dx, int dz)
    {
        //Update position
        citizen.transform.position = new Vector3(citizen.transform.position.x + dx * speed * Time.deltaTime, citizen.transform.position.y, citizen.transform.position.z + dz * speed * Time.deltaTime);

        //Check if citizen has gone beyond boarders
        if (citizen.transform.position.x < boundries[0].transform.position.x)
        {
            citizen.transform.position = new Vector3(boundries[0].transform.position.x, citizen.transform.position.y, citizen.transform.position.z);
        }
        if (citizen.transform.position.x > boundries[1].transform.position.x)
        {
            citizen.transform.position = new Vector3(boundries[1].transform.position.x, citizen.transform.position.y, citizen.transform.position.z);
        }
        if (citizen.transform.position.z < boundries[0].transform.position.z)
        {
            citizen.transform.position = new Vector3(citizen.transform.position.x, citizen.transform.position.y, boundries[0].transform.position.z);
        }
        if (citizen.transform.position.z > boundries[1].transform.position.z)
        {
            citizen.transform.position = new Vector3(citizen.transform.position.x, citizen.transform.position.y, boundries[1].transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider trigger)
    {
        //Start chopping if the citizen touches a tree
        if (trigger.tag == "Tree")
        {
            Debug.Log("tree");
            trigger.GetComponent<EnvironmentObject>().Harvest(citizen);
            chopping = true;
        }
    }

    public void Resume()
    {
        chopping = false;
    }
}
