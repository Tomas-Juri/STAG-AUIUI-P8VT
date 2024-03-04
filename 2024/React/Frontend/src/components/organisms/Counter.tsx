import { useState } from "react";

type Props = {
    value: number;
    onChange: () => void;
}

export const Counter = (props: Props) => {
  return (
    <div>
      <div>{props.value}</div>
      <button onClick={() => props.onChange()}>Increment</button>
    </div>
  );
};
