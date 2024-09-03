# Test task for Peanut Trade

## How to add new Exchange to project

Firstly you need to add new settings to `appsettings.json`. You should follow the same structure as previous ones. **Note!** Count of symbols should be the same for all exchangesand must mean the same cryptocurrency pairs, for example `BTCUSDT` for Binance and `BTC-USDT` for Kucoin.

![image](https://github.com/user-attachments/assets/64d1c670-3b7b-49fb-98bd-9a963b672c8c)

Next step, you need to create a new client settings and inherit it from the 'BaseExchangeClientSettings' class, then register it in `Program.cs`.

![image](https://github.com/user-attachments/assets/304f7e02-2567-4b6c-b7e6-90f480cd0ab9)
![image](https://github.com/user-attachments/assets/7edbdde6-6d30-4ca4-a568-7ca2d2ef42bd)

Then create new client service and inherit it from `IExchangeClient`, implement methods as needed, aslo do not forget to register it in `Program.cs` with client settings that you created before.

![image](https://github.com/user-attachments/assets/fdd03f30-5fe3-4e34-81f0-c8ff790eb216)

After this your implementation will pull through DI to `ArbitrationService` and will be used through collection of client services.

![image](https://github.com/user-attachments/assets/6d371cee-43a6-4072-8cf9-6e26d89ae066)

### Best regards!
