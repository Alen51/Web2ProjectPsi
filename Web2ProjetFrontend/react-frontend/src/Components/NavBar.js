import React from "react";
import { NavLink, useNavigate } from "react-router-dom";

const NavBar = ({isAuth, tipKorisnika, statusVerifikacije, handleLogout}) => {

    const active = (isActive) =>{
        if(isActive)
            return "item active"
        else
            return "item"
    }

    

    return (
        <div className="navbar" >
            
            <nav className="navbar">
            <div className="navbar-item">
            {/*nelogovani i neregistrovani korisnici
            oni vide home, register i login. Posle cu dodavati za role, da li je korisnik ovakav ili onakav*/}
            {isAuth ? null : <NavLink color="red" className={({isActive}) => active(isActive)} to="/" ><li className="nav-link">Home page</li></NavLink> }
            {isAuth ? null : <NavLink className={({isActive}) => active(isActive)} to="/login"><li className="nav-link">Log in</li></NavLink> }
            {isAuth ? null : <NavLink className={({isActive}) => active(isActive)} to="/registration"><li className="nav-link">Registration</li></NavLink>}
            
            {/* logovani korisnik koji je kupac, dodati proveru za role*/}
            {isAuth && tipKorisnika === 'Kupac' ?<li className="nav-link"> <NavLink className={({isActive}) => active(isActive)} to="/kupacDashboard">Kupac Dashboard</NavLink></li> : null}  
            {/*isAuth && tipKorisnika === 'Kupac' ? <NavLink className={({isActive}) => active(isActive)} to="/kupacPoruci"></NavLink> : null*/}
            {isAuth && tipKorisnika === 'Kupac' ? <li className="nav-link"> <NavLink  className={({isActive}) => active(isActive)} to="/kupacPorudzbine">Kupac porudzbine</NavLink></li> : null}
            

            {/*logovani korisnik koji je prodavac, dodati proveru za role, dodati da li je korisnik verifikovan*/}
            {isAuth && tipKorisnika === 'Prodavac' ? <li className="nav-link"><NavLink className={({isActive}) => active(isActive)} to="/prodavacDashboard">Prodavac dashboard</NavLink></li> : null}
            {isAuth && tipKorisnika === 'Prodavac' && statusVerifikacije === 'Prihvacen' ? <li className="nav-link"> <NavLink className={({isActive}) => active(isActive)} to="/prodavacDodajArtikal">Prodavac dodaj artikal</NavLink></li> : null}
            {isAuth && tipKorisnika === 'Prodavac' && statusVerifikacije === 'Prihvacen' ? <li className="nav-link"><NavLink className={({isActive}) => active(isActive)} to="/prodavacNovePorudzbine">Prodavac nove porudzbine</NavLink> </li>: null}
            {isAuth && tipKorisnika === 'Prodavac' && statusVerifikacije === 'Prihvacen' ? <li className="nav-link"><NavLink className={({isActive}) => active(isActive)} to="/prodavacPrethodnePorudzbine">Prodavac prethodne porudzbine</NavLink></li> : null}
            {isAuth && tipKorisnika === 'Prodavac' && statusVerifikacije === 'Prihvacen' ? <li className="nav-link"><NavLink className={({isActive}) => active(isActive)} to="/prodavacPregledArtikala">Pregled Artikala</NavLink></li> : null}

            {/*logovani korisnik koji je admin, dodati proveru za role*/}
            {isAuth && tipKorisnika === 'Administrator' ?<li className="nav-link"> <NavLink className={({isActive}) => active(isActive)} to="/adminDashboard">Admin dashboard</NavLink></li> : null}
            {isAuth && tipKorisnika === 'Administrator' ?<li className="nav-link"> <NavLink className={({isActive}) => active(isActive)} to="/adminVerifikacija">Admin Verifikaicja</NavLink></li> : null}
            {isAuth && tipKorisnika === 'Administrator' ?<li className="nav-link"> <NavLink className={({isActive}) => active(isActive)} to="/adminSvePorudzbine">Admin sve porudzbine</NavLink> </li>: null}
           

            {/*logovani korisnik bez obzira na ulogu*/}
            {isAuth && statusVerifikacije === 'Prihvacen' ?<li className="nav-link"><NavLink className={({isActive}) => active(isActive)} to="/profil">Profil</NavLink></li> : null}
            {isAuth ?<li className="nav-link"> <NavLink className={({isActive}) => active(isActive)} onClick={handleLogout} to="/">Logout</NavLink></li> : null}
            </div>
            </nav>

        </div>
    )
}


export default NavBar;