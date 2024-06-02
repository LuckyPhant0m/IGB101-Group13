using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MapGeneration : MonoBehaviour
{
    //Editable variables
    [SerializeField] private GameObject[] rooms;
    [SerializeField] private int startingDungeonX;
    [SerializeField] private int startingDungeonY;
    [SerializeField] private int maxRooms;
    [SerializeField] private int length;
    [SerializeField] private MapPlacer mapPlacer;


    //Public variables
    public int dungeonX;
    public int dungeonY;

    //Regular varibales
    public int[][] newDungeon;
    private int currentRoom;
    private int nextRoomDirection;
    private int dungeonSize;
    private int[] choice;

    void Start()
    {
        //Set some variables to be used later
        dungeonX = startingDungeonX;
        dungeonY = startingDungeonY;
        dungeonSize = dungeonX * dungeonY;
        newDungeon = new int[10][];

        createMap(0);
        mapPlacer.ShowRooms();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            newDungeon = new int[10][];

            createMap(0);
            mapPlacer.ShowRooms();
        }
    }

    //Map Generation
    //The map coordinate system works a follows:
    // The map is stored as a list of values:
    //            [0, 0, 0, 0, 0, 0]
    // The map boundries are also stored as integers:
    //       dungeonX = 2, dungeonY = 3
    // Converting a list position 'n' to coordinates (x, y) is done as:
    //       (x, y) = (n % dungeonX, n / dungeonX) 
    // Converting coordinates (x, y) to a list position 'n' is done as:
    //            n = x + y * dungeonX
    //
    private void createMap(int floor)
    {
        newDungeon[floor] = new int[dungeonSize];                                                                            //Reset the dungeon to a list of all 0s the size of the boundries
        currentRoom = (int)(dungeonY / 2 * dungeonX + 1);                                                                 //Set the starting room to a position in the first column, half way up
        choice = new int[5];
        choice = new int[] { 2, 1, 1, 1, 1, 1, 1 };
        newDungeon[floor][currentRoom - 1] = 2;
        
        //First part of map generation: generate main path (start to finish)
        for (int i = 0; i < maxRooms; i++)                                                                            //Repeats until the dungeon reaches the final column (dungeonX) or 50 rooms have been placed
        {
            newDungeon[floor][currentRoom] = 1;

            //Place the end room if the dungeon is at it's limit
            if (currentRoom % dungeonX == length)
            {
                newDungeon[floor][currentRoom] = 3;
                break;
            }

            //Choose which of 3 directions the next room is in
            nextRoomDirection = Random.Range(0, 3);                                                                   //Chooses a random direction for next room: 0 = up, 1 = right, 2 = down
            if (nextRoomDirection == 0 && currentRoom < dungeonX * (dungeonY - 1))
                currentRoom += dungeonX;
            else if (nextRoomDirection == 1)
            {
                if (currentRoom % dungeonX == 3)
                {
                    newDungeon[floor][currentRoom] = 4;
                }
                if (currentRoom % dungeonX == 5)
                {
                    newDungeon[floor][currentRoom] = 5;
                }
                currentRoom += 1;
            }
            else if (nextRoomDirection == 2 && currentRoom >= dungeonX)
                currentRoom -= dungeonX;
        }
    }

    //            TO CLEAR UP POTENTIAL CONFUSION:
    //
    //    Internal map array:            Unity coordinates:
    //         ^ (+ve y)                   ^ (+ve x)
    //         |                           |
    //         |---> (+ve x)               |---> (+ve z)
}

