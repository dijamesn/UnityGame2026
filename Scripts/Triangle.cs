using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class TetrahedronMesh : MonoBehaviour
{
    public float size = 1f;

    void Start()
    {
        Mesh mesh = new Mesh();
        mesh.name = "Tetrahedron";

        float h = size;

        Vector3 v0 = new Vector3(0, h, 0);          // top
        Vector3 v1 = new Vector3(-h, 0, -h);        // base
        Vector3 v2 = new Vector3(h, 0, -h);
        Vector3 v3 = new Vector3(0, 0, h);

        Vector3[] vertices = new Vector3[]
        {
            v0, v1, v2,
            v0, v2, v3,
            v0, v3, v1,
            v1, v3, v2
        };

        int[] triangles = new int[]
        {
            0, 1, 2,
            3, 4, 5,
            6, 7, 8,
            9, 10, 11
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        GetComponent<MeshFilter>().mesh = mesh;
    }
}