import './Account.css';
import {Header} from '../../components/Header/Header';
import {Footer} from '../../components/Footer/Footer';
import { useState, useEffect } from 'react';
import { useNavigate } from "react-router-dom";

interface UsuarioProp {
    id: number,
    name: string,
    email: string,
    password: string,
    bestScore: number,
    lastScore: number,
    gamesPlayed: number
}

export function Account(){

    const [usuario, setUsuario] = useState<UsuarioProp | null>(null);
    
    const Navigate = useNavigate();

    useEffect(() => {
        const token = localStorage.getItem("token");
        if (!token) return;
    
        const cargarUsuario = async () => {
            const res = await fetch("http://localhost:3000/api/perfil", {
                headers: {
                Authorization: "Bearer " + token
                }
            });
    
        const data = await res.json();
        if (data.usuario) setUsuario(data.usuario);
        };
    
        cargarUsuario();
        }, []);

    const logout = () => {
        localStorage.removeItem("token");
        setUsuario(null);
        Navigate("/")
    };

    return(
        <>

            <Header/>

            <section className="fondoAccount">
                <div className="contenedorAccount">
                    <h1>Cuenta</h1>
                    <h2>Nombre: {usuario?.name}</h2>
                    <h2>Mejor puntuacion: {usuario?.bestScore}</h2>
                    <h2>Ultima puntuacion: {usuario?.lastScore}</h2>
                    <h2>Partidas jugadas: {usuario?.gamesPlayed}</h2>

                    <button className='botonCerrarSesion' onClick={logout}>Cerrar sesion</button>
                </div>
            </section>

            <Footer/>

        </>
    );
}