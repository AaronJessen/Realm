using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ARExplorer
{
    public class Monster4 : MonsterBase
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        public override void Create(float speed)
        {
            base.Create(speed);
            base.MoveForward("Fly Forward", true);
            Debug.Log("Create 4");
        }

        public override void Move()
        {
            base.Move();
            
            // Debug.Log("Move 2");
        }

        //private void OnCollisionEnter(Collision other)
        //{
        //    MoveForward("Fly Forward", false);
        //}

        //private void OnCollisionExit(Collision collision)
        //{
        //    MoveForward("Fly Forward", true);
        //}

        //private void OnCollisionStay(Collision collision)
        //{
        //    if (collision.gameObject.GetComponent<CrystleCtrl>())
        //    {

        //        Attack("Melee Attack");
        //        //HitCrystalEvent?.Invoke(1f, other.gameObject);
        //    }
        //}

    }
}
