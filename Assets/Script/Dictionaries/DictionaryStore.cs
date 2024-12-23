using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Look at items in store
/// Purchase Items 
/// Remove and Add to cart. 
/// Return items from cart. 
/// 
/// We can have a list of items in our shopping list. 
/// If we lookup an item in our search field
/// we want to see if that particular item exists in our store. 
/// If we exceed 5 items we need to purchase a bag. 
/// If the item doesn't exist we will not display anything. 
/// 
/// When we do find an item
/// Ask the Quantity of that item. 
/// Display price of item
/// Price should change as we add more items 
/// Image of the item we want to purchase. 
/// 
/// </summary>
public class DictionaryStore : MonoBehaviour
{
    Dictionary<string, float> storeItems = new Dictionary<string, float>();
    // Start is called before the first frame update
    void Start()
    {
        storeItems.Clear();
        storeItems.Add("potatoes", 4.50f);
        storeItems.Add("Toothpaste", 2.50f);
        storeItems.Add("apples", 3.00f);

        foreach (KeyValuePair<string, float> item in storeItems)
        {
            Debug.Log("The store item is " + item.Key + item.Value);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        // Use a keyboard input to remove an item
        if (Input.GetKeyDown(KeyCode.Space))
        {
            storeItems.Remove("apples");
            // print out the resulting dictionary
            foreach (KeyValuePair<string, float> item in storeItems)
            {
                Debug.Log("The store item is " + item.Key + item.Value);
            }
        }
        

        if (Input.GetKeyUp(KeyCode.A))
        {
            storeItems.Add("Chips", 1.50f);
            foreach (KeyValuePair<string, float> item in storeItems)
            {
                Debug.Log("The store item is " + item.Key + item.Value);
            }
        }
    }
}
