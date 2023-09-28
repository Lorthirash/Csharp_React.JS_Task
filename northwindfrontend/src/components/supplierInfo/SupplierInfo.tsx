import React, { useState, useEffect } from "react";
import SupplierInfoService from "../../services/SupplierInfoService";
import { SupplierModel } from "../../models/SupplierInfoModel";
import { SupplierProductModel } from "../../models/SupplierInfoModel";

import Card from "../UI/Card";

function SupplierInfo() {
  const [suppliers, setSuppliers] = useState<SupplierModel[]>([]);
  const [selectedSupplier, setSelectedSupplier] = useState<number | null>(null);
  const [productsForSelectedSupplier, setProductsForSelectedSupplier] =
    useState<SupplierProductModel[] | null>(null);

  useEffect(() => {
    async function fetchSuppliers() {
      try {
        const supplierData = await SupplierInfoService.getSupplierProductInfo();
        setSuppliers(supplierData);
      } catch (error) {
        console.error("An error occurred during the request:", error);
      }
    }

    fetchSuppliers();
  });

  useEffect(() => {
    if (selectedSupplier !== null) {
      const selectedSupplierData = suppliers.find(
        (s) => s.supplierID === selectedSupplier
      );
      if (selectedSupplierData) {
        setProductsForSelectedSupplier(selectedSupplierData.products);
      } else {
        setProductsForSelectedSupplier([]);
      }
    }
  }, [selectedSupplier, suppliers]);

  const handleSupplierChange = (
    event: React.ChangeEvent<HTMLSelectElement>
  ) => {
    const selectedSupplierID = parseInt(event.target.value);
    setSelectedSupplier(selectedSupplierID);
  };

  return (
    <Card>
      <h1 className="mt-4">Supplier Product Information</h1>
      <select onChange={handleSupplierChange} value={selectedSupplier || ""}>
        <option value="">Select a supplier...</option>
        {suppliers.map((supplier) => (
          <option key={supplier.supplierID} value={supplier.supplierID}>
            {supplier.companyName}
          </option>
        ))}
      </select>
      {selectedSupplier !== null && (
        <div>
          {productsForSelectedSupplier !== null &&
          productsForSelectedSupplier.length > 0 ? (
            <table className="table table-striped">
              <thead>
                <tr>
                  <th scope="col">Product Name</th>
                  <th scope="col">Ordered Value</th>
                </tr>
              </thead>
              <tbody>
                {productsForSelectedSupplier.map((product) => (
                  <tr key={product.productID}>
                    <td>{product.productName}</td>
                    <td>{product.totalOrderedValue}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          ) : (
            <p>No product information available for the selected supplier.</p>
          )}
        </div>
      )}
    </Card>
  );
}

export default SupplierInfo;
