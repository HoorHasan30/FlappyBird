using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //Variables
    private SpriteRenderer spriteRenderer; //to change the sprit that is currenty displayed for the bird animation
    public Sprite[] sprites; //array of sprites to cycle between 
    private int spriteIndex; //to keep track of the current index in the array
    private Vector3 direction; //direction of movemnet
    public float gravity = -9.8f; //how much gravity we are using
    public float strength = 5; //to manage how difficult the game is

    //Methods
    private void Awake() //called automatically by unity the very first frame when the object is intialize & it only get called once in the whole life cycle
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //will search for this component on teh same object that the script is running on 
    }

    private void Start() //will be called the very first frame that this object is enabled
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f); //calling the function repeatedly & cycling every 0.15s
    } 

    //called automatically every single frame + handling input
    private void Update()
    {
        //if space bar in the keyboard is clicked || 0 --> mouse left click is pressed
        if (Keyboard.current.spaceKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame) 
        {
            //the bird with flap up
            direction = Vector3.up * strength; 

        }
        
        //if there is to keyboard/mouse input --> apply gravity 
        direction.y += gravity * Time.deltaTime; //deltaTime --> makes the frame rate independent 

        //updating the position of the bird by accessing the transform of the object based on their direction
        transform.position += direction * Time.deltaTime; //used deltaTime twice beacuse gravity is an acceleration m/s^2 
    }

    //reset the bird place when re-enabled
    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void AnimateSprite()
    {
        spriteRenderer.sprite = sprites[spriteIndex]; //update the sprint

        spriteIndex++;

        //if it gets to the end of the array --> it resart from the begining again
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0 ; //to start over
        }
    }

    //Detecting collision between the bird and other objects
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager gm = FindFirstObjectByType<GameManager>(); //ref of the game manager

        if(other.gameObject.tag == "Obstacle")
        {
            gm.GameOver();
        }
        else if(other.gameObject.tag == "Scoring")
        {
             gm.IncreaseScore();
        }
    }
}

