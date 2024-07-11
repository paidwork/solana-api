<p align="center">
  <img src="https://zrcdn.net/static/img/logos/paidwork/paidwork-logo-github.png" alt="Paidwork" />
</p>

<h3 align="center">
  Send & Receive secure Blockchain transactions on Solana with Worken
</h3>
<p align="center">
  🚀 Over 20K+ Worken holders!
</p>

<p align="center">
  <a href="https://github.com/paidwork/solana-sdk-unity">
    <img alt="GitHub Repository Stars Count" src="https://img.shields.io/github/stars/paidwork/solana-sdk-unity?style=social" />
  </a>
    <a href="https://x.com/paidworkco">
        <img alt="Follow Us on X" src="https://img.shields.io/twitter/follow/paidworkco?style=social" />
    </a>
</p>
<p align="center">
    <a href="http://commitizen.github.io/cz-cli/">
        <img alt="Commitizen friendly" src="https://img.shields.io/badge/commitizen-friendly-brightgreen.svg" />
    </a>
    <a href="https://github.com/paidwork/solana-sdk-php">
        <img alt="License" src="https://img.shields.io/github/license/paidwork/solana-sdk-php" />
    </a>
    <a href="https://github.com/paidwork/solana-sdk-php/pulls">
        <img alt="PRs Welcome" src="https://img.shields.io/badge/PRs-welcome-brightgreen.svg" />
    </a>
</p>

API providing access to make easy and secure Blockchain transactions with Worken. <a href="https://www.paidwork.com/worken?utm_source=github.com&utm_medium=referral&utm_campaign=readme" target="_blank">Read more</a> about Worken Token.
<p align="center">
 <h3 align="center">Endpoints<h3/>
<p/>

* CreateTransactionToAssociatedAccount **[POST]**
* SimulateTransactionToAssociatedAccount **[POST]**
* CreateTransactionWithBurnToAssociatedAccount **[POST]**
* SimulateTransactionWithBurnToAssociatedAccount **[POST]**
* Burn **[POST]**
* SimulateBurn **[POST]**
* CreateWallet **[POST]**
* CreateWalletWordCount **[POST]**
* CreateWalletWordList **[POST]**
* CreateWalletFull **[POST]**


## CreateTransactionToAssociatedAccount

#### **[POST]** /api/Transactions/CreateTransactionToAssociatedAccount

this endpoint send created transaction based on given body and send it to network for processing while returning Hash of such transaction

#### Body structure
```c#
public class CreateTransactionRequest
{
    public string fromAccountPublicKey { get; set; }

    public string fromAccountPrivateKey { get; set; }

    public string toAccountPublicKey { get; set; }

    public ulong lanPorts {  get; set; }
    
    public string Memo { get; set; } = string.Empty;

    public ulong SolAmount { get; set; } = 0;
}
```
#### Result
`string` Transaction hash 



## SimulateTransactionToAssociatedAccount

#### **[POST]** /api/Transactions/CreateTransactionToAssociatedAccount
this endpoint simulate transaction without sending it to network while returning result of complited transaction. This endpoint execute transaction exacly same as `CreateTransactionToAssociatedAccount` so this endpoint can be use for testing implementation
#### Body structure
```c#
public class CreateTransactionRequest
{
    public string fromAccountPublicKey { get; set; }

    public string fromAccountPrivateKey { get; set; }

    public string toAccountPublicKey { get; set; }

    public ulong lanPorts {  get; set; }
    
    public string Memo { get; set; } = string.Empty;

    public ulong SolAmount { get; set; } = 0;
}
```
#### Result
```c#
public class SimulationLogs
{
    public AccountInfo[] Accounts { get; set; }

    [JsonPropertyName("err")]
    public TransactionError Error { get; set; }

    public string[] Logs { get; set; }
}
```

## CreateTransactionWithBurnToAssociatedAccount

#### **[POST]** /api/Transactions/CreateTransactionToAssociatedAccount

this endpoint send created transaction based on given body and send it to network for processing while returning Hash of such transaction

#### Body structure
```c#
public class CreateTransactionBurnRequest
{
    public string fromAccountPublicKey { get; set; }

    public string fromAccountPrivateKey { get; set; }

    public string toAccountPublicKey { get; set; }

    public ulong lanPorts {  get; set; }

    public ulong LamPortsBurn { get; set; }

    public string Memo { get; set; } = string.Empty;

    public ulong SolAmount { get; set; } = 0;
}
```
#### Result
`string` Transaction hash 

## SimulateTransactionWithBurnToAssociatedAccount

