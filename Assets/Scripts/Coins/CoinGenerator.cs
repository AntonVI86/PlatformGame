using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform _coinPoints;
    [SerializeField] private float _timeToCreateCoin;

    private Transform[] _spawnPoints;
    private List<Coin> _coins = new List<Coin>();

    private void Awake()
    {
        _spawnPoints = new Transform[_coinPoints.childCount];

        for (int i = 0; i < _coinPoints.childCount; i++)
        {
            _spawnPoints[i] = _coinPoints.GetChild(i);
        }

        foreach (Transform point in _spawnPoints) 
        {
            Coin newCoin = Instantiate(_coinPrefab, point.transform);
            _coins.Add(newCoin);
        }
    }

    private void OnEnable()
    {
        foreach (Coin coin in _coins) 
        {
            coin.Collected += OnCollected;
        }
    }

    private void OnDisable()
    {
        foreach (Coin coin in _coins)
        {
            coin.Collected -= OnCollected;
        }
    }

    private void OnCollected(Coin coin) 
    {
        StartCoroutine(CreateCoin());
    }

    private IEnumerator CreateCoin()
    {
        var delay = new WaitForSeconds(_timeToCreateCoin);

        yield return delay;

        var result = _coins.FirstOrDefault(p => p.gameObject.activeSelf == false);

        result.gameObject.SetActive(true);

    }
}
