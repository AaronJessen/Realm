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
        private static Vuforia.VuforiaBehaviour vuforiaBehav;
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
            blitSetting = (Blit)forwardRendererData.rendererFeatures[1];
            //((BlitPass)forwardRendererData.rendererFeatures[1]).blitMaterial = testMar;
            //Debug.Log("forwardRendererData " + forwardRendererData.rendererFeatures[1].name);
            //foreach (var k in forwardRendererData.rendererFeatures)
            //{
            //    Debug.Log("forwardRendererData " + k.name);
            //    ///((BlitPass)k).blitMaterial = testMar;
            //}
            //tem.settings.blitMaterial = testMar;
            //forwardRendererData.SetDirty();
           // InvokeRepeating("ChangeMat", 1, 2);
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
