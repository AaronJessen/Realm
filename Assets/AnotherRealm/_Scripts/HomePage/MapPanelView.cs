using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ARExplorer
{
    public class MapPanelView : MonoBehaviour
    {
        [SerializeField]
        private Button EnterButton;

        // Start is called before the first frame update
        void Awake()
        {
            EnterButton.onClick.AddListener(EnterARMode);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void EnterARMode()
        {
            GameManager.Instance.VuforiaToggle(true);
            LoadScene.JumpToScene(1);
        }


    }
}
