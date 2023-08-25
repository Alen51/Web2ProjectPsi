import axios from "../api/axios";
import ResponseDto from "../Models/ResponseDto";
import KorisnikDto from "../Models/KorisnikDto.js";


export const LoginUser = async (email,lozinka) => {
  const LOGIN_URL = "/users/login";
  var msgl;
  try {
    const { data } = await axios.post(
       "https://localhost:7034/api/users/login",
      JSON.stringify({ email, lozinka }),
      {
        headers: { "Content-Type": "application/json" },
        withCredentials: true,
      }
    );
    msgl=data;
    
    const response = new ResponseDto(data);
    return response;

  } catch (err) {
    alert("Error while login:"+msgl);
    return null;
  }
};

export const RegisterUser = async (korisnikJSON) => {
    const REGISTRATION_URL = "/users/registration";
    var msg1;
    try{
       const {data} = await axios.post(`${process.env.REACT_APP_API_BACK}${REGISTRATION_URL}`,
            korisnikJSON,
            {
                headers:{'Content-Type' : 'application/json'},
                withCredentials: true
            }
        );
        const response = new ResponseDto(data);
        msg1=response.result;
        return response;
    }catch(err){
        alert("Nesto se desilo prilikom registracije"+ msg1);
        
        return null;
    }
}

export const EditProfile = async (updatedKorisnikJSON, id, token) => {
  const UPDATE_URL = "/users/" + id ; //treba da dobije id isto
  try{
      const {data} = await axios.put(
          `${process.env.REACT_APP_API_BACK}${UPDATE_URL}`,
          updatedKorisnikJSON,
          {
              headers: 
              {
                  'Content-Type' : 'application/json',
                  'Authorization' : token
              },
              withCredentials: true
          }
      );
      const updatedKorisnik = new KorisnikDto(data);
      return updatedKorisnik;
  }catch(err){
      console.log(err);
      alert("Error while profile data edit")
  }
}

export const GetAllProdavce = async (token) => {
  const GET_PRODAVCE_URL = '/users/getProdavce'
  try{
      const {data} = await axios.get(
          `${process.env.REACT_APP_API_BACK}${GET_PRODAVCE_URL}`,
          {
              headers:{
                  'Content-Type' : 'application/json',
                  Authorization : `Bearer ${token}`
              },
          }
      );
      const prodavci = data.map(prodavac => {
          return new KorisnikDto(prodavac);
      })
      return prodavci;
  }catch(err){
      console.log(err);
      alert("Nesto se desilo prilikom dobavljanja prodavaca");
      return null;
  }
}

export const VerifyProdavca = async (prodavacId, buttonType, token) =>{
  const VERIFY_PRODAVCA = '/users/verifyProdavca/';
  try{
      const {data} = await axios.put(
          `${process.env.REACT_APP_API_BACK}${VERIFY_PRODAVCA}${prodavacId}`,
          buttonType,
          {
              headers:{
                  'Content-Type' : 'application/json',
                  'Authorization' : `Bearer ${token}`
              },
              withCredentials: true
          }
      );
      const verifikovaniProdavci = data.map(verifikovanProdavac => {
          return new KorisnikDto(verifikovanProdavac);
      })
      return verifikovaniProdavci;
  }catch(err){
      console.log(err);
      alert("Nesto se desilo prilikom verifikacije prodavca");
      return null;
  }

}
