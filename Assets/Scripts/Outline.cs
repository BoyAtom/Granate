using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Outline : MonoBehaviour
{
    public Color EnterMouse;
    public GameObject inventoryObject;
    public GameObject textField;

    private GameObject textFld;
    private Inventory inventory;
    private MeshRenderer meshRenderer;
    private bool is_in = false;
    public bool pressed = false;

    void Start()
    {
        inventory = inventoryObject.GetComponent<Inventory>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && is_in)
        {
            inventory.AddItemToInventory(gameObject);
        }
    }

    private void CreateTextField()
    {
        Vector3 mousePos = Input.mousePosition;
        textFld = Instantiate(textField, mousePos, new Quaternion(0, 0, 0, 0));
        textFld.GetComponentInChildren<TextMeshProUGUI>().text = "Hello! I'm " + gameObject.name;
        textFld.transform.SetParent(GameObject.Find("Hud").transform);
    }

    private void OnMouseEnter()
    {
        is_in = !is_in;
        meshRenderer.materials[1].SetFloat("_ScaleFactor", 1.03f);
        meshRenderer.materials[1].SetColor("_OutlineColor", EnterMouse);
        CreateTextField();
    }

    private void OnMouseExit()
    {
        is_in = !is_in;
        meshRenderer.materials[1].SetFloat("_ScaleFactor", 1f);
        Destroy(textFld);
    }
}
