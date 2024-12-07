using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackSolutionUsingStacks : MonoBehaviour
{
    // INstantiate an object
    // Have some buttons that will run some general commands. 
    // Start is called before the first frame update
    [SerializeField] public GameObject object_to_stack;
    public Transform pos_of_Top_Stack_item;
    public Stack<GameObject> objectQueue = new Stack<GameObject>();
    void Start()
    {

        pos_of_Top_Stack_item.position = new Vector3(0f, 5.5f, 0f);
    }


    public void Enqueue()
    {
        // FIFO -first in first out
        if (objectQueue.Count > 5)
        {
            Debug.Log("Reached the upper limit of the stack for this example");
            return;
        }

        // add a new object
        objectQueue.Push(Instantiate(object_to_stack, pos_of_Top_Stack_item.position, Quaternion.identity)); // add object to stack
        string randomIDGenerator = "";
        // need to generate random value to select random char.
        System.Random newRand = new System.Random();



        for (int i = 0; i < 9; i++)
        {
            int randomValue = newRand.Next(0, 26); // generate a random number.
            char letter = Convert.ToChar(randomValue + 65);// generate rand number by converting numb to character
            randomIDGenerator = randomIDGenerator + letter; // concatonate string together.

        }
        objectQueue.Peek().name = randomIDGenerator; // new ID for object. 
        Debug.Log("Newly added objects name is " + object_to_stack.name);
        objectQueue.Peek().GetComponent<MeshRenderer>().material.color = new Color(
                UnityEngine.Random.Range(0f, 1f),
                UnityEngine.Random.Range(0f, 1f),
                UnityEngine.Random.Range(0f, 1f),
                1f); // declare a object with a new color. leave alpha unchanged. 


        pos_of_Top_Stack_item.position = pos_of_Top_Stack_item.position + new Vector3(0f, -1f, 0f); // increase the y position for the next stacked item


    }

    public void PeekObject()
    {

        Debug.Log("The object you are looking at ID's " + objectQueue.Peek()); // name of object that is at top of stack. 
        Debug.Log("Size of stack is " + objectQueue.Count); // state size of the stack after peeking just for verification 
    }

    public void Dequeue()
    {
        objectQueue.Peek().SetActive(false);
        Destroy(objectQueue.Peek()); // remove from top pos position. 
        objectQueue.Pop();





        pos_of_Top_Stack_item.position = pos_of_Top_Stack_item.position + new Vector3(0f, +1f, 0f); // update position as well
        Debug.Log(objectQueue.Count); // logged new value along with visual 
    }

    public void ClearQueue()
    {
        foreach (GameObject objectInStack in objectQueue)
        {
            Destroy(objectInStack);

        }  // remove all objects from stack
        objectQueue.Clear();
        pos_of_Top_Stack_item.position = new Vector3(0f, 5.5f, 0f);// reset position 
        //Debug.Log(objectQueue.Count);
    }
}
