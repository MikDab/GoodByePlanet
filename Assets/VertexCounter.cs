using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class VertexCounter : MonoBehaviour
{
    public int VertexAmount;

    void OnValidate()
    {
        MeshFilter[] renderers = this.GetComponentsInChildren<MeshFilter>();

        for (int i = 0; i < renderers.Length; i++)
        {
            VertexAmount += renderers[i].mesh.vertexCount;
        }
    }

}
