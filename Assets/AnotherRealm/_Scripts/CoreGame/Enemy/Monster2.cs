using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ARExplorer
{
    public class Monster2 : MonsterBase
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
            Debug.Log("Create 2");
        }

        public override void Move()
        {
            base.Move();
            //transform.position = Vector3.Slerp(transform.position, CrystleCtrl.Instance.transform.position, 0.005f);
           // Debug.Log("Move 2");
        }

        //private void OnCollisionEnter(Collision other)
        //{
        //    MoveForward("Fly Forward", false);
        //    //if (other.gameObject.GetComponent<CrystleCtrl>())
        //    //{
        //    //    Attack("Melee Attack");
        //    //    //HitCrystalEvent?.Invoke(1f, other.gameObject);
        //    //}
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
