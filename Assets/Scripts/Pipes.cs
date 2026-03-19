using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Pipes : MonoBehaviour
{
    //Variables 
    public float speed = 5f; //the speed of the moving pipes
    private float leftEdge; //left edge of the screen

    //Methods
    private void Start()
    {
      //calculating the left edge
      //converting screen space to world space coordinates by accessing the camera
      leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;

    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; //for moving the pipes to the left
        
        //Destroying the pipes if it reach all the way to the left edge of the screen 
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
