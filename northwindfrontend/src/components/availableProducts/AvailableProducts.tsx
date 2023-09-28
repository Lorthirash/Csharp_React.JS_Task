import React, { useEffect, useState } from "react";
import productService from "../../services/ProductService";
import ProductModel from "../../models/ProductModel";
import Card from "../UI/Card";

function AvailableProduct() {
  const [products, setProducts] = useState<ProductModel[]>([]);

  useEffect(() => {
    async function fetchProducts() {
      try {
        const availableProducts = await productService.getAvailableProducts();
        setProducts(availableProducts);
      } catch (error) {
        console.error("An error occurred during the request:", error);
      }
    }

    fetchProducts();
  });

  return (
    <Card>
      <h1 className="mt-4">Available product</h1>
      <table className="table table-striped">
        <thead>
          <tr>
            <th scope="col">Product ID</th>
            <th scope="col">Product Name</th>
            <th scope="col">Supplier ID</th>
            <th scope="col">Category ID</th>
            <th scope="col">Quantity Per Unit</th>
            <th scope="col">Unit Price (USD)</th>
            <th scope="col">Units In Stock</th>
            <th scope="col">Units On Order</th>
            <th scope="col">Reorder Level</th>
            <th scope="col">Discontinued</th>
          </tr>
        </thead>
        <tbody>
          {products.map((product) => (
            <tr key={product.productID}>
              <td>{product.productID}</td>
              <td>{product.productName}</td>
              <td>{product.supplierID}</td>
              <td>{product.categoryID}</td>
              <td>{product.quantityPerUnit}</td>
              <td>{product.unitPrice} USD</td>
              <td>{product.unitsInStock} db</td>
              <td>{product.unitsOnOrder}</td>
              <td>{product.reorderLevel}</td>
              <td>{product.discontinued ? "Yes" : "No"}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </Card>
  );
}

export default AvailableProduct;
