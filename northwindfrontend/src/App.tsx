import React from "react";
import "./App.css";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import AvailableProducts from "./components/availableProducts/AvailableProducts";
import SupplierInfo from "./components/supplierInfo/SupplierInfo";
import Home from "./components/Home/Home";
import RootLayout from "./components/Root/Root";
import ErrorPage from "./components/Error/ErrorPage";

const router = createBrowserRouter([
  {
    path: "/",
    element: <RootLayout />,
    errorElement: <ErrorPage />,
    children: [
      { path: "/", element: <Home /> },
      { path: "/products", element: <AvailableProducts /> },
      { path: "/supplierinfo", element: <SupplierInfo /> },
    ],
  },
]);

function App() {
  return <RouterProvider router={router} />;
}

export default App;
