using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using static Result;

class Result
{

    /*
     * Complete the 'bomberMan' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. STRING_ARRAY grid
     */
    private static void CheckConstraints(int n, List<string> grid)
    {
        if (grid.Count < 1
            || grid.Count > 200
            || grid.Any(item => item.Length < 1 || item.Length > 200))
            throw new ArgumentException("Grid dimensions (rows and column length) must be between 1 and 200.");

        if (n < 1 || n > Math.Pow(10,9))
            throw new ArgumentException("Value 'n' must be between 1 and 10^9.");
    }

    public class ExplosionHelper()
    {
        private static bool IsBlown(List<string> currentGrid, int row, int col, int i, int j)
        {

            return currentGrid[i][j] == 'O' ||
                    (i > 0 && currentGrid[i - 1][j] == 'O') ||           // Up
                    (i < row - 1 && currentGrid[i + 1][j] == 'O') ||     // Down
                    (j > 0 && currentGrid[i][j - 1] == 'O') ||           // Left
                    (j < col - 1 && currentGrid[i][j + 1] == 'O');       // Right
        }

        public static List<string> Detonate(List<string> currentGrid, int row, int col)
        {
            List<string> nextGrid = new List<string>();

            for (int i = 0; i < row; i++)
            {
                var rowChars = new StringBuilder();

                for (int j = 0; j < col; j++)
                {
                    rowChars.Append(IsBlown(currentGrid, row, col, i, j) ? '.' : 'O');
                }

                nextGrid.Add(rowChars.ToString());
            }

            return nextGrid;
        }

    }

    public interface IGridState
    {
        List<string> Process(List<string> initialGrid, int row, int col);
    }

    // State for N = 1
    public class InitialState : IGridState
    {
        public List<string> Process(List<string> initialGrid, int row, int col)
        {
            return initialGrid;
        }
    }

    // State for Even N
    public class FullBombState : IGridState
    {
        public List<string> Process(List<string> initialGrid, int row, int col)
        {
            var fullGrid = Enumerable.Repeat(new string(
                'O',
                col), row).ToList();
            return fullGrid;
        }
    }

    // State for N % 4 == 3 (1st explosion)
    public class ThreeSecondState : IGridState
    {
        public List<string> Process(List<string> initialGrid, int row, int col)
        {
            return ExplosionHelper.Detonate(initialGrid, row, col);
        }
    }

    // State for N % 4 == 1 (2nd explosion)
    public class FiveSecondState : IGridState
    {
        public List<string> Process(List<string> initialGrid, int row, int col)
        {
            var state3 = ExplosionHelper.Detonate(initialGrid, row, col);
            return ExplosionHelper.Detonate(state3, row, col);
        }
    }

    // Context
    public class Context
    {
        private IGridState _state;

        public void SetState(IGridState state)
        {
            _state = state;
        }

        public List<string> ExecuteStrategy(List<string> grid, int n)
        {
            int row = grid.Count;
            int col = grid[0].Length;
            return _state.Process(grid, row, col);
        }
    }

    public static List<string> BomberMan(int n, List<string> grid)
    {
        CheckConstraints(n, grid);

        var context = new Context();

        if (n == 1)
            context.SetState(new InitialState());
        else if (n % 2 == 0)
            context.SetState(new FullBombState());
        else if (n % 4 == 3)
            context.SetState(new ThreeSecondState());
        else
            context.SetState(new FiveSecondState());

        return context.ExecuteStrategy(grid, n);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r = Convert.ToInt32(firstMultipleInput[0]);

        int c = Convert.ToInt32(firstMultipleInput[1]);

        int n = Convert.ToInt32(firstMultipleInput[2]);

        List<string> grid = new List<string>();

        for (int i = 0; i < r; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        List<string> result = Result.BomberMan(n, grid);

        Console.WriteLine(String.Join("\n", result));
    }
}