#### **[POST]** /api/Transactions/SimulateTransactionWithBurnToAssociatedAccount
this endpoint simulate transaction without sending it to network while returning result of complited transaction. This endpoint execute transaction exacly same as `CreateTransactionToAssociatedAccount` so this endpoint can be use for testing implementation
#### Body structure
```c#
public class CreateTransactionRequest
{
    public string fromAccountPublicKey { get; set; }

    public string fromAccountPrivateKey { get; set; }

    public string toAccountPublicKey { get; set; }

    public ulong lanPorts {  get; set; }

    public ulong LamPortsBurn { get; set; }

    public string Memo { get; set; } = string.Empty;

    public ulong SolAmount { get; set; } = 0;
}
```
#### Result
```c#
public class SimulationLogs
{
    public AccountInfo[] Accounts { get; set; }

    [JsonPropertyName("err")]
    public TransactionError Error { get; set; }

    public string[] Logs { get; set; }
}
```## Burn

#### **[POST]** /api/Transactions/Burn

this endpoint send created transaction with only burn instruction

#### Body structure
```c#
public class CreateBurnRequest
{
    public string FromAccountPublicKey { get; set; }

    public string FromAccountPrivateKey { get; set; }

    public ulong Amount { get; set; }

    public string Memo { get; set; } = string.Empty;
}
```
#### Result
`string` Transaction hash ## SimulateBurn

#### **[POST]** /api/Transactions/SimulateBurn

this endpoint send created transaction with only burn instruction but only simulate transaction without sending to network

#### Body structure
```c#
public class CreateBurnRequest
{
    public string FromAccountPublicKey { get; set; }

    public string FromAccountPrivateKey { get; set; }

    public ulong Amount { get; set; }

    public string Memo { get; set; } = string.Empty;
}
```
#### Result
```c#
public class SimulationLogs
{
    public AccountInfo[] Accounts { get; set; }

    [JsonPropertyName("err")]
    public TransactionError Error { get; set; }

    public string[] Logs { get; set; }
}
```
## CreateWallet

#### **[POST]** /api/Wallet/CreateWallet

create base wallet with default values for wordCount and wordList as given
`WordCount.Twelve` and `WordList.English`

#### Body structure
```
empty
``` 

#### Example result [JSON]
<details>

```json
{
  "account": {
    "privateKey": {
      "key": "45oED964ffnj1Br6tDbwcLNdi8JaZqHciVdWeaJhLVwB4JWZ3SRWE7LtZn4Zh4ntqjrDD7ksyMaPRBuMEnfdhojz",
      "keyBytes": "mjAR0I/E+pNVwqxQ+Z3yGb1o0z5uELRb60DZikAQFDADskNwpOnFtC30jRx+Cyni+o3ALdANvDmJtJVU8cCuNQ=="
    },
    "publicKey": {
      "key": "FRt3vuU8aPPs74ZeH5CA6QD9WYutvVzzsySTYSTD1dn",
      "keyBytes": "A7JDcKTpxbQt9I0cfgsp4vqNwC3QDbw5ibSVVPHArjU="
    }
  },
  "mnemonic": {
    "isValidChecksum": true,
    "wordList": {
      "space": " ",
      "wordCount": 2048
    },
    "indices": [
      1224,
      1684,
      34,
      1881,
      1701,
      1350,
      453,
      1818,
      519,
      2037,
      1451,
      1540
    ],
    "words": [
      "october",
      "spoon",
      "affair",
      "twenty",
      "start",
      "potato",
      "december",
      "today",
      "domain",
      "wrong",
      "rely",
      "scene"
    ]
  }
}
```

</details>

## CreateWalletWordCount

#### **[POST]** /api/Wallet/CreateWalletWordCount

create base wallet with default values for wordList as given
`WordList.English` while wordCount must be provided

#### Body structure
```
int 
``` 
#### Possible values that represent number of words
12 15 18 21 24

#### Example result [JSON]
<details>

