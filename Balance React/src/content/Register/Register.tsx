import './Register.css';
import {Header} from '../../components/Header/Header';
import {Footer} from '../../components/Footer/Footer';
import { useState } from 'react';

export function Register(){

    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");

    const registerUserReact = async () => {
        const respuesta = await fetch("http://localhost:3000/api/usuarios/registrar", {
            method: "POST",
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify({name, email, password, confirmPassword})
        });

        const data = await respuesta.json();
        console.log(data);
        alert(data.message);

    }

    return(
        <>

            <Header/>

            <section className="fondoRegister">
                <div className="contenedorRegister">

                    <div className="contenedorRegisterSuperior">
                        <img className="icon" src="../../../img/Icon-Balance.png" alt="Icon-Balance"/>

                        <h1>Crear cuenta</h1>
                    </div>

                    <div className="contenedorRegisterInferior">
                        <form action="">

                            <label>Nombre de usuario:</label>
                            <br/>

                            <input className='inputRegister' type="text" onChange={(e) => setName(e.target.value)}/>
                            <br/>
                            <br/>

                            <label>Email:</label>
                            <br/>

                            <input className='inputRegister' type="email" onChange={(e) => setEmail(e.target.value)}/>
                            <br/>
                            <br/>

                            <label>Contraseña:</label>
                            <br/>

                            <input className='inputRegister' type="password" onChange={(e) => setPassword(e.target.value)}/>
                            <br/>
                            <br/>

                            <label>Repetir contraseña:</label>
                            <br/>

                            <input className='inputRegister' type="password" onChange={(e) => setConfirmPassword(e.target.value)}/>
                            <br/>
                            <br/>

                            <button className="botonRegister" onClick={(e) => {e.preventDefault(); registerUserReact();}}>Crear cuenta</button>
                        </form>
                    </div>
                </div>
            </section>

            <Footer/>
            
        </>
    );
}