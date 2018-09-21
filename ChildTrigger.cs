using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTrigger : MonoBehaviour {

    public GameObject iscolled;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.transform.name);

        if (collision.tag ==  "Moving_OBJ")
        {
            if (iscolled == null)
            {
                iscolled = collision.gameObject;
                GetComponentInParent<RoadforTarget>().OnChiledTriggerEnter(collision);
            }
        }
    }
}
