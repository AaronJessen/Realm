using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ARExplorer
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        private static Vuforia.VuforiaBehaviour vuforiaBehav;
        public GameObject World;

        private ARProgress arProgress;
        public ARProgress ARProgressStatus
        {
            get
            {
                return arProgress;
            }
            set
            {
                arProgress = value;
                //UpdateARProgressEvent?.Invoke(arProgress);
            }
        }


        // Start is called before the first frame update
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<GameManager>();
                }
                return instance;
            }

        }

        void Start()
        {
            ARProgressStatus = ARProgress.Scaning;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void VuforiaToggle(bool toggle)
        {
            if (!vuforiaBehav)
            {
                vuforiaBehav = FindObjectOfType<Vuforia.VuforiaBehaviour>();
            }
            if (vuforiaBehav)
            {
                vuforiaBehav.enabled = toggle;
            }
        }



    }

    public enum ARProgress
    {
        PreScan = 1,
        Scaning = 2,
        ScanSuccess = 3

    }
}
