using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Stove stove;
    
    public string triggerName = "";

    public GameObject chickenPrefab;
    public GameObject eggPrefab;
    public GameObject friedEggPrefab;

    public GameObject heldItem;
    public string heldItemName;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (triggerName == "Chicken")
            {
                PickUpItem(chickenPrefab, "chickenPiece");
            }

            if(triggerName == "Egg")
            {
                PickUpItem(eggPrefab, "egg");
            }
            
            if (triggerName == "Stove")
            {
                print("I'm at the Stove");
                if (heldItemName == "chickenPiece")
                {
                    print("Ready to cook!");
                    stove.CookChicken();
                    PlaceHeldItem();
                }
                else if (heldItemName == "egg") 
                { 
                    stove.FryEgg();
                    PlaceHeldItem();

                }
                else
                {
                   if(stove.cookedFood == "cookedChicken")
                   {
                        PickUpItem(chickenPrefab, "cookedChicken");
                        stove.CleanStove();
                   }
                   if(stove.cookedFood == "friedEgg")
                   {
                        PickUpItem(friedEggPrefab, "friedEgg");
                        Destroy(friedEggPrefab);
                        stove.CleanStove();
                    }
                }
            }

            if(triggerName == "Receivers")
            {
              if(heldItemName == "cookedChicken")
              {
                 PlaceHeldItem();
                 GameObject.Find("Receivers/Chicken with an egg/cookedChicken").SetActive(true);
              }
              if (heldItemName == "cookedChicken")
                {
                    GameObject.Find("Receivers/Chicken with an egg/friedEgg").SetActive(true);
                }
            }


        }
        
        


            
             
            
            
        
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerName = other.name;
    }

    private void OnTriggerExit(Collider other)
    {
        triggerName = "";
    }

    private void PlaceHeldItem()
    {
        Destroy(heldItem);
        heldItemName = "";
    }

    private void PickUpItem(GameObject itemPrefab, string itemName)
    {
        heldItem = Instantiate(itemPrefab, transform, false);
        heldItem.transform.localPosition = new Vector3(0, 2, 2);
        heldItemName = itemName;
    }
}
