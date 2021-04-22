using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour {    
    private NavMeshAgent agent;
    private Animator animator;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update() { 
        if (Input.GetMouseButton(0)) {
            MoveToCursor();
        } 
        UpdateAnimator();
    } 

    private void MoveToCursor() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit) { 
            agent.destination = hit.point;
        }
    }

    private void UpdateAnimator() { 
        var localVelocity = transform.InverseTransformDirection(agent.velocity); 
        animator.SetFloat("forwardSpeed", localVelocity.z);
    }
}
