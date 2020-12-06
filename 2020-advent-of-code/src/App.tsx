import React from "react";
import "./App.css";
import Day1 from "./days/day1";
import Day2 from "./days/day2";
import Day3 from "./days/day3";
import Day4 from "./days/day4";
import Day5 from "./days/day5";
import Day6 from "./days/day6";

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
      </div>
    </div>
  );
}

export default App;
