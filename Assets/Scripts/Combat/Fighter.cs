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
                bool isInRange = Vector3.Distance(transform.position, target.position) < weaponRange;
                if (!isInRange) {
                    mover.MoveTo(target.position);
                } else {
                    mover.StopAgent();
                }
            }
        }
        public void Attack(CombatTarget target) {
            this.target = target.transform;
        }
    }
}