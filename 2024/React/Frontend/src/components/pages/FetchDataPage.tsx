import { useEffect, useState } from "react";
import { Layout } from "../organisms";
import { api } from "../../api";
import { Endpoints } from "../../api/endpoints";
import Table from 'react-bootstrap/Table';

type WeatherForecast = {
  id: string;
  date: Date;
  temperatureC: number;
  summary: string;
};

export const FetchDataPage = () => {
  const [data, setData] = useState<WeatherForecast[]>([]);

  useEffect(() => {
    api()
      .get<WeatherForecast[]>(Endpoints.WeatherForecast.Index)
      .then((response) => setData(response.data));
  }, []);

  return (
    <Layout>
      <h1>Fetch data example!</h1>
      <Table striped bordered hover className="mt-4">
        <thead>
          <tr>
            <th>Id</th>
            <th>Date</th>
            <th>Temperature</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {data.map(forecast => <tr>
            <td>{forecast.id}</td>
            <td>{forecast.date.toLocaleString('cs')}</td>
            <td>{forecast.temperatureC}°C</td>
            <td>{forecast.summary}</td>
          </tr>)}
        </tbody>
        </Table>  
    </Layout>
  );
};
