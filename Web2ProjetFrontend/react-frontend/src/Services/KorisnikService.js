import axios from "../api/axios";
import ResponseDto from "../Models/ResponseDto";
import KorisnikDto from "../Models/KorisnikDto.js";


export const LoginUser = async (email,lozinka) => {
  const LOGIN_URL = "/users/login";
  try {
    const { data } = await axios.post(
      `${process.env.REACT_APP_API_BACK}${LOGIN_URL}`,
      JSON.stringify({ email, lozinka }),
      {
        headers: { "Content-Type": "application/json" },
        withCredentials: true,
      }
    );
    
    const response = new ResponseDto(data);
    return response;

  } catch (err) {
    alert("Nesto se desilo prilikom logovanja");
    return null;
  }
};

export const RegisterUser = async (korisnikJSON) => {
    const REGISTRATION_URL = "/users/registration";
    try{
        const {data} = await axios.post(`${process.env.REACT_APP_API_BACK}${REGISTRATION_URL}`,
            korisnikJSON,
            {
                headers:{'Content-Type' : 'application/json'},
                withCredentials: true
            }
        );
        const response = new ResponseDto(data);
        return response;
    }catch(err){
        alert("Nesto se desilo prilikom registracije");
        return null;
    }
}
