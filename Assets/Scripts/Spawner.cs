using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Variabes
    public GameObject prefab; //For prefab 
    public float spawnRate = 1f; //For spawn rate
    public float minHeight = -1f; //For pipes position up & down
    public float maxHeight = 1f; //For pipes position up & down


    //Methods
    private void OnEnable() //will be called automatically only when the script is enabled
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate); //calling the function repeatedly & cycling according to the rate
    }

    private void OnDisable() //will be called automatically only when the script is disabled
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        //To clone the existing prefab --> (prefab, intialPosition, rotation)
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity); //(object, wherever the spawner is positioned, no need for rotation)

        //Adjusting the position of the pipes
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }   
}
