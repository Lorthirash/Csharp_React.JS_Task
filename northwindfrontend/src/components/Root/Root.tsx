import React from "react";
import { Outlet } from "react-router-dom";
import Navbar from "../navBar/NavBar";
import AvailableProduct from "../availableProducts/AvailableProducts";

function RootLayout() {
  return (
    <>
      <Navbar />
      <main >
        <Outlet />
       
      </main>
    </>
  );
}
export default RootLayout;
