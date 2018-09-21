using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadforTarget : MonoBehaviour {

    public void OnChiledTriggerEnter(Collider other)
    {
        if (other.tag == "Moving_OBJ")
        {
            other.transform.GetComponent<MoveOBJ>().CmdNextTarget();
        }
    }
}
