using UnityEngine;

namespace Hasan.Misc
{
    public class SetPivot : MonoBehaviour
    {
        public Vector3 pivot = Vector3.zero;
        private Vector3 lastPivot = Vector3.zero;
        private MeshFilter meshFilter;
        private Mesh mesh;

        public Vector3 rotationEuler = Vector3.zero;
        private Vector3 lastRotationEuler = Vector3.zero;


        private void Start()
        {
            Initialize();
            pivot = Vector3.zero;
        }

        private void Update()
        {
            if (mesh != null)
            {
                if (pivot != lastPivot)
                {
                    UpdatePivotPosition();
                    lastPivot = pivot;
                }
                if (rotationEuler != lastRotationEuler)
                {
                    UpdatePivotRotation();
                    lastRotationEuler = rotationEuler;
                }
            }
        }
        private void UpdatePivotRotation()
        {
            if (mesh == null) return;


            Quaternion currentRotationQuat = Quaternion.Euler(rotationEuler);
            Quaternion lastRotationQuat = Quaternion.Euler(lastRotationEuler);
            Quaternion rotationDelta = currentRotationQuat * Quaternion.Inverse(lastRotationQuat);
            Vector3 localPivotPos = mesh.bounds.center + Vector3.Scale(mesh.bounds.extents, pivot);
            Vector3 worldPivotPos = transform.TransformPoint(localPivotPos);

            rotationDelta.ToAngleAxis(out float angle, out Vector3 axis);
            if (!Mathf.Approximately(angle, 0f))
            {
                transform.RotateAround(worldPivotPos, axis, angle);
            }

            Vector3[] verts = mesh.vertices;
            Quaternion inverseDelta = Quaternion.Inverse(rotationDelta);

            for (int i = 0; i < verts.Length; i++)
            {

                Vector3 v = verts[i] - localPivotPos;
                v = inverseDelta * v;
                verts[i] = v + localPivotPos;
            }

            mesh.vertices = verts;
            mesh.RecalculateBounds();
        }

        private void Initialize()
        {
            meshFilter = GetComponent<MeshFilter>();
            if (meshFilter != null)
            {
                mesh = meshFilter.mesh;
                UpdatePivotVector();
            }
            else
            {
                Debug.LogWarning("Not find MeshFilter");
            }
        }

        private void UpdatePivotPosition()
        {
            if (mesh == null) return;
            Vector3 diff = Vector3.Scale(mesh.bounds.extents, lastPivot - pivot);
            transform.position -= Vector3.Scale(diff, transform.localScale);
            Vector3[] verts = mesh.vertices;
            for (int i = 0; i < verts.Length; i++)
            {
                verts[i] += diff;
            }
            mesh.vertices = verts;
            mesh.RecalculateBounds();
        }


        private void UpdatePivotVector()
        {
            if (mesh == null) return;

            Bounds bounds = mesh.bounds;
            Vector3 offset = -1 * bounds.center;
            pivot = lastPivot = new Vector3(
                offset.x / bounds.extents.x,
                offset.y / bounds.extents.y,
                offset.z / bounds.extents.z
            );
        }
    }
}