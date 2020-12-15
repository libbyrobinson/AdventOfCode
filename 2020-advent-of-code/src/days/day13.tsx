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

  const getFirstBusTimestamp = (input: string[]) => {
    return 0;
    // const earliestDeparture = Number(input[0]);

    // const buses = input[1]
    //   .split(",")
    //   .filter((bus: string) => bus !== "x")
    //   .map((bus: string) => Number(bus))
    //   .map((bus: number) => {
    //     return {
    //       busId: bus,
    //       nextTime: Math.ceil(earliestDeparture / bus) * bus,
    //     };
    //   })
    //   .sort((n1, n2) => n1.nextTime - n2.nextTime);

    // return {
    //   earliestDeparture,
    //   earliestBus: buses[0],
    // };
  };

  const exampleBus = getEarliestBus(exampleInput);
  if (exampleBus.earliestBus.busId !== 59) {
    throw Error(
      `Expected bus 59 to be earliest in the example, but was actually ${exampleBus.earliestBus.busId}`
    );
  }

  // needs to be >        100000000000000
  // max number in ts is 9007199254740991
  const exampleTimestamp = getFirstBusTimestamp(exampleInput);
  if (exampleTimestamp !== 1068781) {
    throw Error(
      `Expected the first bus to depart at 1068781 in the example, but was actually ${exampleTimestamp}`
    );
  }

  const bus = getEarliestBus(input);

  return (
    <div>
      <h2>Day 13</h2>
      <p>
        The ID of the earliest bus I can take multiplied by the number of
        minutes to wait in part 1 is{" "}
        {bus.earliestBus.busId *
          (bus.earliestBus.nextTime - bus.earliestDeparture)}
      </p>
    </div>
  );
}

export default Day13;
