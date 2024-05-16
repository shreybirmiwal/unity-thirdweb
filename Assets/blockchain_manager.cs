using System.Collections;
using UnityEngine;
using TMPro;
using Thirdweb;
using System.Numerics;

public class BlockchainManager : MonoBehaviour
{

    public TMP_InputField inputField;
    public TMP_Text displayText;


    private string contract_address = "0xc94bf248e2Aaa8E95c52Fb24711528743544d0aA";
    private string contract_ABI = @"[
        {
            ""type"": ""constructor"",
            ""name"": """",
            ""inputs"": [],
            ""outputs"": [],
            ""stateMutability"": ""nonpayable""
        },
        {
            ""type"": ""function"",
            ""name"": ""getNumber"",
            ""inputs"": [],
            ""outputs"": [
                {
                    ""type"": ""uint256"",
                    ""name"": """",
                    ""internalType"": ""uint256""
                }
            ],
            ""stateMutability"": ""view""
        },
        {
            ""type"": ""function"",
            ""name"": ""increment"",
            ""inputs"": [],
            ""outputs"": [],
            ""stateMutability"": ""nonpayable""
        },
        {
            ""type"": ""function"",
            ""name"": ""setNumber"",
            ""inputs"": [
                {
                    ""type"": ""uint256"",
                    ""name"": ""_number"",
                    ""internalType"": ""uint256""
                }
            ],
            ""outputs"": [],
            ""stateMutability"": ""nonpayable""
        }
    ]";


    private ThirdwebSDK sdk;
    private Contract contract;

    void Start()
    {
        sdk = ThirdwebManager.Instance.SDK;
        GetData();
    }

    public async void GetData()
    {
        contract = sdk.GetContract(contract_address, contract_ABI);
        var data = await contract.Read<string>("getNumber");
        displayText.text = data;
    }

    void Update()
    {
    }

    public async void UpdateNumber()
    {

        //get the value in the input field
        string number = inputField.text;
        BigInteger arg1 = BigInteger.Parse(number);

        var data  = await contract.Write("setNumber", arg1);

        GetData();
    }

    public async void IncrementNumber()
    {
        var data  = await contract.Write("increment");
        GetData();

    }
}
