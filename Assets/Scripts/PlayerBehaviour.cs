using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(ray, out hitInfo))
            {
               CheckRaycastHit(hitInfo);
            }
        }
    }

    void CheckRaycastHit(RaycastHit hit)
    {
        if(hit.collider.tag == "Door")
        {

        }
        else
        {
            agent.SetDestination(hit.point);
        }
    }
}
