using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject door;
    [SerializeField] GameObject collectiblePrefab;
    
    private GameObject _collectible;

    public void RestartLevel()
    {
        SetActiveDoor(false);
        RandomDoorPosition();
        GenerateCollectible();
    }

    public void GenerateCollectible()
    {
        if (_collectible is not null) Destroy(_collectible.gameObject);
        _collectible = Instantiate(collectiblePrefab);
        var posX = Random.Range(-13.0f, 13.0f);
        _collectible.transform.position = new Vector3(posX, 0.6f, 8.0f);
    }

    public void SetActiveDoor(bool value)
    {
        door.SetActive(value);
    }
    
    private void RandomDoorPosition()
    {
        var pos = door.transform.position;
        pos.x = Random.Range(-2.5f, 2.5f);
        door.transform.position = pos;
    }
}
