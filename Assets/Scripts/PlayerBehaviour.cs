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

        CamRotation();
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

    void CamRotation()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Camera.main.transform.RotateAround(agent.transform.position, Vector3.up, 90);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Camera.main.transform.RotateAround(agent.transform.position, Vector3.up, -90);
        }
    }
}
