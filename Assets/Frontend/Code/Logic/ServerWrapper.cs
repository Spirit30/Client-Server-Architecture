using Backend;
using Shared;
using UnityEngine;

namespace Frontend
{
    public class ServerWrapper : MonoBehaviour
    {
        Game game = new Game();

        [SerializeField]
        GamePlayer player;

        void Awake()
        {
            game.OnGameDataResponse += OnGameDataResponse;
        }

        void OnDestroy()
        {
            game.OnGameDataResponse -= OnGameDataResponse;
        }

        void Start()
        {
            game.GameDataRequest();
        }

        void OnGameDataResponse(GameData data)
        {
            player.Play(data);
        }
    }
}