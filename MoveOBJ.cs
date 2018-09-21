using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.AI;
using UnityEngine;


public class MoveOBJ : MonoBehaviour
{

    public Transform target;
    private Comparer cm;

    public float forwardforce = 25;
    public float middleforce = 0.01f;

    public int idx = 0;
    public float maxIndex = 0;
    public List<GameObject> targetList;

    public class Comparer : IComparer<GameObject>
    {
        public int Compare(GameObject x, GameObject y)
        {
            return (x.name).CompareTo(y.name);
        }
    }

    void Start()
    {
        GoNextTarget();

        cm = new Comparer();
        targetList = new List<GameObject>();
        Transform roadlist = GameObject.Find("Road02").transform;

        for (int i = 0; i < roadlist.childCount; i++)
        {
            targetList.Add(roadlist.Find("Path" + (i + 1)).gameObject);
        }
        CmdNextTarget();

    }

    void GoNextTarget()
    {
        Vector3 lookDir = (target.position - transform.position).normalized;

        Quaternion from = transform.rotation;
        Quaternion to = Quaternion.LookRotation(lookDir);

        transform.rotation = Quaternion.Lerp(from, to, middleforce);

        GetComponent<Rigidbody>().velocity = transform.forward * forwardforce;
    }

    public void CmdNextTarget()
    {
        maxIndex++;
        if (maxIndex < 5f)
        {
            target = targetList[idx].transform;
            idx++;
        }
    }

}
