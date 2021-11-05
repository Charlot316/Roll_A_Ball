using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavTest : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;

    public bool WallSinkBottom = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (agent != null && agent.enabled == true)
        {
            agent.SetDestination(target.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")){
        }
    }
}
