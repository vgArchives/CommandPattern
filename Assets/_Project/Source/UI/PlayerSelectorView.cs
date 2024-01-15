using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectorView : MonoBehaviour
{
    public static Action<PlayerIdentifier> OnPlayerSelected;

    [SerializeField] private Toggle _playerOneButton;
    [SerializeField] private Toggle _playerTwoButton;

    protected void Start()
    {
        _playerOneButton.onValueChanged.AddListener(HandlePlayerOneClick);
        _playerTwoButton.onValueChanged.AddListener(HandlePlayerTwoClick);
    }

    protected void OnDestroy()
    {
        _playerOneButton.onValueChanged.RemoveListener(HandlePlayerOneClick);
        _playerTwoButton.onValueChanged.RemoveListener(HandlePlayerTwoClick);
    }

    private void HandlePlayerOneClick(bool value)
    {
        if (!value)
        {
            return;
        }

        OnPlayerSelected?.Invoke(PlayerIdentifier.PlayerOne);
    }

    private void HandlePlayerTwoClick(bool value)
    {
        if (!value)
        {
            return;
        }

        OnPlayerSelected?.Invoke(PlayerIdentifier.PlayerTwo);
    }
}
