import { number } from "prop-types";
import React from "react";

function Day1() {
  const input: number[] = [
    1977,
    1515,
    1857,
    1800,
    1737,
    1778,
    1505,
    1958,
    1982,
    1941,
    1417,
    1232,
    1234,
    2005,
    1637,
    1956,
    1252,
    1457,
    1494,
    1317,
    1388,
    1630,
    1207,
    1536,
    1225,
    1369,
    1343,
    1502,
    1616,
    1744,
    1950,
    1280,
    1647,
    1780,
    1435,
    1915,
    1365,
    1707,
    1795,
    1554,
    1652,
    539,
    1892,
    1546,
    1908,
    1629,
    1836,
    1805,
    1395,
    1360,
    1487,
    1739,
    1884,
    1427,
    1615,
    1470,
    1922,
    1753,
    1632,
    1968,
    1429,
    2008,
    1124,
    1441,
    1384,
    1955,
    1815,
    1741,
    1331,
    1442,
    1988,
    1788,
    1585,
    1794,
    1217,
    1434,
    1751,
    1240,
    1284,
    1883,
    1711,
    1376,
    1638,
    1932,
    1979,
    1769,
    1597,
    896,
    1691,
    1379,
    1386,
    1658,
    2009,
    1885,
    1721,
    1619,
    1825,
    1688,
    1544,
    1934,
    1484,
    1720,
    1215,
    1371,
    1752,
    1692,
    1745,
    1911,
    1453,
    1723,
    1856,
    1270,
    1397,
    812,
    1610,
    1712,
    1829,
    1524,
    1541,
    1338,
    1383,
    1592,
    2006,
    1823,
    1410,
    1422,
    1394,
    1933,
    1572,
    1697,
    1736,
    2003,
    1301,
    1817,
    1902,
    1389,
    1490,
    1705,
    1329,
    1458,
    1510,
    1625,
    1676,
    1443,
    1539,
    1710,
    24,
    1586,
    1948,
    1994,
    1975,
    1974,
    1237,
    1419,
    1748,
    1589,
    1821,
    1462,
    1792,
    1381,
    1400,
    1222,
    1602,
    2001,
    1976,
    1700,
    1626,
    1966,
    1548,
    1593,
    2010,
    1149,
    1372,
    1224,
    1675,
    1271,
    1896,
    1983,
    1299,
    1528,
    1631,
    1804,
    1562,
    1754,
    1566,
    1473,
    1980,
    465,
    1868,
    1304,
    1279,
    1963,
    1582,
    1713,
    1330,
    1758,
    1551,
    1241,
    1469,
    1888,
  ];

  const expenseMap = input.reduce(
    (map: { [key: number]: number }, row: number) => {
      map[row] = row;
      return map;
    },
    {}
  );

  const find2 = (
    expenseMap: { [key: number]: number },
    desiredSum: number
  ): number[] => {
    return Object.keys(expenseMap).reduce((matches: number[], key: string) => {
      const firstMatch = Number(key);
      const secondMatch = desiredSum - firstMatch;

      if(expenseMap[secondMatch]) {
        matches = [firstMatch, secondMatch]
      }

      return matches;
    }, []);
  };

  const find3 = (
    expenseMap: { [key: number]: number },
    desiredSum: number
  ): number[] => {
    return Object.keys(expenseMap).reduce((matches: number[], key: string) => {
      const firstMatch = Number(key);      
      const secondMatches = find2(expenseMap, desiredSum - firstMatch);

      if(secondMatches.length === 2) {
        matches = [firstMatch, ...secondMatches];
      }
      
      return matches;
    }, []);
  };

  const part1 = find2(expenseMap, 2020);
  const part2 = find3(expenseMap, 2020);

  return (
    <div>
      <h2>Day 1</h2>
      <p>
        Part 1: {part1[0]} * {part1[1]} = {part1[0] * part1[1]}
      </p>
      <p>
        Part 2: {part2[0]} * {part2[1]} * {part2[2]} ={" "}
        {part2[0] * part2[1] * part2[2]}
      </p>
    </div>
  );
}

export default Day1;
