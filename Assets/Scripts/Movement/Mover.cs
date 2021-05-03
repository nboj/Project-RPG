using UnityEngine;
using UnityEngine.AI; 

namespace RPG.Movement {
    public class Mover : MonoBehaviour {    
        private NavMeshAgent agent;
        private Animator animator;

        private void Start() {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }

        private void Update() { 
            UpdateAnimator();
        } 

        public void MoveTo(Vector3 destination)
        {
            agent.isStopped = false;
            agent.destination = destination;
        }

        private void UpdateAnimator() { 
            var localVelocity = transform.InverseTransformDirection(agent.velocity); 
            animator.SetFloat("forwardSpeed", localVelocity.z);
        }

        public void StopAgent() {
            agent.isStopped = true;
        }
    }
}
