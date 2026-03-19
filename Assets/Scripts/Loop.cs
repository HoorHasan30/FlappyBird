using UnityEngine;

public class Loop : MonoBehaviour
{
    //Variables
    private MeshRenderer meshRenderer; //meshRenderer reference to access the material for changes
    public float animationSpeed = 1f; //To customize the speed 
    
    //Methods
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        //Changing the ofset of the background
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0); //(x,y)
    } 
}
