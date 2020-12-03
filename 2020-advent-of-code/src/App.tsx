import React from "react";
import "./App.css";
import Day1 from "./days/day1";
import Day2 from "./days/day2";
import Day3 from "./days/day3";

function App() {
  return (
    <div className="App">
      <header>
        <h1>Advent of Code 2020</h1>
      </header>
      <body>
        <div>
          <Day1 />
          <Day2 />
          <Day3 />
        </div>
      </body>
    </div>
  );
}

export default App;
