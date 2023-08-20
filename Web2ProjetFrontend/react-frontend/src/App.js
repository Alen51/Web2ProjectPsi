
import './App.css';

import Home from './Components/Home';
import NavBar from './Components/NavBar';
import Login from './Components/LoginAndRegisterComponents/Login';
import Registration from './Components/LoginAndRegisterComponents/Registration';
import { Route, Routes } from 'react-router-dom';
import { useEffect, useState } from 'react';
import KupacDashboard from './Components/KupacComponents/KupacDashboard';
import KupacPorudzbine from './Components/KupacComponents/KupacPorudzbine';
import KupacPoruci from './Components/KupacComponents/KupacPoruci';
import ProdavacDashboard from './Components/ProdavacComponents/ProdavacDashboard';
import ProdavacDodajArtikal from './Components/ProdavacComponents/ProdavacDodajArtikal';
import Profil from './Components/ProfileComponents/Profil';

function App() {

  //da li je korisnik autentifikovan, on je atuentifikovan i posle registracije i posle logovanje
  const [isAuth, setIsAuth] = useState(false);
  const [tipKorisnika, setTipKorisnika] = useState('');
  const [statusVerifikacije, setStatusVerifikacije] = useState('');
  const [isKorisnikInfoGot, setIsKorisnikInfoGot] = useState(false);  //ovo govori da li smo dobili podatke o korisniku
  
  useEffect(() => {
    const getAuth = () => {
        if(sessionStorage.getItem('korisnik') !== null && sessionStorage.getItem('isAuth') !== null){
            setIsAuth(JSON.parse(sessionStorage.getItem('isAuth')))
            const korisnik = JSON.parse(sessionStorage.getItem('korisnik'))
            setTipKorisnika(korisnik.tipKorisnika);
            setStatusVerifikacije(korisnik.statusVerifikacije);
        }
    }
    getAuth();
  }, [isKorisnikInfoGot]); //kada dobijemo ove podatke, ova funkcija ce se rerenderovati i onda ce se azurirati stanja
                            //na taj nacin izqazvacemo ponovno azuriranje stranice i onda navbara, nadam se da je tako
  
  const handleKorisnikInfo = (gotKorisnikInfo) => {
    setIsKorisnikInfoGot(gotKorisnikInfo);
  }

  const handleLogout = () => {
    sessionStorage.removeItem('korisnik');
    sessionStorage.removeItem('isAuth');
    sessionStorage.removeItem('token');
    setIsAuth(false);
    setStatusVerifikacije('');
    setTipKorisnika('');
    setIsKorisnikInfoGot(false);  
  
    
  }

  

  const routes = [
    {path: '/', element: <Home></Home>},
    {path: '/login', element: <Login handleKorisnikInfo={handleKorisnikInfo}></Login>},
    {path: '/registration', element: <Registration handleKorisnikInfo={handleKorisnikInfo}></Registration>},
    {path: '/kupacDashboard', element: <KupacDashboard></KupacDashboard>},
    {path: '/kupacDashboard/kupacPoruci' , element:<KupacPoruci></KupacPoruci>},
    {path: '/kupacPorudzbine', element: <KupacPorudzbine></KupacPorudzbine>},
    {path: '/kupacPorudzbine/PrikazPorudzbine/:id', element: <Home></Home>},
    {path: '/prodavacDashboard', element: <ProdavacDashboard></ProdavacDashboard>},
    {path: '/prodavacDodajArtikal', element:<ProdavacDodajArtikal></ProdavacDodajArtikal>},
    {path: '/prodavacNovePorudzbine', element: <Home></Home>},
    {path: '/prodavacPrethodnePorudzbine', element: <Home></Home>},
    {path: '/prodavacNovePorudzbine/PrikazPorudzbine/:id', element: <Home></Home>},
    {path: '/prodavacPrethodnePorudzbine/PrikazPorudzbine/:id', element: <Home></Home>},
    {path: '/prodavacPregledArtikala', element:<Home></Home>},
    {path: '/prodavacPregledArtikala/IzmeniArtikal/:id', element: <Home></Home>},
    {path: '/adminDashboard', element: <Home></Home>},
    {path: '/adminVerifikacija', element: <Home></Home>},
    {path: '/adminSvePorudzbine', element: <Home></Home>},
    {path: '/adminSvePorudzbine/PrikazPorudzbine/:id', element: <Home></Home>},
    {path: '/profil', element: <Profil></Profil>}
    
  ]

  return (
    <div className='App'>
     
      <NavBar isAuth={isAuth} tipKorisnika = {tipKorisnika} statusVerifikacije={statusVerifikacije} handleLogout={handleLogout}/>
      <div className='container'>
        <Routes>
          {
            routes.map((route) => (
              <Route path={route.path} element={route.element}></Route>
            ))
          }
        </Routes>
        
      </div>
      
    </div>
  );
}


export default App;
