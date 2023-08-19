import axios from "../api/axios";
import ArtikalDto from '../Models/ArtikalDto';

export const GetArtikle = async(token) => {
    const GET_ARTIKLE_URL = "/products";
    try{
        const { data } = await axios.get(
            `${process.env.REACT_APP_API_BACK}${GET_ARTIKLE_URL}`,
                {
                    headers: {
                    "Content-Type": "application/json",
                    Authorization : `Bearer ${token}`
                    },
                }
            );
        const artikli = data.map(artikal => {
            return new ArtikalDto(artikal);
        })   
        return artikli;
    }catch(err){
        alert("Nesto se desilo prilikom dobavljanja artikala");
        return null;
    }
}