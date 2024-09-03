# Test task for Peanut Trade

## How to add new Exchange to project

Firstly you need to add new settings to `appsettings.json`. You should follow the same structure as previous ones. **Note!** Count of symbols should be the same for all exchangesand must mean the same cryptocurrency pairs, for example `BTCUSDT` for Binance and `BTC-USDT` for Kucoin.

![image](https://github.com/user-attachments/assets/82e30f9a-276b-4d4d-9c80-117f19c2b77a)

Next step, you need to create a new client settings and inherit it from the 'BaseExchangeClientSettings' class, then register it in `Program.cs`.

![image](https://github.com/user-attachments/assets/304f7e02-2567-4b6c-b7e6-90f480cd0ab9)
![image](https://github.com/user-attachments/assets/7edbdde6-6d30-4ca4-a568-7ca2d2ef42bd)

Then create new client service and inherit it from `IExchangeClient`, implement methods as needed, aslo do not forget to register it in `Program.cs` with client settings that you created before.

![image](https://github.com/user-attachments/assets/fdd03f30-5fe3-4e34-81f0-c8ff790eb216)

After this your implementation will pull through DI to `ArbitrationService` and will be used through collection of client services.

![image](https://github.com/user-attachments/assets/6d371cee-43a6-4072-8cf9-6e26d89ae066)

## Examples of requests and responses

**Request**
`/api/arbitration/estimate?inputAmount=5&outputCurrency=BTC&inputCurrency=ETH`

**Response**
```
{
    "outputAmount": 0.21215000,
    "exchangeName": "binance"
}
```

**Request**
`/api/arbitration/rates?baseCurrency=ETH&quoteCurrency=BTC`

**Response**
```
[
    {
        "exchangeName": "binance",
        "rate": 0.04231000
    },
    {
        "exchangeName": "kucoin",
        "rate": 0.04229
    }
]
```

### Best regards!
