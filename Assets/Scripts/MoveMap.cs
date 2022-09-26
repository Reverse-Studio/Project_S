using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{
    public GameObject[] mapPrefab; 
    public GameObject player;
    public GameObject rangeObjectPrefab;
    public GameObject[] rangeObject;
    public int count = 4;
    
    private float posX;
    private float posZ;
    

    private void Start() {
        posX = player.gameObject.transform.position.x; // 0
        posZ = player.gameObject.transform.position.z; // 0
    }

    private void Update() {
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
        //     DownMoveMap();
        // }
        // for(int i = 0; i < count; i++) {
        //     rangeObject[i] = Instantiate(rangeObject[i], this.transform.position, Quaternion.identity);
        //     rangeObject[i].transform.parent = mapPrefab[4].transform;
        // }
    }

    void OnTriggerExit(Collider col) {
        if(col.tag == ("Chunk")) {
            UpMoveMap();
            MoveRangeObject();
        }
        if(col.tag == ("Chunk1")) {
            LeftMoveMap();
            MoveRangeObject();
        }
        if(col.tag == ("Chunk2")) {
            RightMoveMap();
            MoveRangeObject();
        }
        if(col.tag == ("Chunk3")) {
            DownMoveMap();
            MoveRangeObject();
        }
    }

    void DownMoveMap() {
        Swap(mapPrefab, 0, 3, 6);
        Swap(mapPrefab, 1, 4, 7);
        Swap(mapPrefab, 2, 5, 8);
        mapPrefab[6].gameObject.transform.position += new Vector3(0, 0, -90);
        mapPrefab[7].gameObject.transform.position += new Vector3(0, 0, -90);
        mapPrefab[8].gameObject.transform.position += new Vector3(0, 0, -90);
        posZ = player.gameObject.transform.position.z;
    }

    void UpMoveMap() {
        Swap(mapPrefab, 6, 3, 0);
        Swap(mapPrefab, 7, 4, 1);
        Swap(mapPrefab, 8, 5, 2);
        mapPrefab[0].gameObject.transform.position += new Vector3(0, 0, 90);
        mapPrefab[1].gameObject.transform.position += new Vector3(0, 0, 90);
        mapPrefab[2].gameObject.transform.position += new Vector3(0, 0, 90);
        posZ = player.gameObject.transform.position.z;
    }

    void RightMoveMap() {
        Swap(mapPrefab, 0, 1, 2);
        Swap(mapPrefab, 3, 4, 5);
        Swap(mapPrefab, 6, 7, 8);
        mapPrefab[2].gameObject.transform.position += new Vector3(90, 0, 0);
        mapPrefab[5].gameObject.transform.position += new Vector3(90, 0, 0);
        mapPrefab[8].gameObject.transform.position += new Vector3(90, 0, 0);
        posX = player.gameObject.transform.position.x;
    }

    void LeftMoveMap() {
        Swap(mapPrefab, 2, 1, 0);
        Swap(mapPrefab, 5, 4, 3);
        Swap(mapPrefab, 8, 7, 6);
        mapPrefab[0].gameObject.transform.position += new Vector3(-90, 0, 0);
        mapPrefab[3].gameObject.transform.position += new Vector3(-90, 0, 0);
        mapPrefab[6].gameObject.transform.position += new Vector3(-90, 0, 0);
        posX = player.gameObject.transform.position.x;
    }

    void MoveRangeObject() {
        for(int i = 0; i < 4; i++) {
            rangeObject[i].transform.SetParent(mapPrefab[4].transform, false);
        }
    }

    // void DeleteRangeObject() {
    //     for(int i = 0; i < 4; i++) {
    //         rangeObject[i].gameObject.SetActive(false);
    //     }
    // }

    void Swap(GameObject[] arr, int i, int j, int k) {
        GameObject tmp = arr[i];
        arr[i] = arr[j];
        arr[j] = arr[k];
        arr[k] = tmp;
    }
}
