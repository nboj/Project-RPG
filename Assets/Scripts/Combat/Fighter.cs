using UnityEngine;
using RPG.Movement;

namespace RPG.Combat {
    public class Fighter : MonoBehaviour {
        [SerializeField] float weaponRange = 2f;
        private Transform target;
        private Mover mover;
        private void Start(){
            mover = GetComponent<Mover>();
        }
        private void Update() { 
            if (target != null) {
                if (!(Vector3.Distance(transform.position, target.position) < weaponRange)) {  
                        mover.MoveTo(target.position); 
                } else {
                    mover.StopAgent();
                }
            }
        }
        public void Attack(CombatTarget target) {
            this.target = target.transform;
        }
        public void Cancel() {
            target = null;
        }
    }
}