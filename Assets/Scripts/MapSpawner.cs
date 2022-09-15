using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject[] mapPrefab; 
    public int count = 9; 


    private float xPos = 0f; // 배치할 위치의 x 값

    private GameObject[] platforms; 
    private int currentIndex = 0; 

    private Vector3 poolPosition = new Vector3(0, 0, 0); // 초반에 생성된 발판들을 화면 밖에 숨겨둘 위치


    void Start() {
        // 변수들을 초기화하고 사용할 발판들을 미리 생성
    }

    void Update() {
        // 순서를 돌아가며 주기적으로 발판을 배치
    }
}
