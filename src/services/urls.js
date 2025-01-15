import axios from 'axios';

export const fetchUrls = async () => {
    try{
        var response = await axios.get("https://localhost:44367/Url/AllUrls");
    } catch (error) {
        console.error(error);
    }

    console.log(response);
}