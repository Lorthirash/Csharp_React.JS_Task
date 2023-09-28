import axios from "axios";
import ProductModel from "../models/ProductModel"; 

const API_BASE_URL = "https://localhost:7215/api";

const productService = {
  getAvailableProducts: async (): Promise<ProductModel[]> => {
    try {
      const response = await axios.get<ProductModel[]>(
        `${API_BASE_URL}/Product/AvailableProducts`
      );
      return response.data;
    } catch (error) {
     
      console.error("An error occurred during the request:", error);

      
      throw error;
    }
  },
};

export default productService;
