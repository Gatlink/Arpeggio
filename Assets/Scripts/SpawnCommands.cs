using UnityEngine;

public class SpawnCommands : MonoBehaviour
{
    public GameObject[] CommandPrefabs;
    public float DeadZoneRatio = 0.8f;

    private Vector3 _spawnPosition;
    private CommandButton _commandsButton;
    private float _maxCommandY;

    public void Start()
    {
        _spawnPosition = transform.GetChild(0).position;
        var newInstance = (GameObject) Instantiate(CommandPrefabs[0], _spawnPosition, Quaternion.identity);
        newInstance.transform.SetParent(transform);
        _commandsButton = newInstance.GetComponent<CommandButton>();

        var rect = GetComponent<RectTransform>().rect;
        _maxCommandY = rect.height * DeadZoneRatio + rect.yMin;
    }

    public void Update()
    {
        if (_commandsButton && _commandsButton.GetComponent<RectTransform>().anchoredPosition.y >= _maxCommandY)
        {
            _commandsButton.Kill();
            _commandsButton = null;
        }
    }
}