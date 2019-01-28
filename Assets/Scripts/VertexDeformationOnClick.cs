using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexDeformationOnClick : MonoBehaviour
{

    public Camera Main;

    void Update()
    {
        // Right click triggers the click
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit, 1000))
        //    {
        //        if (hit.collider != null)
        //        {
        //            Mesh mesh = GetComponent<MeshFilter>().mesh;
        //            float minDistanceSqr = Mathf.Infinity;
        //            Vector3 nearestVertex = Vector3.zero;
        //            // scan all vertices to find nearest
        //            foreach (Vector3 vertex in mesh.vertices)
        //            {
        //                Vector3 diff = hit.point - vertex;
        //                float distSqr = diff.sqrMagnitude;
        //                if (distSqr <= minDistanceSqr)
        //                {
        //                    minDistanceSqr = distSqr;
        //                    nearestVertex = vertex;
        //                }
        //            }
        //            // convert nearest vertex back to world space
        //            // return transform.TransformPoint(nearestVertex);

        //        }
        //    }
        //}
    }

    

}
