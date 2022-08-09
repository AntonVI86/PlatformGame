using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public event UnityAction<Coin> Collected;

    private int _priceValue = 1;

    public int PriceValue => _priceValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Hero hero)) 
        {
            Collected?.Invoke(this);
        }
    }
}
