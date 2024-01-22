using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    Rigidbody2D PlayerRigi;
    float angle = 0;
    int xSpeed = 3;
    int ySpeed = 30;
    GameManager gameManagerObject;
    public GameObject deathEffectObject;
    bool playerIsDead = false;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        PlayerRigi = GetComponent<Rigidbody2D>();
        gameManagerObject = GameObject.Find("Game Manager").GetComponent<GameManager>();

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
        if (playerIsDead == true) return;
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
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.tag == "Obstacle")
        {
            PlayerDeath();
        }
        else if(other.gameObject.tag == "Item")
        {
            
        }    
        
    }
    void PlayerDeath()
    {
        playerIsDead = true;
        Destroy(Instantiate(deathEffectObject, transform.position, Quaternion.identity), 0.5f);
        gameManagerObject.GameOver(); 
        StopPlayerMovement();  
    }
    void StopPlayerMovement()
    {
        PlayerRigi.velocity = new Vector2(0, 0);
        PlayerRigi.isKinematic = true;
    }
}
