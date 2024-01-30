using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {

    public GameObject Player;

    public GameObject[] obstacles;

    private int obstCount;

    int playerDistance = -1;
    int obstcIndex = 0;
    int distanceBetweenObstc = 25;

    // Use this for initialization
    void Start () {

        obstCount = obstacles.Length;
        CreateObstacle();
	}
	
	// Update is called once per frame
	void Update () {

        int PlayerDistance = (int)(Player.transform.position.y / (distanceBetweenObstc / 2));

        if(playerDistance != PlayerDistance)
        {
            CreateObstacle();
            playerDistance = PlayerDistance;
        }
	}

    public void CreateObstacle()
    {
        int RandomObstCounter = Random.Range(0, obstCount);
        GameObject newObstacle = Instantiate(obstacles[RandomObstCounter], new Vector3(0, obstcIndex * distanceBetweenObstc), Quaternion.identity);
        newObstacle.transform.SetParent(transform);
        obstcIndex++;
    }
  
}
