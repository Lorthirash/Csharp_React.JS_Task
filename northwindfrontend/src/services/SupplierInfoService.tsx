import axios from "axios";
import { SupplierModel } from "../models/SupplierInfoModel";
import { SupplierProductModel } from "../models/SupplierInfoModel";

const API_BASE_URL = "https://localhost:7215/api";

const SupplierInfoService = {
    getSupplierProductInfo: async (): Promise<SupplierModel[]> => {
      try {
        const response = await axios.get<SupplierModel[]>(
          `${API_BASE_URL}/Product/SupplierProductInfo`
        );
        return response.data;
      } catch (error) {
        
        console.error("An error occurred during the request:", error);
  
        
        throw error;
      }
    },
  };
export default SupplierInfoService;
