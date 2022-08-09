using UnityEngine;
using UnityEngine.Events;

public class Hero : MonoBehaviour
{ 
    public event UnityAction<int> CoinCollected;

    private int _coinCount;  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin)) 
        {
            _coinCount += coin.PriceValue;
            CoinCollected?.Invoke(_coinCount);
            coin.gameObject.SetActive(false);
        }
    }
}
