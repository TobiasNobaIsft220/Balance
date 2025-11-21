import './Login.css';
import {Header} from '../../components/Header/Header';
import {Footer} from '../../components/Footer/Footer';
import {useState} from "react";

export function Login(){

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const loginUserReact = async () => {
        const respuesta = await fetch("http://localhost:3000/api/usuarios/login", {
            method: "POST",
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify({ email, password})
        });

        const data = await respuesta.json();
        console.log(data);
        alert(data.message);

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

                            <button className="botonLogin" onClick={(e) => {e.preventDefault(); loginUserReact();}}>Iniciar sesión</button>
                        </form>
                    </div>

                </div>
            </section>

            <Footer/>
        </>
    );
}