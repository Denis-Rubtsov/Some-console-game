using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkConsoleGame
{
    internal class Map
    {
        char[,] _map;
        Position _startPosition = new(1,1);
        List<Position> _listOfEnemies = new();
        

        public void LoadMapFromFile(string fileName)
        {
            string[] tempMap = File.ReadAllLines(fileName);
            _map = new char[tempMap.Length, tempMap[0].Length];
            for (int i = 0; i < tempMap.Length; i++)
            {
                for (int j = 0; j < tempMap[0].Length; j++)
                {
                    _map[i, j] = tempMap[i][j];
                }
            }
            _map[_startPosition.Y, _startPosition.X] = 'P';
            FindEnemies();
        }

        public void PrintMap()
        {
            if (_map != null)
            {
                for (int i = 0; i < _map.GetLength(0); i++)
                {
                    for (int j = 0; j < _map.GetLength(1); j++)
                    {
                        Console.Write(_map[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }

        private void FindEnemies()
        {
            if (_map != null)
            {
                for (int i = 0; i < _map.GetLength(0); i++)
                {
                    for (int j = 0; j < _map.GetLength(1); j++)
                    {
                        if (_map[i, j] == 'E') _listOfEnemies.Add(new(j, i));
                    }
                    Console.WriteLine();
                }
            }
        }

        public void MoveEnemy()
        {
            Random random = new();
            var enemyNumber = random.Next(0,_listOfEnemies.Count);
            var direction = random.Next(1, 5);
            Position nextPosition = new(0, 0);
            switch(direction)
            {
                case 1:
                    nextPosition = _listOfEnemies[enemyNumber].Plus(0, -1);
                    break;
                case 2:
                    nextPosition = _listOfEnemies[enemyNumber].Plus(0, 1);
                    break;
                case 3:
                    nextPosition = _listOfEnemies[enemyNumber].Plus(-1, 0);
                    break;
                case 4:
                    nextPosition = _listOfEnemies[enemyNumber].Plus(1, 0);
                    break;
            }
            if (_map[nextPosition.Y, nextPosition.X] == ' ')
            {
                _map[_listOfEnemies[enemyNumber].Y, _listOfEnemies[enemyNumber].X] = ' ';
                _map[nextPosition.Y, nextPosition.X] = 'E';
                _listOfEnemies[enemyNumber] = nextPosition;
            }
        }

        public int MovePlayer(ref Position currentPosition, Position nextPosition)
        {
                switch (_map[nextPosition.Y, nextPosition.X])
                {
                    case ' ':
                        _map[nextPosition.Y, nextPosition.X] = 'P';
                        if (currentPosition.Equals(_startPosition)) _map[currentPosition.Y, currentPosition.X] = '@';
                        else _map[currentPosition.Y, currentPosition.X] = ' ';
                        currentPosition = nextPosition;
                        break;
                    case '#':
                        break;
                    case 'G':
                        _map[nextPosition.Y, nextPosition.X] = 'P';
                        if (currentPosition.Equals(_startPosition)) _map[currentPosition.Y, currentPosition.X] = '@';
                        else _map[currentPosition.Y, currentPosition.X] = ' ';
                        currentPosition = nextPosition;
                        return 200;
                        break;
                    case 'E':
                        _map[nextPosition.Y, nextPosition.X] = 'P';
                        if (currentPosition.Equals(_startPosition)) _map[currentPosition.Y, _startPosition.X] = '@';
                        else _map[currentPosition.Y, currentPosition.X] = ' ';
                        currentPosition = nextPosition;
                        throw new BattleException("Time to battle");
                        break;
                    case 'B':
                        _map[nextPosition.Y, nextPosition.X] = 'P';
                        if (currentPosition.Equals(_startPosition)) _map[currentPosition.Y, currentPosition.X] = '@';
                        else _map[currentPosition.Y, currentPosition.X] = ' ';
                        currentPosition = nextPosition;
                        throw new BossBattleException("Time to battle the boss!");
                        break;
                    case 'S':
                        throw new StoreException();
                        break;
                    case 'D':
                        throw new EndOfLevelException();
                        break;
                }
            return 0;
        }
    }
}
