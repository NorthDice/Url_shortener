import axios from 'axios';

export const fetchUrls = async () => {
    try{
        var response = await axios.get("https://localhost:44367/Url/AllUrls");

        return response.data;
    } catch (error) {
        console.error(error);
        return [];
    }

}