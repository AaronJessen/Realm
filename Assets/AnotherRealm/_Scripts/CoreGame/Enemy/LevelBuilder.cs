﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
    
   [CreateAssetMenu(menuName = "Create/Test/LevelBuilder")]

	public class LevelBuilder : ScriptableObject
	{
        [SerializeField]
        public List<EnemySpawn> EnemySpawnList;


        // Start is called before the first frame update
        void Start()
		{
    	 	   
		}
	
    	// Update is called once per frame
		void Update()
   	 	{
   	  	   
   	 	}
	}

    [System.Serializable]
    public class EnemySpawn
    {
        //public BlackHoleCtrl blackHoleCtrlScr;
        public List<MonsterBaseSpawn> MonsterList;
    }

    [System.Serializable]
    public class MonsterBaseSpawn
    {
        public int total;
        public float speed;
        [SerializeField]
        public MonsterBase Monster;
    }
}
