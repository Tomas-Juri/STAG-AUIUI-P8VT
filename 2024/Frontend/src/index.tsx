import React from "react";
import { createRoot } from "react-dom/client";
import { BrowserRouter } from "react-router-dom";
import { Application } from "./Application.tsx";

const baseUrl =
  document.getElementsByTagName("base")[0].getAttribute("href") ?? "";
const rootElement = document.getElementById("root")!;
const root = createRoot(rootElement);

root.render(
  <BrowserRouter basename={baseUrl}>
    <Application/>
  </BrowserRouter>
);
