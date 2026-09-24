using UnityEngine;

public class EventTimer : MonoBehaviour
{
    [SerializeField] private VoidEventChannel _channelPos;
    [SerializeField] private Transform[] _harvestLocations;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5f)
        {
            _channelPos.RaiseEvent(); //_harvestLocations[Random.Range(0, _harvestLocations.Length)].position
            timer = 0f;
        }
    }
}