```json
{
  "account": {
    "privateKey": {
      "key": "45oED964ffnj1Br6tDbwcLNdi8JaZqHciVdWeaJhLVwB4JWZ3SRWE7LtZn4Zh4ntqjrDD7ksyMaPRBuMEnfdhojz",
      "keyBytes": "mjAR0I/E+pNVwqxQ+Z3yGb1o0z5uELRb60DZikAQFDADskNwpOnFtC30jRx+Cyni+o3ALdANvDmJtJVU8cCuNQ=="
    },
    "publicKey": {
      "key": "FRt3vuU8aPPs74ZeH5CA6QD9WYutvVzzsySTYSTD1dn",
      "keyBytes": "A7JDcKTpxbQt9I0cfgsp4vqNwC3QDbw5ibSVVPHArjU="
    }
  },
  "mnemonic": {
    "isValidChecksum": true,
    "wordList": {
      "space": " ",
      "wordCount": 2048
    },
    "indices": [
      1224,
      1684,
      34,
      1881,
      1701,
      1350,
      453,
      1818,
      519,
      2037,
      1451,
      1540
    ],
    "words": [
      "october",
      "spoon",
      "affair",
      "twenty",
      "start",
      "potato",
      "december",
      "today",
      "domain",
      "wrong",
      "rely",
      "scene"
    ]
  }
}
```

</details>

## CreateWalletWordList

#### **[POST]** /api/Wallet/CreateWalletWordList

create base wallet with default values for WordCount as given
`WordCount count` while WordList must be provided

#### Body structure
```
string
``` 
#### Possible values that represents wordList
"English", "Japanese", "ChineseSimplified", "ChineseTraditional", "Spanish", "French", "PortugueseBrazil", "Czech"

#### Example result [JSON]
<details>

```json
{
  "account": {
    "privateKey": {
      "key": "45oED964ffnj1Br6tDbwcLNdi8JaZqHciVdWeaJhLVwB4JWZ3SRWE7LtZn4Zh4ntqjrDD7ksyMaPRBuMEnfdhojz",
      "keyBytes": "mjAR0I/E+pNVwqxQ+Z3yGb1o0z5uELRb60DZikAQFDADskNwpOnFtC30jRx+Cyni+o3ALdANvDmJtJVU8cCuNQ=="
    },
    "publicKey": {
      "key": "FRt3vuU8aPPs74ZeH5CA6QD9WYutvVzzsySTYSTD1dn",
      "keyBytes": "A7JDcKTpxbQt9I0cfgsp4vqNwC3QDbw5ibSVVPHArjU="
    }
  },
  "mnemonic": {
    "isValidChecksum": true,
    "wordList": {
      "space": " ",
      "wordCount": 2048
    },
    "indices": [
      1224,
      1684,
      34,
      1881,
      1701,
      1350,
      453,
      1818,
      519,
      2037,
      1451,
      1540
    ],
    "words": [
      "october",
      "spoon",
      "affair",
      "twenty",
      "start",
      "potato",
      "december",
      "today",
      "domain",
      "wrong",
      "rely",
      "scene"
    ]
  }
}
```
</details>


## CreateWalletFull

#### **[POST]** /api/Wallet/CreateWalletFull

this endpoint gives you full access to parameters of creating wallet such as `WordCount` and `WordList` so both must be provided for this endpoint

#### Body structure
```csharp
public class WalletCreationRequest
{
    public string WordList { get; set; }

    public int WordCount { get; set; }
}
``` 
#### Possible values for WordCount that represent number of words
12 15 18 21 24

#### Possible values for WordList that represents wordList
"English", "Japanese", "ChineseSimplified", "ChineseTraditional", "Spanish", "French", "PortugueseBrazil", "Czech"

#### Example result [JSON]
<details>

```json
{
  "account": {
    "privateKey": {
      "key": "45oED964ffnj1Br6tDbwcLNdi8JaZqHciVdWeaJhLVwB4JWZ3SRWE7LtZn4Zh4ntqjrDD7ksyMaPRBuMEnfdhojz",
      "keyBytes": "mjAR0I/E+pNVwqxQ+Z3yGb1o0z5uELRb60DZikAQFDADskNwpOnFtC30jRx+Cyni+o3ALdANvDmJtJVU8cCuNQ=="
    },
    "publicKey": {
      "key": "FRt3vuU8aPPs74ZeH5CA6QD9WYutvVzzsySTYSTD1dn",
      "keyBytes": "A7JDcKTpxbQt9I0cfgsp4vqNwC3QDbw5ibSVVPHArjU="
    }
  },
  "mnemonic": {
    "isValidChecksum": true,
    "wordList": {
      "space": " ",
      "wordCount": 2048
    },
    "indices": [
      1224,
      1684,
      34,
      1881,
      1701,
      1350,
      453,
      1818,
      519,
      2037,
      1451,
      1540
    ],
    "words": [
      "october",
      "spoon",
      "affair",
      "twenty",
      "start",
      "potato",
      "december",
      "today",
      "domain",
      "wrong",
      "rely",
      "scene"
    ]
  }
}
```

</details>

