import { useState } from "react";
import { Layout } from "../organisms";
import Button from "react-bootstrap/Button";
import Alert from "react-bootstrap/Alert";

export const CounterPage = () => {
  const [count, setCount] = useState(0);

  return (
    <Layout>
      <h1>Counter example!</h1>
      <Alert>Count is {count}</Alert>
      <Button variant="primary" onClick={() => setCount(count + 1)}>
        Click me
      </Button>
    </Layout>
  );
};
