import React from "react";
import "./App.css";
import Day1 from "./days/day1";
import Day10 from "./days/day10";
import Day11 from "./days/day11";
import Day12 from "./days/day12";
import Day2 from "./days/day2";
import Day3 from "./days/day3";
import Day4 from "./days/day4";
import Day5 from "./days/day5";
import Day6 from "./days/day6";
import Day7 from "./days/day7";
import Day8 from "./days/day8";
import Day9 from "./days/day9";

function App() {
  return (
    <div className="App">
      <header>
        <h1>Advent of Code 2020</h1>
      </header>
      <div>
        <Day1 />
        <Day2 />
        <Day3 />
        <Day4 />
        <Day5 />
        <Day6 />
        <Day7 />
        <Day8 />
        <Day9 />
        <Day10 />
        <Day11 />
        <Day12 />
      </div>
    </div>
  );
}

export default App;
