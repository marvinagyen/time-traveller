using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameInventory : MonoBehaviour {
      public GameObject InventoryMenu;
      public GameObject CraftMenu;
      public bool InvIsOpen = false;
      public bool CraftIsOpen = false;
      public bool hasWatchKey = false;
      public bool hasPoison = false;
      public bool hasidCard = false;

      public AudioSource inventoryOpen;
      public AudioSource inventoryClose;
      
      //CRAFTING
      public GameObject buttonCraft1; // hanger+pliers=key
      public GameObject buttonCraft2; // bottle+flower=poison
      public AudioSource crafting_sound;

    //5 Inventory Items:
    public static bool item1bool = false;
      public static bool item2bool = false;
      public static bool item3bool = false;
      public static bool item4bool = false;
      public static bool item5bool = false;
      public static bool item6bool = false;
      public static bool item7bool = false;
      public static bool item8bool = false;

      public static int item1num = 0;
      public static int item2num = 0;
      public static int item3num = 0;
      public static int item4num = 0;
      public static int item5num = 0;
      public static int item6num = 0;
      public static int item7num = 0;
      public static int item8num = 0;
     //public static int coins = 0;

    [Header("Add item image objects here")]
      public GameObject item1image;
      public GameObject item2image;
      public GameObject item3image;
      public GameObject item4image;
      public GameObject item5image;
    public GameObject item6image;
    public GameObject item7image;
    public GameObject item8image;
    //public GameObject coinText;

    // Item number text variables. Comment out if each item is unique (1/2).
    [Header("Add item number Text objects here")]
      public Text item1Text;
      public Text item2Text;
      public Text item3Text;
      public Text item4Text;
      public Text item5Text;
    public Text item6Text;
    public Text item7Text;
    public Text item8Text;

    // Crafting buttons. Uncomment and add for each button:
    // public GameObject buttonCraft1; // weapon1 creation

    void Start(){
            InventoryMenu.SetActive(false);
            //CraftMenu.SetActive(false);
            InventoryDisplay();
            buttonCraft1.SetActive(false);
            buttonCraft2.SetActive(false);
    }

      void InventoryDisplay(){
   

            if (item1bool == true) {item1image.SetActive(true);} else {item1image.SetActive(false);}
            if (item2bool == true) {item2image.SetActive(true);} else {item2image.SetActive(false);}
            if (item3bool == true) {item3image.SetActive(true);} else {item3image.SetActive(false);}
            if (item4bool == true) {item4image.SetActive(true);} else {item4image.SetActive(false);}
            if (item5bool == true) {item5image.SetActive(true);} else {item5image.SetActive(false);}
        if (item6bool == true) { item6image.SetActive(true); } else { item6image.SetActive(false); }
        if (item7bool == true) { item7image.SetActive(true); } else { item7image.SetActive(false); }
        if (item8bool == true) { item8image.SetActive(true); } else { item8image.SetActive(false); }

        //Text coinTextB = coinText.GetComponent<Text>();
        //coinTextB.text = ("COINS: " + coins);

        // Item number updates. Comment out if each item is unique (2/2).
        Text item1TextB = item1Text.GetComponent<Text>();
            item1TextB.text = ("" + item1num);

            Text item2TextB = item2Text.GetComponent<Text>();
            item2TextB.text = ("" + item2num);

            Text item3TextB = item3Text.GetComponent<Text>();
            item3TextB.text = ("" + item3num);

            Text item4TextB = item4Text.GetComponent<Text>();
            item4TextB.text = ("" + item4num);

            Text item5TextB = item5Text.GetComponent<Text>();
            item5TextB.text = ("" + item5num);

        Text item6TextB = item6Text.GetComponent<Text>();
        item6TextB.text = ("" + item6num);

        Text item7TextB = item7Text.GetComponent<Text>();
        item7TextB.text = ("" + item7num);

        Text item8TextB = item8Text.GetComponent<Text>();
        item8TextB.text = ("" + item8num);

        //Crafting buttons:
        if ((item1num == 1) && (item2num == 1)){       // sample inventory items to be used
                  buttonCraft1.SetActive(true);
            }
            else { buttonCraft1.SetActive(false); }

        if ((item4num >= 1) && (item6num == 1))
        {       // sample inventory items to be used
            buttonCraft2.SetActive(true);
        }
        else { buttonCraft2.SetActive(false); }

        if (item5num > 0)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerMove_2>().hasSeed = true;
        }
    }

      public void InventoryAdd(string item){
            string foundItemName = item;
            if (foundItemName == "item1") {item1bool = true; item1num ++;}
            else if (foundItemName == "item2") {item2bool = true; item2num ++;}
            else if (foundItemName == "item3") {item3bool = true; item3num ++;}
            else if (foundItemName == "item4") {item4bool = true; item4num ++;}
            else if (foundItemName == "item5") {item5bool = true; item5num ++;}
        else if (foundItemName == "item6") { item6bool = true; item6num++; }
        else if (foundItemName == "item7") { item7bool = true; item7num++; }
        else if (foundItemName == "item8") { item8bool = true; item8num++; }
        else { Debug.Log("This item does not exist to be added"); }
            InventoryDisplay();

            if (!InvIsOpen){
                  OpenCloseInventory();
            }
      }

      public void InventoryRemove(string item, int num){
            string itemRemove = item;
            if (itemRemove == "item1") {
                  item1num -= num;
                  if (item1num <= 0) { item1bool =false; }
                  // Add any other intended effects: new item crafted, speed boost, slow time, etc
             }
            else if (itemRemove == "item2") {
                  item2num -= num;
                  if (item2num <= 0) { item2bool =false; }
                  // Add any other intended effects
             }
            else if (itemRemove == "item3") {
                  item3num -= num;
                  if (item3num <= 0) { item3bool =false; }
                    // Add any other intended effects
            }
            else if (itemRemove == "item4") {
                  item4num -= num;
                  if (item4num <= 0) { item4bool =false; }
                    // Add any other intended effects
            }
            else if (itemRemove == "item5") {
                  item5num -= num;
                  if (item5num <= 0) { item5bool =false; }
                    // Add any other intended effects
            }
        else if (itemRemove == "item6")
        {
            item6num -= num;
            if (item6num <= 0) { item6bool = false; }
            // Add any other intended effects
        }
        else if (itemRemove == "item7")
        {
            item7num -= num;
            if (item7num <= 0) { item7bool = false; }
            // Add any other intended effects
        }
        else if (itemRemove == "item8")
        {
            item8num -= num;
            if (item8num <= 0) { item8bool = false; }
            // Add any other intended effects
        }
        else { Debug.Log("This item does not exist to be removed"); }
        if (item3num == 1)
        {
            hasWatchKey = true;
        }

        if (item8num == 1)
        {
            hasidCard = true;
        }
        InventoryDisplay();
      }

      //public void CoinChange(int amount){
            //coins +=amount;
            //InventoryDisplay();
      //}

      // Open and Close the Inventory. Use this function on a button next to the inventory bar.
      public void OpenCloseInventory(){
            if (InvIsOpen) { 
                InventoryMenu.SetActive(false);
                inventoryClose.Play(0);

            } else { 
                InventoryMenu.SetActive(true);
                inventoryOpen.Play(0);
            }
            InvIsOpen = !InvIsOpen;
      }

      //Open and Close the Craftbook
      public void OpenCloseCraftBook(){
            if (CraftIsOpen){ CraftMenu.SetActive(false); }
            else { CraftMenu.SetActive(true); }
            CraftIsOpen = !CraftIsOpen;
      }


      public void CraftObject1(){
            //hanger/plier craft
            InventoryAdd("item3"); // sample inventory item to be added, needs supporting UI images
            InventoryRemove("item2", 1); // sample inventory items to be removed
            crafting_sound.Play(0);
            OpenCloseCraftBook();
      }

      // Craft Object 2 is for creating the lockpick.
      public void CraftObject2(){
            crafting_sound.Play(0);
            InventoryAdd("item7"); // sample inventory item to be added, needs supporting UI images
            InventoryRemove("item4", 1); InventoryRemove("item6", 1); // sample inventory items to be removed, item3 is the inventory
            string message = "Yikes!! That poison looks deadly!\nI wouldn't wish that on my worst enemies! Or maybe I would...";
            GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().makeMessagesAppear(message);
            hasPoison = true;
            OpenCloseCraftBook();
    }


      // Reset all static inventory values on game restart.
      public void ResetAllInventory(){
            item1bool = false;
            item2bool = false;
            item3bool = false;
            item4bool = false;
            item5bool = false;
        item6bool = false;
        item7bool = false;
        item8bool = false;

        item1num = 0; // object name
            item2num = 0; // object name
            item3num = 0; // object name
            item4num = 0; // object name
            item5num = 0; // object name
        item6num = 0; // object name
        item7num = 0; // object name
        item8num = 0; // object name
    }

}