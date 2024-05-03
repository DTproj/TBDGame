using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.AI;

public class PlayerBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;

    public NavMeshAgent Agent { get { return agent; } }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (DialogueManager.Instance.IsDialogueOpen || InventoryManager.Instance.IsInventoryOpen)
        {
            return;
        }

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
        CamZoom();
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

    void CamZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && Camera.main.orthographicSize < 20)
        {
            Camera.main.orthographicSize++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f && Camera.main.orthographicSize > 1)
        {
            Camera.main.orthographicSize--;
        }
    }
}
