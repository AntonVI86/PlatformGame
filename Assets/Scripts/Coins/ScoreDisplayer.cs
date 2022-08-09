using UnityEngine;
using TMPro;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _hero.CoinCollected += OnCoinCollected;
    }

    private void OnDisable()
    {
        _hero.CoinCollected -= OnCoinCollected;
    }

    public void OnCoinCollected(int coinCount) 
    {
        _score.text = coinCount.ToString();
    }
}
