using ConnectionFour.Service.BusinessLogic;
using ConnectionFour.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Response = ConnectionFour.Model.Enums.ResponseEnum;

namespace ConnectionFour.Service.Services.Validator
{
    public class ValidatorService : IValidatorService
    {
        public bool CheckGameIsValid(string inputBoard)
        {
            if (string.IsNullOrWhiteSpace(inputBoard)) return false;

            if (inputBoard.Length != GameRules.VectorLength) return false;

            if (!CheckAllPositionsAreValid(inputBoard)) return false;

            if (GetDifferenceOfMovementsBetweenPlayers(inputBoard) > 1) return false;

            return true;
        }

        public string CheckForWinner(string inputBoard)
        {
            char[,] boardMatrix = ParseInputBoardToMatrix(inputBoard);
            var playerChains = GetTotalPlayerChains(boardMatrix);

            Response response = GetGameResults(playerChains);

            return response.GetDescription();
        }

        private static Response GetGameResults(Dictionary<char, int> playerChains)
        {
            int playerA = playerChains
                .Where(x => x.Key == GameRules.PlayerOnePosition)
                .Select(x => x.Value)
                .FirstOrDefault();

            int playerB = playerChains
                .Where(x => x.Key == GameRules.PlayerTwoPosition)
                .Select(x => x.Value)
                .FirstOrDefault();

            if (playerA > 0 && playerB == 0)
            {
                return Response.TeamAHasWon;
            }

            if (playerA == 0 && playerB > 0)
            {
                return Response.TeamBHasWon;
            }

            if (playerA >= 1 && playerB >= 1)
            {
                throw new Exception("Cannot win more than one player");
            }

            return Response.TheGameIsOngoing;
        }

        private static char[,] ParseInputBoardToMatrix(string inputBoard)
        {
            int columnPositionBoard = 0;
            char[,] boardMatrix = new char[GameRules.TotalPositionsPerRow, GameRules.TotalPositionsPerColumn];

            for (var i = 0; i < inputBoard.Length; i += GameRules.TotalPositionsPerColumn)
            {
                string column = inputBoard.Substring(i, Math.Min(GameRules.TotalPositionsPerColumn, inputBoard.Length - i));

                for (int j = 0; j < column.Length; j++)
                {
                    boardMatrix[columnPositionBoard, j] = column.ElementAt(j);
                }

                columnPositionBoard++;
            }

            return boardMatrix;
        }

        private static Dictionary<char, int> GetTotalPlayerChains(char[,] boardMatrix)
        {
            Dictionary<char, int> totalPlayerChains = new()
            {
                { GameRules.PlayerOnePosition, 0 },
                { GameRules.PlayerTwoPosition, 0 }
            };

            for (int row = 0; row < GameRules.TotalPositionsPerRow; row++)
            {
                for (int col = 0; col< GameRules.TotalPositionsPerColumn; col++)
                {
                    foreach (char player in GameRules.Players)
                    {
                        bool hasFour = CheckFourInlineByPlayer(boardMatrix, row, col, player);

                        if (hasFour)
                        {
                            totalPlayerChains[player] = totalPlayerChains.GetValueOrDefault(player) + 1;
                        }
                    }
                }
            }

            return totalPlayerChains;
        }

        private static bool CheckFourInlineByPlayer(char[,] boardMatrix, int row, int col, char player)
        {
            try
            {
                if (boardMatrix[row, col] == player &&
                    boardMatrix[row - 1, col - 1] == player &&
                    boardMatrix[row - 2, col - 2] == player &&
                    boardMatrix[row - 3, col - 3] == player)
                {
                    return true;
                }
            }
            catch (Exception) { }

            try
            {
                if (boardMatrix[row, col] == player &&
                    boardMatrix[row, col - 1] == player &&
                    boardMatrix[row, col - 2] == player &&
                    boardMatrix[row, col - 3] == player)
                {
                    return true;
                }
            }
            catch (Exception) { }

            try
            {
                if (boardMatrix[row, col] == player &&
                    boardMatrix[row - 1, col] == player &&
                    boardMatrix[row - 2, col] == player &&
                    boardMatrix[row - 3, col] == player)
                {
                    return true;
                }
            }
            catch (Exception) { }

            try
            {

                if (boardMatrix[row, col] == player &&
                    boardMatrix[row - 1, col + 1] == player &&
                    boardMatrix[row - 2, col + 2] == player &&
                    boardMatrix[row - 3, col + 3] == player)
                {
                    return true;
                }
            }
            catch (Exception) { }

            try
            {

                if (boardMatrix[row, col] == player &&
                    boardMatrix[row, col + 1] == player &&
                    boardMatrix[row, col + 2] == player &&
                    boardMatrix[row, col + 3] == player)
                {
                    return true;
                }
            }
            catch (Exception) { }

            return false;
        }

        private static int GetDifferenceOfMovementsBetweenPlayers(string input)
        {
            int totalMovesPlayerOne = input.Count(x => x == GameRules.PlayerOnePosition);
            int totalMovesPlayerTwo = input.Count(x => x == GameRules.PlayerTwoPosition);

            return Math.Abs(totalMovesPlayerOne - totalMovesPlayerTwo);
        }

        private static bool CheckAllPositionsAreValid(string input)
        {
            foreach (char c in input)
            {
                if (!GameRules.ValidPositions.Contains(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
