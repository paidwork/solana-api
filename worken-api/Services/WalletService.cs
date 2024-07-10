using Solnet.Wallet;
using Solnet.Wallet.Bip39;
using worken_api.Interfaces;

namespace worken_api.Services
{
    public class WalletService : IWalletService
    {

        public WalletService() { }

        public Wallet CreateWallet()
        {
            return new Wallet(WordCount.Twelve, WordList.English);
        }

        public Wallet CreateWallet(WordCount count)
        {
            return new Wallet(count, WordList.English);
        }

        public Wallet CreateWallet(WordList wordList)
        {
            return new Wallet(WordCount.Twelve, wordList);
        }

        public Wallet CreateWallet(WordCount count, WordList wordList)
        {
            return new Wallet(count, wordList);
        }

        public WordList ConvertStringToWordList(string wordList)
        {
            WordList words = null;

            switch (wordList)
            {
                case nameof(WordList.English):
                    words = WordList.English;
                    break;
                case nameof(WordList.Japanese):
                    words = WordList.Japanese;
                    break;
                case nameof(WordList.ChineseSimplified):
                    words = WordList.ChineseSimplified;
                    break;
                case nameof(WordList.ChineseTraditional):
                    words = WordList.ChineseTraditional;
                    break;
                case nameof(WordList.Spanish):
                    words = WordList.Spanish;
                    break;
                case nameof(WordList.French):
                    words = WordList.French;
                    break;
                case nameof(WordList.PortugueseBrazil):
                    words = WordList.PortugueseBrazil;
                    break;
                case nameof(WordList.Czech):
                    words = WordList.Czech;
                    break;
                default:
                    words = WordList.English;
                    break;
            }

            return words;
        }
    }
}
