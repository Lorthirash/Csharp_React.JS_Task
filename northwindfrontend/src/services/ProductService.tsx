import axios from "axios";
import ProductModel from "../models/ProductModel"; // Az elérési út legyen a megfelelő helyre mutató

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

      // Tovább dobja a hibát a hívó kód felé
      throw error;
    }
  },
};

export default productService;
