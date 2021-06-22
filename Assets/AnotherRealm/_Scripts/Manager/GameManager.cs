using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static Blit;


namespace ARExplorer
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
       // private static Vuforia.VuforiaBehaviour vuforiaBehav;
        public GameObject World;
        public List<Material> testMarList;
        public BlitPass blitPass;
        public ForwardRendererData forwardRendererData;
        Blit blitSetting;
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
            if (forwardRendererData != null && forwardRendererData.rendererFeatures != null && forwardRendererData.rendererFeatures.Count > 1)
            {
                blitSetting = (Blit)forwardRendererData.rendererFeatures[1];
            }
            else
            {
                blitSetting.settings.blitMaterial = null;
            }
        }

        public void ChangeMat(int index)
        {
            Debug.Log("ChangeMat");
            blitSetting.settings.blitMaterial = testMarList[index];
            forwardRendererData.SetDirty();
            StartCoroutine(ChangeMatIE());
        }

        IEnumerator ChangeMatIE()
        {
            yield return new WaitForSeconds(2f);
            blitSetting.settings.blitMaterial = null;
        }

        private void BlitPass(ScriptableRendererFeature k)
        {
            throw new NotImplementedException();
        }

        // Update is called once per frame
        void Update()
        {

        }

        //public void VuforiaToggle(bool toggle)
        //{
        //    if (!vuforiaBehav)
        //    {
        //        vuforiaBehav = FindObjectOfType<Vuforia.VuforiaBehaviour>();
        //    }
        //    if (vuforiaBehav)
        //    {
        //        vuforiaBehav.enabled = toggle;
        //    }
        //}



    }

    public enum ARProgress
    {
        PreScan = 1,
        Scaning = 2,
        ScanSuccess = 3

    }
}
