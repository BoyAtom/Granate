using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHide : MonoBehaviour
{
    public GameObject Player;
    public float REACTION_DISTANCE = 20f;
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CloseEnought(Player.transform);
    }

    void CloseEnought(Transform obj)
    {
        float dist = CountDistance(obj);
        Debug.Log(dist);
        if (dist > REACTION_DISTANCE) animator.SetBool("is_far", true);
        else animator.SetBool("is_far", false);
    }

    float CountDistance(Transform obj)
    {
        return Vector3.Distance(obj.position, transform.position);
    }
}
