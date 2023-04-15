using PlayFab_Tutorial.Controllers;
using Unity.Netcode;
using UnityEngine;

public class CoinController : NetworkBehaviour
{
    [SerializeField] int _score = 5;
    [SerializeField] float _maxDelayTime = 10f;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Collider2D _collider2D;
    [SerializeField] float _currentTime;

    public void Collected(PlayerNetworkModelController playerModel)
    {
        playerModel.ScoreIncrease(_score);

        EnableDisableProcessClientRpc(false);
    }

    void Update()
    {
        if (_spriteRenderer.enabled || _collider2D.enabled) return;
        
        _currentTime += Time.deltaTime;

        if (_currentTime > _maxDelayTime)
        {
            EnableDisableProcessClientRpc(true);
        }
    }

    [ClientRpc]
    void EnableDisableProcessClientRpc(bool value)
    {
        _spriteRenderer.enabled = value;
        _collider2D.enabled = value;
        _currentTime = 0f;
    }
}
