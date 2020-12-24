const player1 = [
  23,
  32,
  46,
  47,
  27,
  35,
  1,
  16,
  37,
  50,
  15,
  11,
  14,
  31,
  4,
  38,
  21,
  39,
  26,
  22,
  3,
  2,
  8,
  45,
  19,
];
const player2 = [
  13,
  20,
  12,
  28,
  9,
  10,
  30,
  25,
  18,
  36,
  48,
  41,
  29,
  24,
  49,
  33,
  44,
  40,
  6,
  34,
  7,
  43,
  42,
  17,
  5,
];

type Player = {
  player: number;
  hand: number[];
};

function Day22() {
  const playCombat = (player1: Player, player2: Player): Player => {
    while (player1.hand.length && player2.hand.length) {
      const player1Card = player1.hand.shift() as number;
      const player2Card = player2.hand.shift() as number;
      if (player1Card > player2Card) {
        player1.hand.push(player1Card, player2Card);
      } else {
        player2.hand.push(player2Card, player1Card);
      }
    }

    return player1.hand.length ? player1 : player2;
  };

  const playRecursiveCombat = (player1: Player, player2: Player): Player => {
    const seenHands = new Set<string>();

    while (player1.hand.length && player2.hand.length) {
      const handKey = `${player1.hand.join(",")}:${player2.hand.join(",")}`;
      if (seenHands.has(handKey)) {
        return player1;
      } else {
        seenHands.add(handKey);
      }

      const player1Card = player1.hand.shift() as number;
      const player2Card = player2.hand.shift() as number;

      if (
        player1.hand.length >= player1Card &&
        player2.hand.length >= player2Card
      ) {
        const winner = playRecursiveCombat(
          { ...player1, hand: [...player1.hand].slice(0, player1Card) },
          { ...player2, hand: [...player2.hand].slice(0, player2Card) }
        );
        if (winner.player === 1) {
          player1.hand.push(player1Card, player2Card);
        } else {
          player2.hand.push(player2Card, player1Card);
        }
      } else {
        if (player1Card > player2Card) {
          player1.hand.push(player1Card, player2Card);
        } else {
          player2.hand.push(player2Card, player1Card);
        }
      }
    }

    return player1.hand.length ? player1 : player2;
  };

  const handScore = (hand: number[]) =>
    hand.reduce((score, currentCard, cardIndex) => {
      return (score += currentCard * (hand.length - cardIndex));
    }, 0);

  const part1Winner = playCombat(
    { player: 1, hand: [...player1] },
    { player: 2, hand: [...player2] }
  );
  const part1Score = handScore(part1Winner.hand);

  // const part2Winner = playRecursiveCombat(
  //   { player: 1, hand: [...player1] },
  //   { player: 2, hand: [...player2] }
  // );
  // const part2Score = handScore(part2Winner.hand);

  return (
    <div>
      <h2>Day 22</h2>
      <p>The winning players score in part 1 is {part1Score}</p>
      {/* <p>The winning players score in part 2 is {part2Score}</p> */}
      <p>The winning players score in part 2 is (commented out)</p>
    </div>
  );
}

export default Day22;
