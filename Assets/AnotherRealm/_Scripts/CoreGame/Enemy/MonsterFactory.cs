using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
    public class MonsterFactory : MonoBehaviour
    {
        //[SerializeField]
        //private GameObject MonsterPref;

        public List<MonsterBase> MonsterTypePreList;
        [HideInInspector]
        public List<MonsterBase> MonsterList;

        public Transform ParTrans;
        public enum MonsterType
        {
            monster1 = 1,
            monster2 = 2,
            monster3 = 3
        };
        MonsterType monsterType;


        // Start is called before the first frame update
        void Start()
        {
            //InitFactory();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public IMonster CreateMonster(MonsterType mType)
        {
            switch (mType)
            {
                case MonsterType.monster1:
                    return new Monster1();
                case MonsterType.monster2:
                    return new Monster2();
                default:
                    return null;
            }
        }

        public void InitFactory()
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject g = Instantiate(MonsterTypePreList[i].gameObject);
                Transform t = g.transform;
                t.SetParent(ParTrans);
                t.localScale = Vector3.one;
                t.localPosition = Vector3.zero;
                MonsterList.Add(g.GetComponent<MonsterBase>());
            }
        }

    }
}
