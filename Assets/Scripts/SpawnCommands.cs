using UnityEngine;

public class SpawnCommands : MonoBehaviour
{
    public GameObject[] CommandPrefabs;
    public float DeadZoneRatio = 0.8f;

    private Vector3 _spawnPosition;
    private Command _commands;
    private float _maxCommandY;

    public void Start()
    {
        _spawnPosition = transform.GetChild(0).position;
        var newInstance = (GameObject) Instantiate(CommandPrefabs[0], _spawnPosition, Quaternion.identity);
        newInstance.transform.SetParent(transform);
        _commands = newInstance.GetComponent<Command>();

        var rect = GetComponent<RectTransform>().rect;
        _maxCommandY = rect.height * DeadZoneRatio + rect.yMin;
    }

    public void Update()
    {
        if (_commands && _commands.GetComponent<RectTransform>().anchoredPosition.y >= _maxCommandY)
        {
            _commands.Kill();
            _commands = null;
        }
    }
}