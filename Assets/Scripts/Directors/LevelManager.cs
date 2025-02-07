using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject door;

    public void RestartLevel()
    {
        SetActiveDoor(false);
        RandomDoorPosition();
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
