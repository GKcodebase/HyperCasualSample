using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public int RotSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(RotSpeed != 0)
        {
            ObstacleRot();
        }
	}

    private void ObstacleRot()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * RotSpeed);
    }
}
