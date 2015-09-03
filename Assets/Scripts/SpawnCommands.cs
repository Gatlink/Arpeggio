using UnityEngine;

public class SpawnCommands : MonoBehaviour
{
    public GameObject[] CommandPrefabs;

    private Vector3 _spawnPosition;

    public void Start()
    {
        _spawnPosition = transform.GetChild(0).position;
        var newInstance = (GameObject) Instantiate(CommandPrefabs[0], _spawnPosition, Quaternion.identity);
        newInstance.transform.SetParent(transform);
    }
}