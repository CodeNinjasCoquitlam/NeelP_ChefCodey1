using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    public GameObject cookedChicken;
    public GameObject friedEgg;

    public string cookedFood = "";
    
    // Start is called before the first frame update
    void Start()
    {
        cookedChicken.SetActive(false);
        friedEgg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CookChicken()
    {
        cookedChicken.SetActive(true);
        cookedFood = "cookedChicken";
    }

    public void FryEgg()
    {
        friedEgg.SetActive(true);
        cookedFood = "friedEgg";
    }

    public void CleanStove()
    {
        cookedChicken.SetActive(false);
        cookedFood = "";
    }
}
