using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject[] mapPrefab; 
    public int count = 9; 

    public float yMin = -3.5f; 
    public float yMax = 1.5f; 
    private float xPos = 20f; // 배치할 위치의 x 값

    private GameObject[] platforms; 
    private int currentIndex = 0; 

    private Vector2 poolPosition = new Vector2(0, -20); // 초반에 생성된 발판들을 화면 밖에 숨겨둘 위치


    void Start() {
        // 변수들을 초기화하고 사용할 발판들을 미리 생성
    }

    void Update() {
        // 순서를 돌아가며 주기적으로 발판을 배치
    }
}
