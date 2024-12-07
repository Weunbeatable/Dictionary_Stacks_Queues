using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueSolutionUsingQueues : MonoBehaviour
{
    // INstantiate an object
    // Have some buttons that will run some general commands. 
    // Start is called before the first frame update
    //Queues
    //FUnctions involving queues are
    // Enqueue: - adds an object to a queue
    // Dequeue: - removes an object from the queue
    // Clear : - clear the queue
    // contains: - checks if a queue has a value. 
    // Peek:  - checks to item at the top of the queue. 

    // Some objects that we want to generate. 
    [SerializeField] public GameObject object_to_add_to_queue;

    // we want to keep track of their positions, so lets use a variable to do that. 
    public Transform pos_of_Top_Stack_item;
    // Create a queue object, the type for this example is GameObject
    public Queue<GameObject> objectQueue = new Queue<GameObject>();
    void Start()
    {
        // grabbed the inital position. 
        pos_of_Top_Stack_item.position = new Vector3(4f, 0.5f, 0f);
    }


    public void Enqueue()
    {
        // FIFO -first in first out
        // Upper limit of this queue will be 5 items. 
        if (objectQueue.Count > 5)
        {
            Debug.Log("Reached the upper limit of the stack for this example");
            return; // do nothing if we try to add more than 5 objects. 
        }

        // We want to add an object to our queue. 

       objectQueue.Enqueue(Instantiate(object_to_add_to_queue, pos_of_Top_Stack_item.position, Quaternion.identity));

        string randomIDGenerator = "";
        // need to generate random value to select random char.
        System.Random newRand = new System.Random();



        for (int i = 0; i < 9; i++)
        {
            int randomValue = newRand.Next(0, 26); // generate a random number.
            char letter = Convert.ToChar(randomValue + 65);// generate rand number by converting numb to character
            randomIDGenerator = randomIDGenerator + letter; // concatonate string together.

        }
        object_to_add_to_queue.name = randomIDGenerator; // new ID for object. 
        Debug.Log("Newly added objects name is " + object_to_add_to_queue.name);

       /* object_to_add_to_queue.GetComponent<MeshRenderer>().material.color = new Color(
                UnityEngine.Random.Range(0f, 1f),
                UnityEngine.Random.Range(0f, 1f),
                UnityEngine.Random.Range(0f, 1f),
                1f);*/ // declare a object with a new color. leave alpha unchanged. 

        pos_of_Top_Stack_item.position = pos_of_Top_Stack_item.position + new Vector3(-1.5f, 0f, 0f); // we modify the next starting position 
        // each time we add an object to our queue. 

    }

    public void Dequeue()
    {
        if (objectQueue.Count <= 0  ) { return; } // if not empty don't do anything 
        else
        {
            Destroy(objectQueue.Dequeue());
            pos_of_Top_Stack_item.position = pos_of_Top_Stack_item.position + new Vector3(1.5f, 0f, 0f);
        }
    }

    public void ClearQueue()
    {
        if (objectQueue.Count <= 0) { return; }
        else
        {
            objectQueue.Clear();
            foreach (GameObject item in objectQueue)
            {
                Destroy(item);
            }

        }
    }
}
