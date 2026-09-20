using System.Collections.Generic;
using UnityEngine;

public class Vectors : MonoBehaviour
{
    [SerializeField] private Transform _player, _enemy;
    [SerializeField] private Vector3 _v1, _v2, _v3;
    [SerializeField] private float _k;
    [SerializeField] private Dictionary<int, Vector3> _matrix = new Dictionary<int, Vector3>();
    //public float k;
    public static float s_k = 0f;
    public const float k = 3.4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _v1 = _player.position;
        _v2 = _enemy.position;
        _v3 = new Vector3(2, 4, -8);
        
        _k = 1.5f;
        //k = 1.5f;
        s_k += 0.1f;

        print($"OInitial Values => _v1: {_v1}, _v2: {_v2}, _v3: {_v3}, _k: {_k}, k: {k}, s_k: {s_k}");

        _matrix.Add(0, _player.position);
        _matrix.Add(1, _enemy.position);

        float dot = Vector3.Dot(_v1, _v1 = _v2);
        print($"Dot Product of Player to Enemy: {dot}");

        var v1_times_v2 = new Vector3(_v1.x * _v2.x, _v1.y * _v2.y, _v1.z * _v2.z);
        var v1_times_k = _v1 * _k;
        var v1_plus_v2 = _v1 + _v2;
        var v1_minus_v2 = _v1 - _v2;

        print($"Vector Operations => v1 * v2: {v1_times_v2}, v1 * k: {v1_times_k}, v1 + v2: {v1_plus_v2}, v1 - v2: {v1_minus_v2}");
    }

    // Update is called once per frame
    private void OnDisable()
    {
        s_k = 0f;
    }
}
