using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
namespace ARExplorer
{
    public class ARPanelView : MonoBehaviour
    {
        [SerializeField]
        private Button ExitButton;

        // Start is called before the first frame update
        void Awake()
        {
            ExitButton.onClick.AddListener(ExitToHome);

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ExitToHome()
        {
            GameManager.Instance.VuforiaToggle(false);
            LoadScene.JumpToScene(0);
        }
    }
}
