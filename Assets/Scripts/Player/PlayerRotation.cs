using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float Sensitivity
    {
        get { return sensitivity; }
        set { sensitivity = value; }
    }
    [Range(0.1f, 9f)][SerializeField] float sensitivity = 2f;

    Vector2 rotation = Vector2.zero;
    const string xAxis = "Mouse X";
    const string yAxis = "Mouse Y";

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }

    void Update()
    {
        RotationLogic();
    }

    private void RotationLogic()
    {
        rotation.x += Input.GetAxis(xAxis) * sensitivity;

        transform.localRotation = Quaternion.Euler(0, rotation.x, 0);
    }
}
