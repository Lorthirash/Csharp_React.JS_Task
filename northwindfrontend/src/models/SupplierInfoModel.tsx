export interface SupplierModel {
  supplierID: number;
  companyName: string;
  products: SupplierProductModel[];
}
export interface SupplierProductModel {
  productID: number;
  productName: string;
  totalOrderedValue: number;
}
