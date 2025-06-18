using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class NavMewshUpdater : MonoBehaviour
{
    [SerializeField] NavMeshSurface navmesh;
    private void Update()
    {
        navmesh.BuildNavMesh();
    }
}
