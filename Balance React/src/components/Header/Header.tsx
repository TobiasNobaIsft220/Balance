import './header.css';
import { useState, useEffect } from 'react';

interface UsuarioProp {
    id: number,
    name: string,
    email: string,
    password: string,
    bestScore: number,
    lastScore: number,
    gamesPlayed: number
}

export function Header(){

    const [usuario, setUsuario] = useState<UsuarioProp | null>(null);

    useEffect(() =>{
        const token = localStorage.getItem("token");

        if(!token){
            return;
        }

        const obtenerPerfil = async () =>{
            const res = await fetch("http://localhost:3000/api/perfil", {
                headers: {
                    Authorization: "Bearer " + token
                }
            });

            const data = await res.json();

            if(data.usuario){
                setUsuario(data.usuario);
            }
        };

        obtenerPerfil();

    }, []);

    return(
        <>
            <header>

                {usuario ? (
                  <div className='header'>
                    
                        <nav className="nav">

                            <a href="home"><img className='icon' src='../../../img/Icon-Balance.png' alt="Icon-Balance" /></a>

                            <a href="home"><button className="botonNav">Home</button></a>
                            <a href="clasificaciones"><button className="botonNav">Clasificaciones</button></a>

                            <a href="cuenta" ><button className='botonNav'><img className='iconUser' src="../../../img/User-Icon.png" alt="User-Icon"/></button></a>

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