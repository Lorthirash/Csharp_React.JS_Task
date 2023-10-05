import axios from "axios";
import { SupplierModel } from "../models/SupplierInfoModel";
import { SupplierProductModel } from "../models/SupplierInfoModel";
import { environment } from "../environments/environment";



const SupplierInfoService = {
    getSupplierProductInfo: async (): Promise<SupplierModel[]> => {
      try {
        const response = await axios.get<SupplierModel[]>(
          `${environment.apiUrl}/Product/SupplierProductInfo`
        );
        return response.data;
      } catch (error) {
        
        console.error("An error occurred during the request:", error);
  
        
        throw error;
      }
    },
  };
export default SupplierInfoService;
