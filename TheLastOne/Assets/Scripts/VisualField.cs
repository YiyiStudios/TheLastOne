using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class VisualField : MonoBehaviour
{
    public float viewAngle;
    public int viewRadius;

    public LayerMask maskTarget;
    public LayerMask maskObstacle;

    public List<Transform> listvisibletarget = new List<Transform>();

    public float meshResolution;
    Mesh viewmesh;
    public MeshFilter viewMeshFilter;


    private void Start()
    {
        viewmesh = new Mesh();
        viewmesh.name = "View Mesh";
        viewMeshFilter.mesh = viewmesh;

    }


    // Update is called once per frame
    private void Update()
    {
       Visible_Target();
        DrawMesh();
    }

    public struct InfoRC
    {
        public bool hit;
        public Vector2 point;//contendra el vector final con su distancia
        public float distance;
        public float angle;
        public InfoRC(bool _hit, Vector2 _point, float _distance, float _angle)
        {
            hit = _hit;
            point = _point;
            distance = _distance;
            angle = _angle;
        }
    }
    public Vector3 Vector_Direction_Line(float angle, bool globalangle)
    {
        if (!globalangle)
        {
            angle += transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad),Mathf.Sin(angle * Mathf.Deg2Rad),0);
    }

    void Visible_Target()
    {
        listvisibletarget.Clear();
        listvisibletarget.Capacity = 0;
        Collider2D[] coll2D = Physics2D.OverlapCircleAll(transform.position, viewRadius, maskTarget);
        for (int i = 0; i < coll2D.Length; i++)
        {
            Transform objetive = coll2D[i].transform;
            Vector2 vector_direction_objetive = (objetive.position - transform.position).normalized;
            if (Vector2.Angle(transform.right, vector_direction_objetive) < viewAngle / 2)
            {
                float distobjetive = Vector2.Distance(objetive.position, transform.position);
                if (Physics2D.Raycast(transform.position, vector_direction_objetive, distobjetive, maskTarget))
                {
                    listvisibletarget.Add(objetive);
                }
            }
        }
    }


    public InfoRC ConstraintsRC(float globalangle)
    {
        Vector3 endRC = Vector_Direction_Line(globalangle, true);
        RaycastHit2D rc = Physics2D.Raycast(transform.position, endRC, viewRadius, maskObstacle);
        if (rc)
        {
            return new InfoRC(true, rc.point, rc.distance, globalangle);

        }
        else
        {
            return new InfoRC(false, new Vector3(transform.position.x, transform.position.y, 0)+ endRC * viewRadius, viewRadius, globalangle);
        }
    }
    void DrawMesh()
    {
        int resolution = Mathf.RoundToInt(viewAngle * meshResolution);
        float angular_distance_rc = viewAngle / resolution;
        List<Vector2> listvertex = new List<Vector2>();

        for (int i = 0; i <= resolution; i++)
        {
            float angle = transform.eulerAngles.z - viewAngle / 2 + angular_distance_rc * i;
            InfoRC vertexinfo = ConstraintsRC(angle);
            listvertex.Add(vertexinfo.point);

        }
        int numVertex = listvertex.Count + 1;
        Vector3[] arrvertex = new Vector3[numVertex];
        int[] arrtriangles = new int[(numVertex - 2) * 3];

        arrvertex[0] = Vector3.zero;

        for (int i = 0; i < numVertex - 1; i++)
        {
            arrvertex[i + 1] = transform.InverseTransformPoint(listvertex[i]);
            if (i < numVertex - 2)
            {
                arrtriangles[i * 3] = 0;
                arrtriangles[i * 3 + 1] = i + 1;
                arrtriangles[i * 3 + 2] = i + 2;
            }
        }
        viewmesh.Clear();
        viewmesh.vertices = arrvertex;
        viewmesh.triangles = arrtriangles;
        viewmesh.triangles = viewmesh.triangles.Reverse().ToArray();
    }
}



