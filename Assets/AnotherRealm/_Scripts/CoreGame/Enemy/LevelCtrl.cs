using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ARExplorer
{
	public class LevelCtrl : MonoBehaviour
	{
        public LevelBuilder levelBuilder;
        public BlackHoleCtrl blackHoleCtrlScr;
        public CrystleCtrl crystleCtrlScr;
        public List<List<MonsterBase>> monsterBaseList = new List<List<MonsterBase>>();
        //public List<MonsterBase> monsterBaseList = new List<MonsterBase>>();
        //public List<List<int>> monsterCount = new List<List<int>>();

        int remainMonsterCount = 0;

        public delegate void LoadLevelEventHandle(LevelBuilder l);
        public static event LoadLevelEventHandle LoadLevelEvent;

        public delegate void WinEventHandle(int level);
        public static event WinEventHandle WinEvent;

        // Start is called before the first frame update
        void Start()
        {
            LoadLevel(MapPanelView.curLevel);
            MonsterBase.MonsterDieEvent += MonsterDie;
            Debug.Log("MapPanelView.curLevel " + MapPanelView.curLevel);
        }
        private void OnDisable()
        {
            Debug.Log("OnDisable ");
            MonsterBase.MonsterDieEvent -= MonsterDie;
        }
        //private void OnDestroy()
        //{
        //    Debug.Log("OnDestroy ");
        //    MonsterBase.MonsterDieEvent -= MonsterDie;
        //}

        // Update is called once per frame
        void MonsterDie()
   	 	{
            remainMonsterCount--;
            Debug.Log("MonsterDie " + remainMonsterCount);
            if(remainMonsterCount == 0)
            {
                Debug.Log("WinEvent ");
                WinEvent?.Invoke(MapPanelView.curLevel);
            }

       }

        //int total
        public void LoadLevel(int level)
        {
            string path = "Levels/Level" + level.ToString();
            levelBuilder = Resources.Load<LevelBuilder>(path);
            LoadLevelEvent.Invoke(levelBuilder);

            blackHoleCtrlScr.InitFactory(levelBuilder.EnemySpawnList.Count);
            //monsterCount.Clear();

            for(int i = 0; i < monsterBaseList.Count; i++)
            {
                for(int j = 0; j < monsterBaseList[i].Count; j++)
                {
                    DestroyImmediate(monsterBaseList[i][j].gameObject);
                    Debug.Log("Destroy " + i  + " " + j);
                    //monsterBaseList[i ][j].gameObject.SetActive(false);
                }
            }

            monsterBaseList.Clear();
            remainMonsterCount = 0;
            for (int i = 0; i < levelBuilder.EnemySpawnList.Count; i++)
            {
                monsterBaseList.Add(new List<MonsterBase>());
                //monsterCount.Add(new List<int>());
                for (int j = 0; j < levelBuilder.EnemySpawnList[i].MonsterList.Count; j++)
                {
                    //monsterCount[i].Add(0);
                    for (int k = 0; k < levelBuilder.EnemySpawnList[i].MonsterList[j].number; k++)
                    {
                       // spawnOffest = new Vector3(Random.Range(-20, 20), 0, 0);
                        MonsterBase tem = Instantiate<MonsterBase>(levelBuilder.EnemySpawnList[i].MonsterList[j].Monster, blackHoleCtrlScr.transform);
                        tem.Create(levelBuilder.EnemySpawnList[i].MonsterList[j].speed);
                        monsterBaseList[i].Add(tem);
                    }

                }
                remainMonsterCount += monsterBaseList[i].Count;
            }
            
            Debug.Log("remainMonsterCount " + remainMonsterCount);
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
