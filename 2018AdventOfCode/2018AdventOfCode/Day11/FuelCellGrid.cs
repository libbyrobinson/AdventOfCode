using System.Collections.Generic;
using System.Threading.Tasks;
using MoreLinq;
using _2018AdventOfCode.Day11;

public class FuelCellGrid
{
    private readonly int _gridSize;
    private readonly FuelCell[,] _cellGrid;

    public FuelCellGrid(int gridSize, int serialNumber)
    {
        _gridSize = gridSize;
        _cellGrid = new FuelCell[gridSize,gridSize];

        for (var y = 1; y <= _gridSize; y++)
        {
            var rowSum = 0;
            for (var x = 1; x <= _gridSize; x++)
            {
                var fuelCell = new FuelCell(x, y, serialNumber);
                rowSum += fuelCell.PowerLevel;
                var cellAbove = GetCell(x, y - 1);
                fuelCell.SummedPowerLevel = rowSum + (cellAbove?.SummedPowerLevel ?? 0);
                AddCellToGrid(fuelCell);
            }
        }
    }

    private void AddCellToGrid(FuelCell fuelCell)
    {
        _cellGrid[fuelCell.XCoordinate -1, fuelCell.YCoordinate - 1] = fuelCell;
    }

    private FuelCell GetCell(int x, int y)
    {
        if (x > 1 && y > 1 && x <= _gridSize && y <= _gridSize)
        {
            return _cellGrid[x - 1, y - 1];
        }

        return null;
    }

    public Task<FuelCellsSquare> FindSquareWithHighestPowerAsync(int squareSize)
    {
        return Task.Run(() =>
        {
            var square = new FuelCellsSquare
            {
                SquareSize = squareSize
            };

            for (var y = 1; y <= _gridSize - squareSize + 1; y++)
            {
                for (var x = 1; x <= _gridSize - squareSize + 1; x++)
                {
                    var power = CalculateSummedSquarePower(x, y, squareSize);
                    if (power > square.PowerLevel)
                    {
                        square.TopLeftCorner = GetCell(x, y);
                        square.PowerLevel = power;
                    }
                }
            }

            return square;
        });
    }

    public async Task<FuelCellsSquare> FindSquareWithHighestPowerAsync()
    {
        var squareTasks = new List<Task<FuelCellsSquare>>();
        for (var size = 1; size <= _gridSize; size++)
        {
            squareTasks.Add(FindSquareWithHighestPowerAsync(size));
        }

        await Task.WhenAll(squareTasks);

        return squareTasks.MaxBy(s => s.Result.PowerLevel).FirstOrDefault().Result;
    }

    private int CalculateSummedSquarePower(int x, int y, int squareSize)
    {
        var a = GetCell(x - 1, y - 1);
        var b = GetCell(x - 1 + squareSize, y - 1); 
        var c = GetCell(x - 1, y - 1 + squareSize);
        var d = GetCell(x - 1 + squareSize, y - 1 + squareSize);

        return (a?.SummedPowerLevel ?? 0) + (d?.SummedPowerLevel ?? 0) - (b?.SummedPowerLevel ?? 0) - (c?.SummedPowerLevel ?? 0);
    }
}