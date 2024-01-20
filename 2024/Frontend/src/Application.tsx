import "bootstrap/dist/css/bootstrap.min.css";
import { Routes, Route } from "react-router-dom";
import { HomePage, CounterPage, FetchDataPage } from "./components/pages";

export const Application = () => (
  <Routes>
    <Route index element={<HomePage />} />
    <Route path="/counter" element={<CounterPage />} />
    <Route path="/fetch-data" element={<FetchDataPage />} />
  </Routes>
);
