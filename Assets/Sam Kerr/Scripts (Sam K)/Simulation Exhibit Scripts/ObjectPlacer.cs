using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField] private GameObject placer;
    [SerializeField] private GameObject[] objects;
    [SerializeField] private Transform parent;
    [SerializeField] private int objectToBePlaced;
    [SerializeField] private float redX;
    [SerializeField] private float redZ;
    [SerializeField] private float redWidth;
    [SerializeField] private float blueX;
    [SerializeField] private float blueZ;
    [SerializeField] private float blueWidth;
    [SerializeField] private GameObject[] boundries;

    private float spawnX;
    private float spawnZ;
    private Vector3 spawnPosition;

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            PlaceObject(2);
        }
        /*
        for (int i = 0; i < 2; i++)
        {
            PlaceRed(0);
        }
        for (int i = 0; i < 2; i++)
        {
            PlaceBlue(1);
        }*/
    }

    private void PlaceObject(int toPlace)
    {
        spawnX = Random.Range(boundries[0].transform.position.x, boundries[1].transform.position.x);
        spawnZ = Random.Range(boundries[0].transform.position.z, boundries[1].transform.position.z);

        spawnPosition = new Vector3(spawnX, objects[toPlace].transform.position.y, spawnZ - 0.3f);

        Instantiate(objects[toPlace], spawnPosition, Quaternion.identity, parent);
    }

    private void PlaceRed(int toPlace)
    {
        spawnX = redX;
        spawnZ = redZ;

        spawnPosition = new Vector3(spawnX, objects[toPlace].transform.position.y + 0.1f, spawnZ);

        Instantiate(objects[toPlace], spawnPosition, Quaternion.identity, parent);
    }

    private void PlaceBlue(int toPlace)
    {
        spawnX = blueX;
        spawnZ = blueZ;

        spawnPosition = new Vector3(spawnX, objects[toPlace].transform.position.y, spawnZ);

        Instantiate(objects[toPlace], spawnPosition, Quaternion.identity, parent);
    }
}
