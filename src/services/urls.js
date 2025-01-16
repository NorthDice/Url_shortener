import axios from 'axios';

const apiUrl = "https://localhost:44367/Url";

export const fetchUrls = async () => {
    try{
        const response = await axios.get(`${apiUrl}/AllUrls`);

        return response.data;
    } catch (error) {
        console.error(error);
        return [];
    }

}
export const addUrl = async (url) => {
    try {
      console.log("Sending URL:", url);  
      const response = await axios.post(`${apiUrl}/Shorten`, { url });
      console.log("Response from server:", response.data);  
      return response.data;  
    } catch (error) {
      console.error('Error adding URL:', error);
      return null;
    }
  };