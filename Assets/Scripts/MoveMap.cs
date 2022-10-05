using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{
    public GameObject[] mapPlaneObject;
    public GameObject player;
    public GameObject[] chunkRangePlaneObject;

    private float posX;
    private float posZ;
    private float directionRight;
    private float directionLeft;
    private float directionUp;
    private float directionDown;


    private void Start()
    {
        posX = player.gameObject.transform.position.x; // 0
        posZ = player.gameObject.transform.position.z; // 0

        directionRight = 15;
        directionLeft = -15;
        directionUp = 15;
        directionDown = -15;
    }

    private void Update()
    {
        // if(posX - player.gameObject.transform.position.x <= -20) { // arr[3] 방향
        //     RightMoveMap();
        // }
        // if(posX - player.gameObject.transform.position.x >= 20) { // arr[5] 방향
        //     LeftMoveMap();
        // }
        // if(posZ - player.gameObject.transform.position.z <= -20) { // arr[7] 방향
        //     UpMoveMap();
        // }
        // if(posZ - player.gameObject.transform.position.z >= 20) { // arr[1] 방향
        //     
        // }
            if(player.gameObject.transform.position.x >= directionRight) {
                RightMoveMap();
                directionRight += 30;
                directionLeft += 30;
            }
            if(player.gameObject.transform.position.x <= directionLeft) {
                LeftMoveMap();
                directionRight -= 30;
                directionLeft -= 30;
            }
            if(player.gameObject.transform.position.z <= directionDown) {
                DownMoveMap();
                directionUp -= 30;
                directionDown -= 30;
            }
            if(player.gameObject.transform.position.z >= directionUp) {
                UpMoveMap();
                directionUp += 30;
                directionDown += 30;
            }        
        
    }

    // void OnTriggerExit(Collider col)
    // {
    //     if (col.tag == ("Chunk"))
    //     {
    //         UpMoveMap();
    //         MoveRangeObject();
    //     }
    //     if (col.tag == ("Chunk1"))
    //     {
    //         LeftMoveMap();
    //         MoveRangeObject();
    //     }
    //     if (col.tag == ("Chunk2"))
    //     {
    //         RightMoveMap();
    //         MoveRangeObject();
    //     }
    //     if (col.tag == ("Chunk3"))
    //     {
    //         DownMoveMap();
    //         MoveRangeObject();
    //     }
    // }

    void DownMoveMap()
    {
        Swap(mapPlaneObject, 0, 3, 6);
        Swap(mapPlaneObject, 1, 4, 7);
        Swap(mapPlaneObject, 2, 5, 8);
        mapPlaneObject[6].gameObject.transform.position += new Vector3(0, 0, -90);
        mapPlaneObject[7].gameObject.transform.position += new Vector3(0, 0, -90);
        mapPlaneObject[8].gameObject.transform.position += new Vector3(0, 0, -90);
        posZ = player.gameObject.transform.position.z;
    }

    void UpMoveMap()
    {
        Swap(mapPlaneObject, 6, 3, 0);
        Swap(mapPlaneObject, 7, 4, 1);
        Swap(mapPlaneObject, 8, 5, 2);
        mapPlaneObject[0].gameObject.transform.position += new Vector3(0, 0, 90);
        mapPlaneObject[1].gameObject.transform.position += new Vector3(0, 0, 90);
        mapPlaneObject[2].gameObject.transform.position += new Vector3(0, 0, 90);
        posZ = player.gameObject.transform.position.z;
    }

    void RightMoveMap()
    {
        Swap(mapPlaneObject, 0, 1, 2);
        Swap(mapPlaneObject, 3, 4, 5);
        Swap(mapPlaneObject, 6, 7, 8);
        mapPlaneObject[2].gameObject.transform.position += new Vector3(90, 0, 0);
        mapPlaneObject[5].gameObject.transform.position += new Vector3(90, 0, 0);
        mapPlaneObject[8].gameObject.transform.position += new Vector3(90, 0, 0);
        posX = player.gameObject.transform.position.x;
    }

    void LeftMoveMap()
    {
        Swap(mapPlaneObject, 2, 1, 0);
        Swap(mapPlaneObject, 5, 4, 3);
        Swap(mapPlaneObject, 8, 7, 6);
        mapPlaneObject[0].gameObject.transform.position += new Vector3(-90, 0, 0);
        mapPlaneObject[3].gameObject.transform.position += new Vector3(-90, 0, 0);
        mapPlaneObject[6].gameObject.transform.position += new Vector3(-90, 0, 0);
        posX = player.gameObject.transform.position.x;
    }

    void MoveRangeObject()
    {
        for (int i = 0; i < chunkRangePlaneObject.Length; i++)
        {
            chunkRangePlaneObject[i].transform.SetParent(mapPlaneObject[4].transform, false);
        }
    }

    // void DeleteRangeObject() {
    //     for(int i = 0; i < 4; i++) {
    //         rangeObject[i].gameObject.SetActive(false);
    //     }
    // }

    void Swap(GameObject[] mapTile, int i, int j, int k)
    {
        GameObject test = mapTile[i];
        mapTile[i] = mapTile[j];
        mapTile[j] = mapTile[k];
        mapTile[k] = test;
    }
}
