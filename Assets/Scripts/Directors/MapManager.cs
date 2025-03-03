using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.AI.Navigation;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public NavMeshSurface navMeshSurface;
    public GameObject horizontalWallPrefab;
    public GameObject verticalWallPrefab;
    
    private List<float> _xh = new () { -7f, 0f, 7f, 14f };
    private List<float> _zh = new () { -4f, 0f, 4f };
    private List<float> _xvInner = new () { -7f, 0f, 7f };
    private List<float> _xvOuther = new () { -7f, 7f };
    private List<float> _zvInner = new () { 0f, 4f };
    private List<float> _zvOuther = new () { -6f, 8f };
    private List<GameObject> _walls = new ();

    public void GenerateWall()
    {
        StartCoroutine(GenerateWallCoroutine());
    }
    
    private IEnumerator GenerateWallCoroutine()
    {
        DestroyWalls();
        GenerateHorizontalWalls();
        GenerateVerticalWalls(_xvInner, _zvInner);
        GenerateVerticalWalls(_xvOuther, _zvOuther);
    
        yield return new WaitForEndOfFrame();
    
        navMeshSurface.BuildNavMesh();
    }

    private void DestroyWalls()
    {
        navMeshSurface.RemoveData();
        if (!_walls.Any()) return;
        
        foreach (var wall in _walls)
        {
            Destroy(wall);
        }
        _walls.Clear();
    }

    private void GenerateVerticalWalls(List<float> xv, List<float> zv)
    {
            var x = xv[Random.Range(0, xv.Count)];
            var z = zv[Random.Range(0, zv.Count)];
            var wall = Instantiate(verticalWallPrefab, new Vector3(x, 0, z), Quaternion.identity);
            _walls.Add(wall);
    }

    private void GenerateHorizontalWalls()
    {
        for (int i = 0; i < _zh.Count; i++)
        {
            var tempXh = new List<float>();
            if (i == 0) tempXh.AddRange(_xh.GetRange(0, 3));
            else if (i == 1) tempXh.AddRange(_xh.GetRange(1, 2));
            else tempXh.AddRange(_xh.GetRange(1, 3));
            
            var count = Random.Range(1, 3);
            for (int j = 0; j < count; j++)
            {
                var index = Random.Range(0, tempXh.Count);
                var x = tempXh[index];
                var position = new Vector3(x, 0, _zh[i]);
                var wall = Instantiate(horizontalWallPrefab, position, Quaternion.identity);
                _walls.Add(wall);
                tempXh.RemoveAt(index);
            }
        }
    }
}
