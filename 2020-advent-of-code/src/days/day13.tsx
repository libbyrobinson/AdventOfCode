const input = [
  "1008832",
  "23,x,x,x,x,x,x,x,x,x,x,x,x,41,x,x,x,x,x,x,x,x,x,449,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,13,19,x,x,x,x,x,x,x,x,x,29,x,991,x,x,x,x,x,37,x,x,x,x,x,x,x,x,x,x,17",
];
const exampleInput = ["939", "7,13,x,x,59,x,31,19"];

function Day13() {
  const getEarliestBus = (input: string[]) => {
    const earliestDeparture = Number(input[0]);

    const buses = input[1]
      .split(",")
      .filter((bus: string) => bus !== "x")
      .map((bus: string) => Number(bus))
      .map((bus: number) => {
        return {
          busId: bus,
          nextTime: Math.ceil(earliestDeparture / bus) * bus,
        };
      })
      .sort((n1, n2) => n1.nextTime - n2.nextTime);

    return {
      earliestDeparture,
      earliestBus: buses[0],
    };
  };

  const getFirstBusTimestamp = (input: string): number => {
    const outOfService = -1;

    const buses = input
      .split(",")
      .map((bus: string) => (bus === "x" ? outOfService : Number(bus)));

    let currentIndex = 1;
    let timestamp = buses[0];
    let lcm = timestamp;

    while (currentIndex < buses.length) {
      if (buses[currentIndex] === outOfService) {
        currentIndex++;
      } else if ((timestamp + currentIndex) % buses[currentIndex] === 0) {
        lcm *= buses[currentIndex];
        currentIndex++;
      } else {
        timestamp += lcm;
      }
    }

    return timestamp;
  };

  const assertPart1Example = (input: string[], expected: number) => {
    const exampleBus = getEarliestBus(input);
    if (exampleBus.earliestBus.busId !== expected) {
      throw Error(
        `Expected bus ${expected} to be earliest in the example, but was actually ${exampleBus.earliestBus.busId}`
      );
    }
  };

  const assertPart2Example = (input: string, expected: number) => {
    const firstBusTimestamp = getFirstBusTimestamp(input);
    if (firstBusTimestamp !== expected) {
      throw Error(
        `Expected timestamp in example to be ${expected}, but found ${firstBusTimestamp}`
      );
    }
  };

  assertPart1Example(exampleInput, 59);
  assertPart2Example("7,13", 77);
  assertPart2Example(exampleInput[1], 1068781);
  assertPart2Example("17,x,13,19", 3417);
  assertPart2Example("67,7,59,61", 754018);
  assertPart2Example("67,x,7,59,61", 779210);
  assertPart2Example("67,7,x,59,61", 1261476);
  assertPart2Example("1789,37,47,1889", 1202161486);

  const part1 = getEarliestBus(input);
  const part2 = getFirstBusTimestamp(input[1]);

  return (
    <div>
      <h2>Day 13</h2>
      <p>
        The ID of the earliest bus I can take multiplied by the number of
        minutes to wait in part 1 is{" "}
        {part1.earliestBus.busId *
          (part1.earliestBus.nextTime - part1.earliestDeparture)}
      </p>
      <p>
        The earliest timestamp such that all of the listed bus IDs depart at
        offsets matching their positions in the list for part 2 is{" "}
        {part2.toString()}
      </p>
    </div>
  );
}

export default Day13;
