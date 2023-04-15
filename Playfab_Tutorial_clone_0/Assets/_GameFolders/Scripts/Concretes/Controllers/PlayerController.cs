using PlayFab_Tutorial.Controllers;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] PlayerNetworkModelController _playerNetworkModelController;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (IsLocalPlayer)
        {
            CreatePlayerModelServerRpc();
        }
    }

    [ServerRpc]
    void CreatePlayerModelServerRpc()
    {
        if (NetworkManager.Singleton.IsServer)
        {
            var playerModel = Instantiate(_playerNetworkModelController);
            playerModel.NetworkObject.SpawnWithOwnership(OwnerClientId);
            playerModel.transform.SetParent(this.transform);
        }
    }
}