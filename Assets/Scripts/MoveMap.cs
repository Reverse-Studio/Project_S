using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{
    public GameObject[] mapPrefab; 
    public GameObject player;
    
    private float posX;
    private float posZ;

    void Start() {
        posX = player.gameObject.transform.position.x;
        posZ = player.gameObject.transform.position.z;
    }

    void Update() {
        if(posX - player.gameObject.transform.position.x <= -20) { // arr[3] 방향
            Swap(mapPrefab, 0, 1, 2);
            Swap(mapPrefab, 3, 4, 5);
            Swap(mapPrefab, 6, 7, 8);
            mapPrefab[2].gameObject.transform.position += new Vector3(60, 0, 0);
            mapPrefab[5].gameObject.transform.position += new Vector3(60, 0, 0);
            mapPrefab[8].gameObject.transform.position += new Vector3(60, 0, 0);
            posX = player.gameObject.transform.position.x;
        }
        if(posX - player.gameObject.transform.position.x >= 20) { // arr[5] 방향
            Swap(mapPrefab, 2, 1, 0);
            Swap(mapPrefab, 5, 4, 3);
            Swap(mapPrefab, 8, 7, 6);
            mapPrefab[0].gameObject.transform.position += new Vector3(-60, 0, 0);
            mapPrefab[3].gameObject.transform.position += new Vector3(-60, 0, 0);
            mapPrefab[6].gameObject.transform.position += new Vector3(-60, 0, 0);
            posX = player.gameObject.transform.position.x;
        }
        if(posZ - player.gameObject.transform.position.z <= -20) { // arr[7] 방향
            Swap(mapPrefab, 6, 3, 0);
            Swap(mapPrefab, 7, 4, 1);
            Swap(mapPrefab, 8, 5, 2);
            mapPrefab[0].gameObject.transform.position += new Vector3(0, 0, 60);
            mapPrefab[1].gameObject.transform.position += new Vector3(0, 0, 60);
            mapPrefab[2].gameObject.transform.position += new Vector3(0, 0, 60);
            posZ = player.gameObject.transform.position.z;
        }
        if(posZ - player.gameObject.transform.position.z >= 20) { // arr[1] 방향
            Swap(mapPrefab, 0, 3, 6);
            Swap(mapPrefab, 1, 4, 7);
            Swap(mapPrefab, 2, 5, 8);
            mapPrefab[6].gameObject.transform.position += new Vector3(0, 0, -60);
            mapPrefab[7].gameObject.transform.position += new Vector3(0, 0, -60);
            mapPrefab[8].gameObject.transform.position += new Vector3(0, 0, -60);
            posZ = player.gameObject.transform.position.z;
        }
    }

    

    void Swap(GameObject[] arr, int i, int j, int k) {
        GameObject tmp = arr[i];
        arr[i] = arr[j];
        arr[j] = arr[k];
        arr[k] = tmp;
    }
}
