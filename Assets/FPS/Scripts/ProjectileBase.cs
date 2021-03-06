using UnityEngine;
using UnityEngine.Events;

namespace ARExplorer
{
    public class ProjectileBase : MonoBehaviour
    {
        public GameObject owner { get; private set; }
        public Vector3 initialPosition { get; private set; }
        public Vector3 initialDirection { get; private set; }
        public Vector3 inheritedMuzzleVelocity { get; private set; }
        public float initialCharge { get; private set; }

        public UnityAction onShoot;
        //WeaponController controller
        public void Shoot()
        {
            //owner = controller.owner;
            initialPosition = transform.position;
            initialDirection = transform.forward;
            //inheritedMuzzleVelocity = controller.muzzleWorldVelocity;
            //initialCharge = controller.currentCharge;

            if (onShoot != null)
            {
                onShoot.Invoke();
            }
        }
    }
}
