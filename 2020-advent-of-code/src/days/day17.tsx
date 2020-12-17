const input = [
  "...#...#",
  "#######.",
  "....###.",
  ".#..#...",
  "#.#.....",
  ".##.....",
  "#.####..",
  "#....##.",
];

type EnergySource = { [key: string]: boolean };

function Day17() {
  const generateNeighborOffsets = (dimensions: number) => {
    let offsets: number[][] = [];
    for (let i = 0; i < Math.pow(3, dimensions); i++) {
      const offset = i
        .toString(3)
        .padStart(dimensions, "0")
        .split("")
        .map((x) => parseInt(x))
        .map((x) => x - 1);

      if (offset.every((v) => v === 0)) {
        continue;
      }

      offsets.push(offset);
    }
    return offsets;
  };

  const toKey = (coordinates: number[]) => coordinates.join(":");

  const toCoordinate = (key: string): number[] => {
    return key.split(":").map((x) => parseInt(x));
  };

  const countActiveNeighbors = (
    coordinate: number[],
    energySource: EnergySource,
    neighborOffsets: number[][]
  ) => {
    let activeNeighbors = 0;
    neighborOffsets.forEach((offset: number[]) => {
      const offsetCoordinate = coordinate.map(
        (dimension: number, index: number) => {
          return dimension + offset[index];
        }
      );
      if (energySource[toKey(offsetCoordinate)]) {
        activeNeighbors++;
      }
    });
    return activeNeighbors;
  };

  const markInactiveBoundary = (
    energySource: EnergySource,
    neighborOffsets: number[][]
  ) => {
    Object.entries(energySource).forEach((value: [string, boolean]) => {
      neighborOffsets.forEach((offset: number[]) => {
        const coordinate = toCoordinate(value[0]);
        const offsetCoordinate = coordinate.map(
          (dimension: number, index: number) => {
            return dimension + offset[index];
          }
        );
        const boundaryKey = toKey(offsetCoordinate);
        if (!energySource[boundaryKey]) {
          energySource[boundaryKey] = false;
        }
      });
    });
  };

  const countActiveCubes = (
    input: string[],
    dimensions: number,
    cycles: number
  ) => {
    const neighborOffsets = generateNeighborOffsets(dimensions);

    let energySource: EnergySource = input.reduce(
      (energySource: EnergySource, row: string, y: number) => {
        for (let x = 0; x < row.length; x++) {
          if (row[x] === "#") {
            const coordinates = new Array(dimensions).fill(0);
            coordinates[0] = x;
            coordinates[1] = y;
            energySource[toKey(coordinates)] = true;
          }
        }
        return energySource;
      },
      {}
    );
    markInactiveBoundary(energySource, neighborOffsets);

    for (let cycle = 0; cycle < cycles; cycle++) {
      let newEnergySource: EnergySource = {};
      Object.entries(energySource).forEach((value: [string, boolean]) => {
        const activeNeighbors = countActiveNeighbors(
          toCoordinate(value[0]),
          energySource,
          neighborOffsets
        );

        if (
          (value[1] && (activeNeighbors === 2 || activeNeighbors === 3)) ||
          (!value[1] && activeNeighbors === 3)
        ) {
          newEnergySource[value[0]] = true;
        }
      });

      markInactiveBoundary(newEnergySource, neighborOffsets);
      energySource = newEnergySource;
    }

    return Object.values(energySource).reduce(
      (activeCount: number, isActive: boolean) => {
        return (activeCount += isActive ? 1 : 0);
      },
      0
    );
  };

  const part1 = countActiveCubes(input, 3, 6);
  const part2 = countActiveCubes(input, 4, 6);

  return (
    <div>
      <h2>Day 17</h2>
      <p>After 6 cycles, there are {part1} active cubes in part 1</p>
      <p>After 6 cycles, there are {part2} active cubes in part 2</p>
    </div>
  );
}

export default Day17;
