using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacks : MonoBehaviour
{
    // INstantiate an object
    // Have some buttons that will run some general commands. 
    // Start is called before the first frame update
    [SerializeField] public GameObject object_to_stack;
    public Transform pos_of_Top_Stack_item;
    public List<GameObject> objectStack = new List<GameObject>();
    void Start()
    {
        
        pos_of_Top_Stack_item.position = new Vector3(0f, 0.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void addObjectsToStack()
    {
        //LIFO last in first out
        if (objectStack.Count > 5)
        {
            Debug.Log("Reached the upper limit of the stack for this example");
            return;
        }
        
           // add a new object
            objectStack.Add(Instantiate(object_to_stack, pos_of_Top_Stack_item.position, Quaternion.identity)); // add object to stack
        string randomIDGenerator = "";
            // need to generate random value to select random char.
            System.Random newRand = new System.Random();

            

            for (int i = 0; i < 9; i++)
            {
                int randomValue = newRand.Next(0, 26); // generate a random number.
                char letter = Convert.ToChar(randomValue + 65);// generate rand number by converting numb to character
                randomIDGenerator = randomIDGenerator + letter; // concatonate string together.

            }
            objectStack[objectStack.Count - 1].name = randomIDGenerator; // new ID for object. 
            Debug.Log("Newly added objects name is " + object_to_stack.name);
        objectStack[objectStack.Count - 1].GetComponent<MeshRenderer>().material.color = new Color(
                UnityEngine.Random.Range(0f, 1f),
                UnityEngine.Random.Range(0f, 1f),
                UnityEngine.Random.Range(0f, 1f),
                1f); // declare a object with a new color. leave alpha unchanged. 
        

        pos_of_Top_Stack_item.position = pos_of_Top_Stack_item.position + new Vector3(0f, 1f, 0f); // increase the y position for the next stacked item
            
        
    }

    public void PeekObject()
    {
        int topPos = objectStack.Count-1;
        Debug.Log("The object you are looking at ID's " + objectStack[topPos].name); // name of object that is at top of stack. 
        Debug.Log("Size of stack is " + objectStack.Count); // state size of the stack after peeking just for verification 
    }

    public void PopObject()
    {
        int topPos = objectStack.Count-1;
        objectStack[topPos].SetActive(false);
        Destroy(objectStack[topPos]); // remove from top pos position. 
        objectStack.Remove(objectStack[topPos]);
        
        
        
        
           
        pos_of_Top_Stack_item.position = pos_of_Top_Stack_item.position + new Vector3(0f, -1f, 0f); // update position as well
        Debug.Log(objectStack.Count); // logged new value along with visual 
    }

    public void ClearObject()
    {
        foreach (GameObject objectInStack in objectStack)
        {
            Destroy(objectInStack);
            
        }  // remove all objects from stack
        objectStack.Clear();
        pos_of_Top_Stack_item.position = new Vector3(0f, 0.5f, 0f);// reset position 
        Debug.Log(objectStack.Count);
    }
}
