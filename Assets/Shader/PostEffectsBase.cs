using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    public class PostEffectsBase : MonoBehaviour
    {

        // Called when need to create the material used by this effect
        protected Material CheckShaderAndCreateMaterial(Shader shader, Material material)
        {
            Debug.Log("CheckShaderAndCreateMaterial");
            if (shader == null)
            {
                Debug.Log("CheckShaderAndCreateMaterial == null");
                return null;
            }

            if (shader.isSupported && material && material.shader == shader)
                return material;

            if (!shader.isSupported)
            {
                return null;
            }
            else
            {
                material = new Material(shader);
                material.hideFlags = HideFlags.DontSave;
                if (material)
                    return material;
                else
                    return null;
            }
        }





    }
}
