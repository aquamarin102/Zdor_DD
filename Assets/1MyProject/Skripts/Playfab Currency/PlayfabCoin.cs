
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;

public class PlayfabCoin : MonoBehaviour
{
    [Header("UI")] 
    [SerializeField] private TextMeshPro _coinsValueText;

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Log success");
        GetVirtualCurrencies();
    }
    
    private void GetVirtualCurrencies()
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, OnError);
    }

    private void OnGetUserInventorySuccess( GetUserInventoryResult result)
    {
        int coins = result.VirtualCurrency["SC"];
        _coinsValueText.text = coins.ToString();
    }

    private void OnError(PlayFabError error)
    {
        Debug.Log("Error: " + error.ErrorMessage);
    }
}
