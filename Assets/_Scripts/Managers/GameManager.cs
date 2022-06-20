using System;
using UnityEngine;

namespace _Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Flags]
        private enum GameState
        {
            None = 0,
            Start = 1 << 0,
            End = 1 << 1,
            Walk = 1 << 2,
            Pilot = 1 << 3,
            Inside = 1 << 4,
            Outside = 1 << 5
        }

        [SerializeField] private GameState _state;

        private void Start()
        {
            _state = GameState.Start | GameState.Inside | GameState.Outside;

            print($"Current game states are: {_state}");
        }
    }
}