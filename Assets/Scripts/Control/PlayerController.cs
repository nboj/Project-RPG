using UnityEngine;  
using RPG.Movement; 
using RPG.Combat;

namespace RPG.Control {
    public class PlayerController : MonoBehaviour {
        private Mover mover;
        private Fighter fighter;
        private void Start() {
            mover = GetComponent<Mover>();
            fighter = GetComponent<Fighter>();
        }
        private void Update()
        {
            if (InterractWithCombat()) { 
            } else if (InterractWithMovement()) {  
            } 
        }

        private bool InterractWithCombat() { 
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits) { 
                var target = hit.transform.GetComponent<CombatTarget>(); 
                if (target != null) {
                    if (Input.GetMouseButtonDown(0)) {
                        fighter.Attack(target);
                    }
                    return true;
                }
            }
            return false;
        }

        private bool InterractWithMovement() { 
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit) {
                if (Input.GetMouseButton(0)) {
                    fighter.Cancel();
                    mover.MoveTo(hit.point);
                }  
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}