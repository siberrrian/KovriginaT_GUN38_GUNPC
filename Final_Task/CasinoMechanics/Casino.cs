using Final_Task.GamesMechanics;
using Final_Task.SaveLoadData;

namespace Final_Task.CasinoMechanics
{
    internal class Casino : IGame
    {
        public string _playerName;
        public int _playerMoney;
        private int _playerMoneyMax = 2000;
        private int _playerMoneyStart = 500;
        private int _bet;
        private FileSystemSaveLoadService _fileSystemSaveLoadService;
        private DiceGame _diceGame;
        private BlackjackGame _blackjackGame;
        public Casino()
        {
            _fileSystemSaveLoadService = new FileSystemSaveLoadService(".\\Casino\\" + _playerName);
            _diceGame = new DiceGame(2, 1, 6);
            _blackjackGame = new BlackjackGame(52);
        }
        public void StartGame()
        {
            Console.WriteLine("Welcome to the casino!\nEnter your name:");
            _playerName = Console.ReadLine();
            int.TryParse(_fileSystemSaveLoadService.LoadData(_playerName), out _playerMoney);
            if (_playerMoney == -1)
            {
                _playerMoney = _playerMoneyStart;
                _fileSystemSaveLoadService.SaveData(_playerMoneyStart.ToString(), _playerName);
            }
            Console.WriteLine(GetGameType());
            CasinoGames gameType;
            while (!Enum.TryParse<CasinoGames>(Console.ReadLine(), out gameType) || (int)gameType < 1 || (int)gameType > 2)
            {
                Console.WriteLine(GetGameType());
            }
            if (_playerMoney == 0)
            {
                Console.WriteLine("No money? Kicked!\nGoodbye!");
                return;
            }
            Console.WriteLine(GetGameBet());
            while (!int.TryParse(Console.ReadLine(), out _bet) || (int)_bet < 1 || (int)_bet > _playerMoney)
            {
                Console.WriteLine(GetGameBet());
            }
            switch (gameType)
            {
                case CasinoGames.Blackjack:
                    _blackjackGame.OnWin += playerWin;
                    _blackjackGame.OnLoose += playerLoose;
                    _blackjackGame.OnDraw += playerDraw;
                    _blackjackGame.PlayGame();
                    break;
                case CasinoGames.Dice:
                    _diceGame.OnWin += playerWin;
                    _diceGame.OnLoose += playerLoose;
                    _diceGame.OnDraw += playerDraw;
                    _diceGame.PlayGame();
                    break;
                default:
                    break;
            }
            _fileSystemSaveLoadService.SaveData(_playerMoney.ToString(), _playerName);
            Console.WriteLine("Goodbye!");
        }

        private void playerDraw()
        {
            Console.WriteLine($"It was a draw. Your bank: {_playerMoney}");
        }

        private void playerLoose()
        {
            _playerMoney -= _bet;
            Console.WriteLine($"You loose :( Your bank: {_playerMoney}");
        }

        private void playerWin()
        {
            _playerMoney += _bet;
            Console.WriteLine($"You win!!! Your bank: {_playerMoney}");
            if (_playerMoney > _playerMoneyMax)
            {
                _playerMoney /= 2;
                Console.WriteLine($"You wasted half of your bank money in casino’s bar. Your bank: {_playerMoney}");
            }
        }

        private string GetGameType() => $"Type {CasinoGames.Blackjack} = {(int)CasinoGames.Blackjack}" +
           $" or {CasinoGames.Dice} = {(int)CasinoGames.Dice}";

        private string GetGameBet() => $"Enter your bet (from 1 to {_playerMoney})";




    }
}
