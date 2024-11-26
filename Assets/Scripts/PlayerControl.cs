using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public int xDirectionToMove;
    public int yDirectionToMove;
    public KeyCode upKeyToMove;
    public KeyCode downKeyToMove;
    public int yMinLimitToMove;
   public int yMaxLimitToMove;
    private float yPosition;
    public string playerType;
    public float ySpeedMovement; 
    // este valor es borrable 
    // Start is called before the first frame update

    void Start()
    {

    }
    private void Update()
    {
        yPosition = Mathf.Clamp(transform.position.y + ySpeedMovement * yDirectionToMove, yMinLimitToMove, yMaxLimitToMove);
        transform.position = new Vector2(transform.position.x, transform.position.y + yDirectionToMove);
    }
    // Update is called once per frame
    void FixedUpdate(){
        if(Input.GetKeyDown(upKeyToMove)){
            xDirectionToMove = 1;
        }else if(Input.GetKeyUp(downKeyToMove)){
            yDirectionToMove = -1;
        }
        else
        {
            yDirectionToMove = 0;
        }
        
        
    }
    void Clamp()
    {

    }
}


