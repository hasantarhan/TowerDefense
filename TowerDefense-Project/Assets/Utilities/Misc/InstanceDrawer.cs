using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
namespace Hasan.Misc
{
    public class InstancedDrawer : MonoBehaviour
    {
        [SerializeField] private Mesh mesh;
        [SerializeField] private Material material;
        [SerializeField] private LayerMask layerMask;

        private List<Transform> positions;
        private int actualCount;
        
        private NativeArray<Matrix4x4> nativeMatrices;

        private void Awake()
        {
            positions = new List<Transform>();
            Initialize();
        }

        private void Update()
        {
            Draw();
        }

        private void OnDestroy()
        {
            nativeMatrices.Dispose();
        }

        private void Initialize()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                positions.Add(transform.GetChild(i));
            }
            nativeMatrices = new NativeArray<Matrix4x4>(positions.Count, Allocator.Temp);
            for (int i = 0; i < positions.Count; i++)
            {
                var matrix = Matrix4x4.TRS(positions[i].transform.position, positions[i].transform.rotation,
                    positions[i].transform.localScale);
                nativeMatrices[i] = matrix;
            }

            for (int i = positions.Count - 1; i >= 0; i--)
            {
                Destroy(positions[i].gameObject);
            }
        }

        private void Draw()
        {
            Graphics.DrawMeshInstanced(mesh, 0, material, nativeMatrices.ToArray(), nativeMatrices.Length);
        }
    }
}