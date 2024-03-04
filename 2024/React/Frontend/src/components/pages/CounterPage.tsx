import { useEffect, useState } from "react";
import { Counter, Layout } from "../organisms";
import Button from "react-bootstrap/Button";
import Alert from "react-bootstrap/Alert";

export const CounterPage = () => {
  const [count, setCount] = useState(0);

  useEffect(() => {
    console.log('Hello' + count)

    return () => console.log('Bye')
  })
  
  return (
    <Layout>
      <h1>Counter example!</h1>
      <Alert>Count is {count}</Alert>
      <Counter value={count} onChange={() => setCount(count + 1)} />
    </Layout>
  );
};
