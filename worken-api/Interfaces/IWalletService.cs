using Solnet.Wallet;
using Solnet.Wallet.Bip39;

namespace worken_api.Interfaces
{
    public interface IWalletService
    {
        Wallet CreateWallet();
        Wallet CreateWallet(WordCount count);
        Wallet CreateWallet(WordCount count, WordList wordList);
        Wallet CreateWallet(WordList wordList);
        WordList ConvertStringToWordList(string wordList);
    }
}