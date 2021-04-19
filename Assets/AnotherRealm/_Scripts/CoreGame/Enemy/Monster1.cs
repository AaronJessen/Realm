using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ARExplorer
{
    public class Monster1 : MonsterBase
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
           // Debug.Log("!! Update");
           // GetDamage("Take Damage");
            //if(base.m_)
            Move();
        }

        public override void Create(float speed)
        {
            base.Create(speed);
            base.MoveForward("Fly Forward", true);

            Debug.Log("Create 1 " + gameObject.name);
        }

        public override void Move()
        {

            base.Move();
            //transform.position = Vector3.Slerp(transform.position, CrystleCtrl.Instance.transform.position, 0.01f);
          //  Debug.Log("Move 1" + gameObject.name);
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
        //        MoveForward("Fly Forward", false);
        //        Attack("Melee Attack");
        //        //HitCrystalEvent?.Invoke(1f, other.gameObject);
        //    }
        //}
    }
}
