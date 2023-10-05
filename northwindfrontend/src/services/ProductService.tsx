import axios from "axios";
import ProductModel from "../models/ProductModel";
import { environment } from "../environments/environment";


const productService = {
  getAvailableProducts: async (): Promise<ProductModel[]> => {
    try {
      const response = await axios.get<ProductModel[]>(
        `${environment.apiUrl}/Product/AvailableProducts`
      );
      return response.data;
    } catch (error) {
     
      console.error("An error occurred during the request:", error);

      
      throw error;
    }
  },
};

export default productService;
