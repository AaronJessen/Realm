using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
	public class LevelCtrl : MonoBehaviour
	{
        public LevelBuilder levelBuilder;
        public BlackHoleCtrl blackHoleCtrlScr;
        public CrystleCtrl crystleCtrlScr;
        public List<List<MonsterBase>> monsterBaseList = new List<List<MonsterBase>>();
        //public List<MonsterBase> monsterBaseList = new List<MonsterBase>>();
        public List<List<int>> monsterCount = new List<List<int>>();



        // Start is called before the first frame update
        void Start()
        {
            LoadLevel(1);
          //  PopUpCtrl.Instance.ShowPopUpWindow("Good", true);
           // PopUpCtrl.Instance.ShowPopUpWindow("GOod", true);
        }

        // Update is called once per frame
        void Update()
   	 	{
   	  	   
   	 	}

        //int total
        public void LoadLevel(int level)
        {
            string path = "Levels/Level" + level.ToString();
            //transform.localPosition = new Vector3(0, 0, 0);
            levelBuilder = Resources.Load<LevelBuilder>(path);
            //Debug.Log("levelBuilder " + levelBuilder.EnemySpawnList[0].MonsterList[0].total);
            blackHoleCtrlScr.InitFactory(levelBuilder.EnemySpawnList.Count);
            monsterCount.Clear();
            monsterBaseList.Clear();
            Vector3 spawnOffest = new Vector3();
            for (int i = 0; i < levelBuilder.EnemySpawnList.Count; i++)
            {
                monsterBaseList.Add(new List<MonsterBase>());
                monsterCount.Add(new List<int>());
                for (int j = 0; j < levelBuilder.EnemySpawnList[i].MonsterList.Count; j++)
                {
                    monsterCount[i].Add(0);
                    for (int k = 0; k < levelBuilder.EnemySpawnList[i].MonsterList[j].total; k++)
                    {
                       // spawnOffest = new Vector3(Random.Range(-20, 20), 0, 0);
                        MonsterBase tem = Instantiate<MonsterBase>(levelBuilder.EnemySpawnList[i].MonsterList[j].Monster, blackHoleCtrlScr.BlackHoleList[i].transform);
                        //MonsterBase tem = Instantiate<MonsterBase>(levelBuilder.EnemySpawnList[i].MonsterList[j].Monster, transform);
                       // tem.transform.position += spawnOffest;
                        tem.Create(levelBuilder.EnemySpawnList[i].MonsterList[j].speed);

                        monsterBaseList[i].Add(tem);


                    }
                }
            }

            StartCoroutine(SpawRelease());
        }

        private IEnumerator SpawRelease()
        {
            Debug.Log("SpawRelease " + monsterBaseList.Count + " : " + monsterBaseList[0].Count);
            for (int i = 0; i < monsterBaseList.Count; i++)
            {
                for(int j = 0; j < monsterBaseList[i].Count; j++)
                {

                    monsterBaseList[i][j].ShowToggle(true);
                    yield return new WaitForSeconds(3);
                }
            }


        }
	}
}
