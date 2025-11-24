import './Login.css';
import {Header} from '../../components/Header/Header';
import {Footer} from '../../components/Footer/Footer';
import {useState} from "react";
import { useNavigate } from 'react-router-dom';

export function Login(){

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const Navigate = useNavigate();

    const loginUserReact = async (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();

        const respuesta = await fetch("http://localhost:3000/api/login", {
            method: "POST",
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify({ email, password})
        });

        const data = await respuesta.json();
        console.log(data);
        alert(data.message);

        if (data.token) {
        localStorage.setItem("token", data.token);
        Navigate("/")
        }

    }

    return(
        <>
            <Header/>

            <section className="fondoLogin">
                <div className="contenedorLogin">

                    <div className="contenedorLoginSuperior">
                        <img className="icon" src="../../../img/Icon-Balance.png" alt="Icon-Balance"/>

                        <h1>Iniciar Sesión</h1>
                    </div>

                    <div className="contenedorLoginInferior">
                        <form action="">

                            <label>Email:</label>
                            <br/>

                            <input className='inputLogin' type="email" onChange={(e) => setEmail(e.target.value)}/>
                            <br/>
                            <br/>

                            <label>Contraseña:</label>
                            <br/>

                            <input className='inputLogin' type="password" onChange={(e) => setPassword(e.target.value)}/>
                            <br/>
                            <a className='aLogin' href="crear-cuenta">¿Aun no tienes una cuenta?</a>
                            <br/>
                            <br/>

                            <button className="botonLogin" onClick={loginUserReact}>Iniciar sesión</button>
                        </form>
                    </div>

                </div>
            </section>

            <Footer/>
        </>
    );
}