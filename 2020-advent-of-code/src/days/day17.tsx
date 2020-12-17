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
const example = [".#.", "..#", "###"];

type Coordinate = { x: number; y: number; z: number };
type EnergySource = { [key: string]: boolean };

function Day17() {
  const generateNeighborOffsets = (dimensions: number) => {
    let offsets: Coordinate[] = [];
    for (let i = 0; i < Math.pow(dimensions, dimensions); i++) {
      const radixValues = i
        .toString(dimensions)
        .padStart(dimensions, "0")
        .split("")
        .map((x) => parseInt(x));
      if (radixValues.every((v) => v === 1)) {
        continue;
      }
      offsets.push({
        x: radixValues[0] - 1,
        y: radixValues[1] - 1,
        z: radixValues[2] - 1,
      });
    }
    return offsets;
  };

  const neighborOffsets = generateNeighborOffsets(3);

  const toKey = (x: number, y: number, z: number) => `${x}:${y}:${z}`;

  const toCoordinate = (key: string): Coordinate => {
    const coordinate = key.split(":");
    return {
      x: Number(coordinate[0]),
      y: Number(coordinate[1]),
      z: Number(coordinate[2]),
    };
  };

  const countActiveNeighbors = (
    coordinate: Coordinate,
    energySource: EnergySource
  ) => {
    let activeNeighbors = 0;
    neighborOffsets.forEach((offset: Coordinate) => {
      if (
        energySource[
          toKey(
            coordinate.x + offset.x,
            coordinate.y + offset.y,
            coordinate.z + offset.z
          )
        ]
      ) {
        activeNeighbors++;
      }
    });
    return activeNeighbors;
  };

  const markInactiveNeighbors = (energySource: EnergySource) => {
    Object.entries(energySource).forEach((value: [string, boolean]) => {
      neighborOffsets.forEach((offset: Coordinate) => {
        const coordinate = toCoordinate(value[0]);
        const boundaryKey = toKey(
          coordinate.x + offset.x,
          coordinate.y + offset.y,
          coordinate.z + offset.z
        );
        if (!energySource[boundaryKey]) {
          energySource[boundaryKey] = false;
        }
      });
    });
  };

  let energySource: EnergySource = input.reduce(
    (energySource: EnergySource, row: string, y: number) => {
      for (let x = 0; x < row.length; x++) {
        if (row[x] === "#") {
          energySource[toKey(x, y, 0)] = true;
        }
      }
      return energySource;
    },
    {}
  );

  markInactiveNeighbors(energySource);

  for (let cycle = 0; cycle < 6; cycle++) {
    // print each z layer for debugging
    let newEnergySource: EnergySource = {};
    Object.entries(energySource).forEach((value: [string, boolean]) => {
      const activeNeighbors = countActiveNeighbors(
        toCoordinate(value[0]),
        energySource
      );

      let newState = false;
      if (value[1]) {
        // currently active
        newState = activeNeighbors === 2 || activeNeighbors === 3;
      } else {
        // not currently active
        newState = activeNeighbors === 3;
      }

      if (newState) {
        newEnergySource[value[0]] = true;
      }
    });

    markInactiveNeighbors(newEnergySource);
    energySource = newEnergySource;
  }

  const part1 = Object.values(energySource).reduce(
    (activeCount: number, isActive: boolean) => {
      return (activeCount += isActive ? 1 : 0);
    },
    0
  );

  return (
    <div>
      <h2>Day 17</h2>
      <p>After 6 cycles, there are {part1} active cubes in part 1</p>
    </div>
  );
}

export default Day17;
