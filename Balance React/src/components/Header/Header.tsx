import './header.css';
import { useState, useEffect } from 'react';

export function Header(){

    const [usuario, setUsuario] = useState<any>(null);

    useEffect(() =>{
        const token = localStorage.getItem("token");

        if(token){
            obtenerPerfil(token);
        }
    }, []);


    const obtenerPerfil = async (token: string) =>{
        const res = await fetch("http://localhost:3000/api/perfil", {
            headers: {
                authorization: "Bearer " + token
            }
        });

        if(res.ok){
            const data = await res.json();
            setUsuario(data.usuario);
        }else{
            setUsuario(null);
            localStorage.removeItem("token");
        }
    }


    return(
        <>
            <header>

                {usuario ? (
                  <div className='header'>
                    
                        <nav className="nav">

                            <a href="home"><img className='icon' src='../../../img/Icon-Balance.png' alt="Icon-Balance" /></a>

                            <a href="home"><button className="botonNav">Home</button></a>
                            <a href="clasificaciones"><button className="botonNav">Clasificaciones</button></a>

                            <a href="">lollllllllllllllllllllll</a>

                        </nav>

                    </div>
                ): (
                    <div className='header'>
                    
                        <nav className="nav">

                            <a href="home"><img className='icon' src='../../../img/Icon-Balance.png' alt="Icon-Balance" /></a>

                            <a href="home"><button className="botonNav">Home</button></a>
                            <a href="clasificaciones"><button className="botonNav">Clasificaciones</button></a>

                            <a  href="iniciar-sesion"><button className="botonNav">Iniciar sesión</button></a>
                            <a  href="crear-cuenta"><button className="botonNav">Crear cuenta</button></a>

                        </nav>

                    </div>
                )}
                
            </header>
        </>
    );
}