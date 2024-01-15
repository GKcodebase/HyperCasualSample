using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    Rigidbody2D PlayerRigi;
    float angle = 0;
    int xSpeed = 3;
    int ySpeed = 30;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        PlayerRigi = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        PlayerInput();
        PlayerMovement();
    }
    void PlayerMovement()
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Cos(angle) * 5;
        
        transform.position = pos;
        angle += Time.deltaTime * xSpeed;
    }
    void PlayerInput()
    {
        if (Input.GetMouseButton(0))
        {
            
            PlayerRigi.AddForce(new Vector2(0, ySpeed));
        }
        else
        {
            if(PlayerRigi.velocity.y > 0)
            {
                PlayerRigi.AddForce(new Vector2(0, -ySpeed));
            }
            else
            {
                PlayerRigi.velocity = new Vector2(PlayerRigi.velocity.x, 0);
            }
            
        }
    }
}
