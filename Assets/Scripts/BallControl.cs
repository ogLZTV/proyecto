using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public  class BallControl :  MonoBehaviour
{

public int xDirectionToMove;
public float xSpeedMovement;
public int yDirectionToMove;
public float ySpeedMovement;
public SpriteRenderer _spriteRenderer;
    public AudioSource _audioSource;
private GameManagerControl gamemanager;
private string currentType;
public bool true2;
    public Rigidbody2D _rigid;

// Start is called before the first frame update
    void Awake(){
        Initialize();
        GetComponents();
    }

    // Update is called once per frame
    void FixedUpdate(){
        //importante
        _rigid.velocity = new Vector2(xSpeedMovement * xDirectionToMove,
            ySpeedMovement * yDirectionToMove);
    }
    public void Initialize(){
        xDirectionToMove = GetinitialDirection();
        yDirectionToMove = GetinitialDirection();
    }
    void GetComponents(){
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        _rigid = GetComponent<Rigidbody2D>();
    }
    int GetinitialDirection(){
        int direction = Random.Range(0,200);
        if (direction == 50)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
            return direction;
                 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "VerticalLimit")
        {
            xSpeedMovement = xSpeedMovement * -1;
            _audioSource.Play();
        }
        else if (collision.gameObject.tag == "Player")
        {
            _audioSource.Play();
            xDirectionToMove = xDirectionToMove * -1;
            _spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            currentType = collision.gameObject.GetComponent<PlayerControl>().playerType;
        }
        else if (collision.gameObject.tag == "Destroyer")
        {
            transform.position = new Vector2(0, 0);
            Initialize();
            if (currentType == "Red")
            {
                gamemanager.UpdatePlayer1Score(1);
            }
            else if (currentType == "Blue")
            {
                gamemanager.UpdatePlayer2Score(1);
            }
        }
    }

}
   