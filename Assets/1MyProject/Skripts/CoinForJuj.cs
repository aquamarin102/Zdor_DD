using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace Quest
{
    public class CoinForJuj : MonoBehaviour
    { 
        private int coinsPrice = 5;

        public void MoneyForKill()
        {
            var request = new AddUserVirtualCurrencyRequest()
            {
                VirtualCurrency = "SC",
                Amount = coinsPrice
            };
            PlayFabClientAPI.AddUserVirtualCurrency(request,AddCoinsSuccess,OnError);
        }

        void AddCoinsSuccess(ModifyUserVirtualCurrencyResult result)
        {
            LobbyStarter.instance.GetVirtualCurrencies();
        }

        void OnError(PlayFabError error)
        {
            Debug.Log("Error:" + error.ErrorMessage);
        }
    }
}