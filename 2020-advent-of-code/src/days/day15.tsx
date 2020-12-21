import { assert } from "../helpers/testHelpers";

type SpokenNumber = {
  spokenOn: number;
  previouslySpokenOn: number;
};

function Day15() {
  const findNthNumberSpoken = (input: number[], n: number): number => {
    const spokenNumbers: Map<number, SpokenNumber> = input.reduce(
      (map: Map<number, SpokenNumber>, value: number, index: number) => {
        map.set(value, { spokenOn: index + 1, previouslySpokenOn: -1 });
        return map;
      },
      new Map()
    );

    let lastNumberSpoken = input[input.length - 1];
    for (var currentTurn = input.length + 1; currentTurn <= n; currentTurn++) {
      const spokenNumber = spokenNumbers.get(lastNumberSpoken) as SpokenNumber;
      if (spokenNumber.previouslySpokenOn === -1) {
        lastNumberSpoken = 0;
      } else {
        lastNumberSpoken =
          spokenNumber.spokenOn - spokenNumber.previouslySpokenOn;
      }

      let previouslySpokenOn = -1;
      if (spokenNumbers.has(lastNumberSpoken)) {
        previouslySpokenOn = (spokenNumbers.get(
          lastNumberSpoken
        ) as SpokenNumber).spokenOn;
      }
      spokenNumbers.set(lastNumberSpoken, {
        spokenOn: currentTurn,
        previouslySpokenOn,
      });
    }

    return lastNumberSpoken;
  };

  assert(findNthNumberSpoken([0, 3, 6], 2020), 436);
  assert(findNthNumberSpoken([1, 3, 2], 2020), 1);
  assert(findNthNumberSpoken([2, 1, 3], 2020), 10);
  assert(findNthNumberSpoken([1, 2, 3], 2020), 27);
  assert(findNthNumberSpoken([2, 3, 1], 2020), 78);
  assert(findNthNumberSpoken([3, 2, 1], 2020), 438);
  assert(findNthNumberSpoken([3, 1, 2], 2020), 1836);

  return (
    <div>
      <h2>Day 15</h2>
      <p>
        The 2020th number spoken in part 1 is{" "}
        {findNthNumberSpoken([5, 2, 8, 16, 18, 0, 1], 2020)}
      </p>
      {/* <p>The 30000000th number spoken in part 2 is {findNthNumberSpoken([5,2,8,16,18,0,1], 30000000)}</p> */}
      <p>The 30000000th number spoken in part 2 is (commented out)</p>
    </div>
  );
}

export default Day15;
