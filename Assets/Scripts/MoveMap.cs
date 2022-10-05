using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{
    public GameObject[] mapPlaneObject;
    public GameObject player;

    private float directionRight;
    private float directionLeft;
    private float directionUp;
    private float directionDown;


    private void Start()
    {
        directionRight = 15;
        directionLeft = -15;
        directionUp = 15;
        directionDown = -15;
    }

    private void Update()
    {
        if (player.gameObject.transform.position.x >= directionRight)
        {
            RightMoveMap();
            directionRight += 30;
            directionLeft += 30;
        }
        if (player.gameObject.transform.position.x <= directionLeft)
        {
            LeftMoveMap();
            directionRight -= 30;
            directionLeft -= 30;
        }
        if (player.gameObject.transform.position.z <= directionDown)
        {
            DownMoveMap();
            directionUp -= 30;
            directionDown -= 30;
        }
        if (player.gameObject.transform.position.z >= directionUp)
        {
            UpMoveMap();
            directionUp += 30;
            directionDown += 30;
        }

    }

    void DownMoveMap()
    {
        Swap(mapPlaneObject, 0, 3, 6);
        Swap(mapPlaneObject, 1, 4, 7);
        Swap(mapPlaneObject, 2, 5, 8);
        mapPlaneObject[6].gameObject.transform.position += new Vector3(0, 0, -90);
        mapPlaneObject[7].gameObject.transform.position += new Vector3(0, 0, -90);
        mapPlaneObject[8].gameObject.transform.position += new Vector3(0, 0, -90);
    }

    void UpMoveMap()
    {
        Swap(mapPlaneObject, 6, 3, 0);
        Swap(mapPlaneObject, 7, 4, 1);
        Swap(mapPlaneObject, 8, 5, 2);
        mapPlaneObject[0].gameObject.transform.position += new Vector3(0, 0, 90);
        mapPlaneObject[1].gameObject.transform.position += new Vector3(0, 0, 90);
        mapPlaneObject[2].gameObject.transform.position += new Vector3(0, 0, 90);
    }

    void RightMoveMap()
    {
        Swap(mapPlaneObject, 0, 1, 2);
        Swap(mapPlaneObject, 3, 4, 5);
        Swap(mapPlaneObject, 6, 7, 8);
        mapPlaneObject[2].gameObject.transform.position += new Vector3(90, 0, 0);
        mapPlaneObject[5].gameObject.transform.position += new Vector3(90, 0, 0);
        mapPlaneObject[8].gameObject.transform.position += new Vector3(90, 0, 0);
    }

    void LeftMoveMap()
    {
        Swap(mapPlaneObject, 2, 1, 0);
        Swap(mapPlaneObject, 5, 4, 3);
        Swap(mapPlaneObject, 8, 7, 6);
        mapPlaneObject[0].gameObject.transform.position += new Vector3(-90, 0, 0);
        mapPlaneObject[3].gameObject.transform.position += new Vector3(-90, 0, 0);
        mapPlaneObject[6].gameObject.transform.position += new Vector3(-90, 0, 0);
    }

    void Swap(GameObject[] mapTile, int i, int j, int k)
    {
        GameObject test = mapTile[i];
        mapTile[i] = mapTile[j];
        mapTile[j] = mapTile[k];
        mapTile[k] = test;
    }
}
