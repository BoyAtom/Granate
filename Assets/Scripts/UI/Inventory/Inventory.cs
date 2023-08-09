using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] gameItems;
    public GameObject[] inventory;
    public GameObject[ , ] inventorySlots;
    public List<GameObject> inventoryItems;
    public int currentTab = 0;

    public Animator taskAnimator;
    bool shown_task = false;
    // Start is called before the first frame update
    void Start()
    {
        inventorySlots = new GameObject[3, 3];
        InitInventorySlots();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ChangeTaskState();
        }
    }

    public void AddItemToInventory(GameObject item)
    {
        if (shown_task) {
            int num;
            Debug.Log(item.name);
            if (item.name == "ObjectA") num = 0;
            else if (item.name == "ObjectB") num = 1;
            else if (item.name == "ObjectC") num = 2;
            else num = -1;

            if (num != -1)
            {
                DrawInventoryObject(num);
            }
        }
    }

    public void ChangeInventoryTabs(int tab)
    {
        if (shown_task)
        {
            if (tab != -1 & tab != currentTab)
            {
                DestroyInventorySlots(currentTab);
                DrawInventoryObjects(tab);
                currentTab = tab;
            }
        }
    }

    private void InitInventorySlots()
    {
        for (int i = 0; i < inventorySlots.GetLength(0); i++) 
        {
            for (int j = 0; j < inventorySlots.GetLength(1); j++)
            {
                inventorySlots[i, j] = inventory[j];
            }
        }
    }

    private void DrawInventoryObject(int slot) 
    {
        if (inventorySlots.GetLength(0) != 0)
        {
            for (int i = 0; i < inventorySlots.GetLength(1); i++)
            {
                if (!inventorySlots[currentTab, i].GetComponent<IsFull>().is_full)
                {
                    inventorySlots[currentTab, i].GetComponent<IsFull>().is_full = true;
                    inventorySlots[currentTab, i].GetComponent<IsFull>().objectNumber = slot;
                    inventoryItems.Add(Instantiate(gameItems[slot], inventorySlots[currentTab, i].transform.position, inventorySlots[currentTab, i].transform.rotation));
                    inventoryItems[i].transform.SetParent(GameObject.FindGameObjectWithTag("Inventory").transform, true);
                    break;
                }
            }
        }
    }

    private void DestroyInventorySlots(int chosenTab)
    {
        if (inventorySlots.GetLength(1) != 0)
        {
            for (int i = 0; i < inventorySlots.GetLength(1); i++)
            {
                inventorySlots[chosenTab, i].GetComponent<IsFull>().is_full = false;
                inventorySlots[chosenTab, i].GetComponent<IsFull>().objectNumber = -1;
                Destroy(inventoryItems[i]);
            }
            inventoryItems.Clear();
        }
    }

    private void DrawInventoryObjects(int chosenTab)
    {
        if (inventorySlots.GetLength(1) != 0)
        {
            for (int i = 0; i < inventorySlots.GetLength(1); i++)
            {
                int slot = inventorySlots[chosenTab, i].GetComponent<IsFull>().objectNumber;
                if (slot != -1)
                {
                    inventorySlots[chosenTab, i].GetComponent<IsFull>().is_full = true;
                    GameObject inv = Instantiate(gameItems[slot], inventorySlots[chosenTab, i].transform.position, inventorySlots[chosenTab, i].transform.rotation);
                    inv.transform.SetParent(GameObject.FindGameObjectWithTag("Inventory").transform, true);
                }
            }
        }
    }

    public void ChangeTaskState()
    {
        if (shown_task) StartFlowOut();
        else StartFlowIn();
    }

    private void StartFlowIn()
    {
        Cursor.lockState = CursorLockMode.Confined;
        shown_task = !shown_task;
        taskAnimator.SetTrigger("StartFlowIn");
    }

    private void StartFlowOut()
    {
        Cursor.lockState = CursorLockMode.Locked;
        shown_task = !shown_task;
        taskAnimator.SetTrigger("StartFlowOut");
    }
}
