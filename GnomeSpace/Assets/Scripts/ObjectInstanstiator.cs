using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstanstiator : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject objectInstantiator;   //This game object assigned in Inspector.
    public GameObject[] objects;            //Array of individual objects to be instantiated.
    public GameObject player;               //Player GO.
    private GameObject instantiatedObject;  //Each instance of an individual objects instantiated.

    public Transform firePoint;

    public bool instantiatingAllowed;
    private bool objectInstantiated;         //Returns true immedietly after an individual object is instantiated.
    public bool playerCollision = false;    //Used to detect whether or not player object has collided with this instance of an object.

    [Header("Number of Objects Instantiated")]
    public int objectCount;                 //Current number of objects that have been instantiated.
    [Header("Max Objects Allowed")]
    public int maxObjectCount;              //Maximum number of objects that can be instantiated at once.

    [Header("Fire Speed")]
    public int fireSpeed;

    [Header("Random Distance Range From Player")]
    public float xDistanceFromPlayerMin;
    public float xDistanceFromPlayerMax;
    public float yDistanceFromPlayerMin;
    public float yDistanceFromPlayerMax;
    public float zDistanceFromPlayerMin;
    public float zDistanceFromPlayerMax;

   Vector3 randomPos;


    private void Awake()
    {
        instantiatedObject = null;
        objects[0].tag = "Asteroid";
        objects[1].tag = "Asteroid";
        objects[2].tag = "Asteroid";
        objects[3].tag = "Time";
        objects[4].tag = "Points";
        objects[5].tag = "HP";
        objects[6].tag = "Platform";
        objects[7].tag = "Platform";
        objects[8].tag = "Platform";
        objects[9].tag = "Platform";
        objects[10].tag = "Platform";
        objects[11].tag = "Platform";
        objects[12].tag = "Platform";

    }
    void Start()
    {
        objectInstantiated = false;
        instantiatingAllowed = true;
        
    }
    void Update()
    {
        if (instantiatingAllowed) { if (playerCollision == true) { InstantiateObject(); } }
        if (objectCount <= maxObjectCount) { instantiatingAllowed = true; }
        else if (objectCount > maxObjectCount) { instantiatingAllowed = false; DestroyImmediate(instantiatedObject); }

        randomPos.x = Random.Range(xDistanceFromPlayerMin, xDistanceFromPlayerMax);
        randomPos.y = Random.Range(yDistanceFromPlayerMin, yDistanceFromPlayerMax);
        randomPos.z = Random.Range(zDistanceFromPlayerMin, zDistanceFromPlayerMax);

        firePoint.position += randomPos;

        objectInstantiator = gameObject;
    }

    void InstantiateObject()
    {
        //gameObject.SetActive(true);
        Instantiate(instantiatedObject = objects[Random.Range(0,objects.Length)], firePoint.position, firePoint.rotation);
        instantiatedObject.transform.Translate(Vector3.forward * fireSpeed);
        if (instantiatedObject != null) { if (instantiatedObject.activeInHierarchy) { objectInstantiated = true; Debug.Log("Instantaited Object"); } }
        else { objectInstantiated = false; }
        objectCount += 1;
        instantiatedObject.SetActive(true);

        if (instantiatedObject != null){ instantiatedObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * fireSpeed); }
        
        
        playerCollision = false;
    }
    public void OnTriggerEnter(Collider collision) {if (collision.gameObject.tag == "Player")
        { playerCollision = true; }
    }
        
}