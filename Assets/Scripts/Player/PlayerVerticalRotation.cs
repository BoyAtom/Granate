using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVerticalRotation : MonoBehaviour
{
    public float Sensitivity
    {
        get { return sensitivity; }
        set { sensitivity = value; }
    }
    [Range(0.1f, 9f)][SerializeField] float sensitivity = 2f;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 180f)][SerializeField] float yRotationLimit = 180f;
    Vector2 rotation = Vector2.zero;
    const string yAxis = "Mouse Y";

    // Update is called once per frame
    void Update()
    {
        RotationLogic();
    }

    float CheckLimits(float angle)
    {
        if (angle > yRotationLimit/2) return yRotationLimit/2;
        else if (angle < -yRotationLimit/2) return -yRotationLimit/2;
        else return angle;
    }

    private void RotationLogic()
    {
        rotation.y -= Input.GetAxis(yAxis) * sensitivity;

        rotation.y = CheckLimits(rotation.y);
        transform.localRotation = Quaternion.Euler(rotation.y, 0, 0);
    }
}
